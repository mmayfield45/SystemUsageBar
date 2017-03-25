using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SystemUsageBar
{
    class RamGraphElement : Element
    {
        public const string RamSettingsSectionName = "RAM";
        public const string ExpandOnHoverSettingName = "ExpandOnHover";
        public const string GraphColorSettingName = "GraphColor";

        private readonly Settings.SettingsSection _settings = Settings.Current.GetSection(RamSettingsSectionName);

        private bool _expanded = false;
        private int _expandedCount;
        private float _lastRamUsage = 0;
        private string _status = string.Empty;

        public RamGraphElement()
            : base()
        {
            _settings.SettingChanging += new System.Configuration.SettingChangingEventHandler(OnSettingChanging);

            this.PreferredSize = new Size(10, 0);
            this.UpdateInfo();
        }


        private void OnSettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            this.Invalidate();
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (_settings.GetBool(ExpandOnHoverSettingName))
            {
                Expand();
            }
        }


        private void CalculateSize()
        {
            using (Bitmap bitmap = new System.Drawing.Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bitmap))
            using (Font f = new Font(SystemFonts.SmallCaptionFont.FontFamily, 8))
            {
                SizeF oSize = g.MeasureString(_status, f);
                this.PreferredSize = new Size((int)Math.Ceiling(oSize.Width) + 8, 0);
            }

        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ToggleExpand();
            }
        }

        protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ToggleExpand();
            }
        }


        private void ToggleExpand()
        {
            if (_expanded)
            {
                Contract();
            }
            else
            {
                Expand();
            }
        }

        private void Expand()
        {
            CalculateSize();
            _expanded = true;
            _expandedCount = 6;
        }

        private void Contract()
        {
            this.PreferredSize = new Size(10, 0);
            _expanded = false;
            _expandedCount = 0;
        }

        public override void UpdateInfo()
        {
            base.UpdateInfo();

            //TODO: contract using timer
            if (_settings.GetBool(ExpandOnHoverSettingName) && !this.IsMouseOver && _expandedCount > 0)
            {
                _expandedCount--;
                if (_expandedCount == 0)
                {
                    Contract();
                }
            }

            WinApi.Structures.MemoryStatusEx mem = new WinApi.Structures.MemoryStatusEx();
            if (WinApi.Kernal32.GlobalMemoryStatusEx(mem))
            {
                _lastRamUsage = (mem.ullTotalPhys - mem.ullAvailPhys) / (float)mem.ullTotalPhys;
                _lastRamUsage = Math.Min(1.0f, _lastRamUsage);
                _status = ((Math.Round((mem.ullTotalPhys - mem.ullAvailPhys) / 1048576.0)) + " / " + (Math.Round(mem.ullTotalPhys / 1048576.0)));
            }

            this.Invalidate();

        }

        protected override void DrawContents(System.Drawing.Graphics g, System.Drawing.Rectangle rect)
        {
            base.DrawContents(g, rect);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

            if (_expanded)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(64, _settings.GetColor(GraphColorSettingName))))
                {
                    int nRamWidth = (int)(rect.Width * _lastRamUsage);
                    Rectangle rGraph = new Rectangle(rect.X, rect.Y, nRamWidth, rect.Height);
                    g.FillRectangle(brush, rGraph);
                }

                using (StringFormat sf = new StringFormat())
                //using (Font f = new Font(SystemFonts.SmallCaptionFont.FontFamily, 8))
                {
                    sf.Trimming = StringTrimming.EllipsisCharacter;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    using (SolidBrush br = new SolidBrush(this.ForeColor))
                    using (Pen p = new Pen(Color.FromArgb(48, 0, 0, 0), 2f))
                    {
                        //g.DrawString(_status, f, br, new System.Drawing.RectangleF(rect.X, rect.Y, rect.Width, rect.Height), sf);
                        
                        // win7
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        GraphicsPath textPath = new GraphicsPath();
                        textPath.AddString(_status, SystemFonts.SmallCaptionFont.FontFamily, (int)FontStyle.Bold, 10f, new RectangleF(rect.X, rect.Y, rect.Width, rect.Height), sf);
                        g.DrawPath(p, textPath);
                        g.FillPath(br, textPath);
                    }
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(196, _settings.GetColor(GraphColorSettingName))))
                {
                    int nRamHeight = (int)(rect.Height * _lastRamUsage);
                    Rectangle rGraph = new Rectangle(rect.X, rect.Y + (rect.Height - nRamHeight), rect.Width, nRamHeight);
                    g.FillRectangle(brush, rGraph);
                }
            }
        }
    }
}
