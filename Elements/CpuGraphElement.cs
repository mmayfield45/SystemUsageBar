using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using SystemUsageBar.Elements;

namespace SystemUsageBar
{
    class CpuGraphElement : Element
    {
        public const string CpuSettingsSectionName = "CPU";
        public const string AlwaysShowTextSettingName = "AlwaysShowText";
        public const string SizeSettingName = "Size";
        public const string GraphColorSettingName = "GraphColor";

        private readonly Settings.SettingsSection _settings = Settings.Current.GetSection(CpuSettingsSectionName);

        private float _lastCpuUsage = 0;
        private GraphDrawer _graphDrawer;

        public CpuGraphElement()
        {
            _settings.SettingChanging += new System.Configuration.SettingChangingEventHandler(OnSettingChanging);

            int size = _settings.GetInt32(SizeSettingName);

            _graphDrawer = new GraphDrawer();     
            _graphDrawer.MaxReadings = size;
            _graphDrawer.MaxValue = 100f;

            PreferredSize = new Size(size, 0);
            UpdateInfo();
        }

        private void OnSettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            if (e.SettingName == SizeSettingName)
            {
                int size = (int)e.NewValue;
                _graphDrawer.MaxReadings = size;
                PreferredSize = new Size(size, 0);
            }
            else 
            {
                Invalidate();
            }
        }

        public override void UpdateInfo()
        {
            base.UpdateInfo();

            _lastCpuUsage = GetCpuUsage();

            _graphDrawer.AddReading(_lastCpuUsage);

            Invalidate();
        }

        protected override void DrawContents(Graphics g, Rectangle rect)
        {
            base.DrawContents(g, rect);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            _graphDrawer.Color = _settings.GetColor(GraphColorSettingName);
            _graphDrawer.Draw(g, rect);

            // cpu value on mouse over
            if (_settings.GetBool(AlwaysShowTextSettingName) || IsMouseOver)
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Center;
                string cpu = Math.Round(_lastCpuUsage).ToString();
                
                using (SolidBrush b = new SolidBrush(Color.FromArgb(200, this.ForeColor)))
                using (Pen p = new Pen(Color.FromArgb(48, 0, 0, 0), 2f))
                {
                    GraphicsPath textPath = new GraphicsPath();
                    textPath.AddString(cpu, FontFamily.GenericSansSerif, (int)FontStyle.Bold, 21f, new RectangleF(rect.X + 1, rect.Y, rect.Width - 2, rect.Height), sf);
                    g.DrawPath(p, textPath);
                    g.FillPath(b, textPath);
                }
            }
        }

        static ulong last_idleTime = 0;
        static ulong last_kernelTime = 0;
        static ulong last_userTime = 0;

        static float GetCpuUsage()
        {

            System.Runtime.InteropServices.ComTypes.FILETIME idleTime, kernelTime, userTime;
            WinApi.Kernal32.GetSystemTimes(out idleTime, out kernelTime, out userTime);

            ulong idle = FiletimeToLong(idleTime);
            ulong kernal = FiletimeToLong(kernelTime);
            ulong user = FiletimeToLong(userTime);

            ulong idl = idle - last_idleTime;
            ulong ker = kernal - last_kernelTime;
            ulong usr = user - last_userTime;

            last_idleTime = idle;
            last_kernelTime = kernal;
            last_userTime = user;

            ulong sys = ker + usr;

            float cpu = (sys - idl) * 100.0f / sys;
            cpu = (float.IsNaN(cpu) || float.IsInfinity(cpu)) ? 0 : cpu;
            cpu = Math.Min(100.0f, cpu);
            cpu = Math.Max(0.0f, cpu);

            return cpu;
        }

        static ulong FiletimeToLong(System.Runtime.InteropServices.ComTypes.FILETIME fileTime)
        {
            return (((ulong)fileTime.dwHighDateTime) << 32) + (uint)fileTime.dwLowDateTime;
        }
    }
}
