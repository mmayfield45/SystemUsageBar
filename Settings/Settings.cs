using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Xml;

namespace SystemUsageBar
{
    public sealed class Settings
    {

        public static Settings Current { get; internal set; }
        public static readonly string SettingsDirectory = GetSettingsDirectory();
        private static string GetSettingsDirectory()
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetCallingAssembly();
            string exeDir = Path.GetDirectoryName(ass.Location);

            //string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            
            return exeDir;
        }

        private Dictionary<string, SettingsSection> _sections = new Dictionary<string, SettingsSection>();

        static Settings()
        {
            Settings.Current = new Settings();
        }

        private Settings()
        {
            Load();
        }

        private void Load()
        {
            try
            {
                string settingsFile = SettingsDirectory + @"\Settings.xml";

                if (!System.IO.File.Exists(settingsFile))
                {
                    return;
                }
            
                XmlDocument doc = new XmlDocument();
                doc.Load(settingsFile);
                foreach (XmlElement element in doc.DocumentElement.ChildNodes)
                {
                    if (element.Name == "section")
                    {
                        LoadSection(element, element.Attributes["name"].Value);
                    }
                }

            }
            catch (Exception)
            { }
        }

        public void LoadSection(XmlElement section, string name)
        {
            if (!_sections.ContainsKey(name))
            {
                _sections[name] = new SettingsSection();
            }

            SettingsSection settingsSection = _sections[name];

            foreach (XmlElement settingElement in section.ChildNodes)
            {
                settingsSection._settings[settingElement.Name] = settingElement.InnerText;
            }

        }

        public void Save()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(SettingsDirectory + @"\Settings.xml", null);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("settings");

                foreach (var sections in _sections)
                {
                    writer.WriteStartElement("section");
                    writer.WriteAttributeString("name", sections.Key);
                    foreach(var kvp in sections.Value._settings)
                    {
                        writer.WriteStartElement(kvp.Key);
                        writer.WriteString(kvp.Value);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public SettingsSection GetSection(string name)
        {
            SettingsSection ret;
            if (!_sections.TryGetValue(name, out ret))
            {
                ret = new SettingsSection();
                _sections[name] = ret;
            }

            return ret;
        }

        public sealed class SettingsSection
        {
            internal Dictionary<string, string> _settings = new Dictionary<string, string>();
            private Dictionary<string, object> _defaults = new Dictionary<string, object>();

            internal SettingsSection()
            {}

            public event System.Configuration.SettingChangingEventHandler SettingChanging;

            private void OnSettingChanged(string settingKey, object settingValue)
            {
                SettingChangingEventArgs e = new SettingChangingEventArgs(settingKey, string.Empty, string.Empty, settingValue, false);
                SettingChangingEventHandler handler = this.SettingChanging;

                if (handler != null)
                {
                    handler(this, e);
                }
            }

            public void SetDefault(string name, object def)
            {
                _defaults[name] = def;
            }

            private T GetDefault<T>(string name)
            {
                object def;

                if (!_defaults.TryGetValue(name, out def))
                {
                    return default(T);
                }

                if (!(def is T))
                {
                    return default(T);
                }

                return (T)def;
            }

            public void Remove(string key)
            {
                _settings.Remove(key);
                OnSettingChanged(key, null);
            }

            public void SetString(string key, string value)
            {
                if (value == null)
                {
                    Remove(key);
                    return;
                }
                _settings[key] = value;
                OnSettingChanged(key, value);
            }

            public string GetString(string key)
            {
                return GetString(key, GetDefault<string>(key));
            }

            public string GetString(string key, string defaultValue)
            {
                string ret;
                if (!_settings.TryGetValue(key, out ret))
                {
                    return defaultValue;
                }

                return ret;
            }


            public void SetInt32(string key, int value)
            {
                _settings[key] = value.ToString();
                OnSettingChanged(key, value);
            }

            public int GetInt32(string key)
            {
                return GetInt32(key, GetDefault<int>(key));
            }

            public int GetInt32(string key, int defaultValue)
            {
                string ret;
                if (!_settings.TryGetValue(key, out ret))
                {
                    return defaultValue;
                }

                int ret2;
                if (!int.TryParse(ret, out ret2))
                {
                    return defaultValue;
                }

                return ret2;
            }


            public void SetColor(string key, System.Drawing.Color value)
            {
                _settings[key] = string.Format("{0},{1},{2},{3}", value.A, value.R, value.G, value.B);
                OnSettingChanged(key, value);
            }

            public System.Drawing.Color GetColor(string key)
            {
                return GetColor(key, GetDefault<System.Drawing.Color>(key));
            }

            public System.Drawing.Color GetColor(string key, System.Drawing.Color defaultValue)
            {
                string ret;
                if (!_settings.TryGetValue(key, out ret))
                {
                    return defaultValue;
                }

                string[] parts = ret.Split(",".ToCharArray());
                if (parts.Length != 4)
                {
                    return defaultValue;
                }

                int[] argb = new int[4];

                for (int i = 0; i < 4; i++)
                {
                    if (!int.TryParse(parts[i], out argb[i]) || argb[i] > 255 || argb[i] < 0)
                    {
                        return defaultValue;
                    }
                }

                return System.Drawing.Color.FromArgb(argb[0], argb[1], argb[2], argb[3]);
            }


            public void SetBool(string key, bool value)
            {
                _settings[key] = value.ToString();
                OnSettingChanged(key, value);
            }

            public bool GetBool(string key)
            {
                return GetBool(key, GetDefault<bool>(key));
            }

            public bool GetBool(string key, bool defaultValue)
            {
                string ret;
                if (!_settings.TryGetValue(key, out ret))
                {
                    return defaultValue;
                }

                bool ret2;
                if (!bool.TryParse(ret, out ret2))
                {
                    return defaultValue;
                }

                return ret2;
            }

        }

    }
}
