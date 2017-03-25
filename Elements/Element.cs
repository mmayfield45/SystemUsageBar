using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SystemUsageBar
{
    class Element : UserControl
    {
        public const string SettingsSectionName = "Misc";
        public const string TextColorSettingName = "TextColor";
        public const string FillHoverColorSettingName = "FillHoverColor";
        public const string FillOnHoverSettingName = "FillOnHover";
        public const string BackgroundColorSettingName = "BackgroundColor";
        public const string BorderColorSettingName = "BorderColor";
        public const string ShowBackgroundSettingName = "ShowBackground";
        public const string ShowBorderSettingName = "ShowBorder";
        public const string StyleSettingName = "Style";
        public const string ElementEnabledSettingName = "ElementEnabled";

        private readonly Settings.SettingsSection _settings = Settings.Current.GetSection(SettingsSectionName);

        public event EventHandler PreferredSizeChanged;

        private Size _preferredSize;
        public new Size PreferredSize
        {
            get { return _preferredSize; }
            set 
            { 
                if(_preferredSize != value)
                {
                    _preferredSize = value;
                    OnPreferredSizeChanged();
                }
            }
        }

        public bool IsMouseOver
        {
            get
            {
                return this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition));
            }
        }

        public Element()
        {
            _settings.SettingChanging += new System.Configuration.SettingChangingEventHandler(OnSettingChanging);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.BackColor = Color.Transparent;
            this.ForeColor = _settings.GetColor(TextColorSettingName);
        }

        private void OnSettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            if (e.SettingName == TextColorSettingName)
            {
                this.ForeColor = (Color)e.NewValue;
            }

            this.Invalidate();
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Invalidate();
        }


        public virtual void UpdateInfo()
        {

        }

        protected virtual void OnPreferredSizeChanged()
        {
            EventHandler handler = this.PreferredSizeChanged;
            if(handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw(e.Graphics);
        }

        protected void Draw(Graphics g)
        {
            Rectangle rect = this.ClientRectangle;
            Rectangle rContent = rect;

            g.SmoothingMode = SmoothingMode.Default;

            if (_settings.GetString(StyleSettingName) == "3D")
            {
                Draw3DContainer(g, rect, ref rContent);
            }
            else if (_settings.GetString(StyleSettingName) == "Flat")
            {
                DrawFlatContainer(g, rect, ref rContent);
            }

            // Draw contents and hover color
            if (rContent.Width > 0 && rContent.Height > 0)
            {
                RectangleF rSavedBounds = g.ClipBounds;
                g.SetClip(rContent);
                DrawContents(g, rContent);
                g.SetClip(rSavedBounds);

                if (this.IsMouseOver && _settings.GetBool(FillOnHoverSettingName))
                {
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(32, _settings.GetColor(FillHoverColorSettingName))))
                    {
                        g.FillRectangle(brush, rContent);
                    }
                }
            }
        }

        private void DrawFlatContainer(Graphics g, Rectangle rect, ref Rectangle content)
        {
            if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser)
            {
                rect.Y += 2;
                rect.Height -= 4;
                content = rect;
            }

            if (_settings.GetBool(ShowBackgroundSettingName))
            {
                using (SolidBrush brush = new SolidBrush(_settings.GetColor(BackgroundColorSettingName)))
                {
                    g.FillRectangle(brush, rect);
                }
            }
            if (_settings.GetBool(ShowBorderSettingName))
            {
                using (Pen pen = new Pen(_settings.GetColor(BorderColorSettingName), 1))
                {
                    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
                }
            }

            content.Inflate(-1, -1);
        }

        private void Draw3DContainer(Graphics g, Rectangle rect, ref Rectangle content)
        {
            if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser && VisualStyleRenderer.IsElementDefined(VisualStyleElement.ToolBar.Button.Hot))
            {
                if (Environment.OSVersion.Version >= new Version(6, 2))
                {
                    Draw3DContainer_Win8(g, rect, ref content);
                } 
                else if (Environment.OSVersion.Version >= new Version(6, 1))
                {
                    Draw3DContainer_Win7(g, rect, ref content);
                }
                else
                {
                    Draw3DContainer_Vista(g, rect, ref content);
                }

                //Rectangle r = rect;
                //r.X -= 1;
                //r.Width += 2;
                //r.Y += 0;
                //r.Height -= 0;

                //VisualStyleRenderer renderer = new VisualStyleRenderer("Taskband::Toolbar", VisualStyleElement.ToolBar.Button.Normal.Part, 3);
                //renderer.DrawBackground(g, r);
                ////vr.DrawText(e.Graphics, rect, "Test", false, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);

                //rContent.X += 2;
                //rContent.Width -= 4;
                //rContent.Y += 2;
                //rContent.Height -= 4;
            }
            else
            {
                ControlPaint.DrawBorder3D(g, rect, System.Windows.Forms.Border3DStyle.SunkenOuter);
                content.Inflate(-1, -1);
            }
        }

        private void Draw3DContainer_Vista(Graphics g, Rectangle rect, ref Rectangle content)
        {
            content.X += 2;
            content.Width -= 4;
            content.Y += 3;
            content.Height -= 6;

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(32, 0, 0, 0)))
            {
                g.FillRectangle(brush, content);
            }

            VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot);
            renderer.DrawBackground(g, rect);
        }

        private void Draw3DContainer_Win7(Graphics g, Rectangle rect, ref Rectangle content)
        {
            g.DrawLine(new Pen(Color.FromArgb(145, 0, 0, 0), 1), new Point(0, 0), new Point(0, rect.Height));
            g.DrawLine(new Pen(Color.FromArgb(103, 255, 255, 255), 1), new Point(1, 1), new Point(1, rect.Height));
            //g.DrawLine(new Pen(Color.FromArgb(103, 255, 255, 255), 1), new Point(rect.Width-2, 0), new Point(rect.Width-2, rect.Height));
            //g.DrawLine(new Pen(Color.FromArgb(145, 0, 0, 0), 1), new Point(rect.Width - 1, 0), new Point(rect.Width - 1, rect.Height));

            content.X += 1;
            content.Width -= 1;
            /*
            content.X += 2;
            content.Width -= 4;
            content.Y += 3;
            content.Height -= 6;

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(32, 0, 0, 0)))
            {
                g.FillRectangle(brush, content);
            }

            VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot);
            renderer.DrawBackground(g, rect);
             * */
        }

        private void Draw3DContainer_Win8(Graphics g, Rectangle rect, ref Rectangle content)
        {
            g.DrawLine(new Pen(Color.FromArgb(40, 0, 0, 0), 1), new Point(0, 0), new Point(0, rect.Height));

            content.X += 1;
            content.Width -= 1;
        }

        protected virtual void DrawContents(Graphics g, Rectangle rect)
        {

        }


    }
}
