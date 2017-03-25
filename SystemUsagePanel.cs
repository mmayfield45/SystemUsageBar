using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Drawing2D;
using SystemUsageBar.Elements;

namespace SystemUsageBar
{
    public partial class SystemUsagePanel : UserControl
    {
        private List<Element> _elements = new List<Element>();

        public SystemUsagePanel()
        {   
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.Opaque, true);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            SetupDefaultSettings();

            if (Settings.Current.GetSection(MediaInfoElement.MediaInfoSettingsSectionName).GetBool(MediaInfoElement.ElementEnabledSettingName))
            {
                _elements.Add(new MediaInfoElement());
            }

            _elements.Add(new NetworkElement());

            if (Settings.Current.GetSection(RamGraphElement.RamSettingsSectionName).GetBool(MediaInfoElement.ElementEnabledSettingName))
            {
                _elements.Add(new RamGraphElement());
            }
            if (Settings.Current.GetSection(CpuGraphElement.CpuSettingsSectionName).GetBool(MediaInfoElement.ElementEnabledSettingName))
            {
                _elements.Add(new CpuGraphElement());
            }

            if (Environment.OSVersion.Version >= new Version(6, 1))
            {
                _elements.Add(new Element() { Width = 2, PreferredSize = new Size(2, 0) });
            }

            foreach (var element in _elements)
            {
                element.PreferredSizeChanged += new EventHandler(Element_PreferredSizeChanged);
                element.VisibleChanged += new EventHandler(Element_VisibleChanged);
                this.Controls.Add(element);
            }


            CalculateSize();
        }


        private void SetupDefaultSettings()
        {
            Settings.SettingsSection _settings = Settings.Current.GetSection(Element.SettingsSectionName);
            _settings.SetDefault(Element.TextColorSettingName, Color.White);
            _settings.SetDefault(Element.FillOnHoverSettingName, true);
            _settings.SetDefault(Element.FillHoverColorSettingName, Color.White);
            _settings.SetDefault(Element.BackgroundColorSettingName, Color.White);
            _settings.SetDefault(Element.BorderColorSettingName, Color.Black);
            _settings.SetDefault(Element.ShowBackgroundSettingName, true);
            _settings.SetDefault(Element.ShowBorderSettingName, true);
            _settings.SetDefault(Element.StyleSettingName, "3D");

            _settings = Settings.Current.GetSection(CpuGraphElement.CpuSettingsSectionName);
            _settings.SetDefault(Element.ElementEnabledSettingName, true);
            _settings.SetDefault(CpuGraphElement.AlwaysShowTextSettingName, false);
            _settings.SetDefault(CpuGraphElement.SizeSettingName, 100);
            _settings.SetDefault(CpuGraphElement.GraphColorSettingName, Color.GreenYellow);

            _settings = Settings.Current.GetSection(RamGraphElement.RamSettingsSectionName);
            _settings.SetDefault(Element.ElementEnabledSettingName, true);
            _settings.SetDefault(RamGraphElement.ExpandOnHoverSettingName, false);
            _settings.SetDefault(RamGraphElement.GraphColorSettingName, Color.Yellow);

            _settings = Settings.Current.GetSection(MediaInfoElement.MediaInfoSettingsSectionName);
            _settings.SetDefault(Element.ElementEnabledSettingName, true);
            _settings.SetDefault(MediaInfoElement.ProgressColorSettingName, Color.FromArgb(0, 0, 164));
            _settings.SetDefault(MediaInfoElement.TrackingColorSettingName, Color.FromArgb(255, 195, 14));
            _settings.SetDefault(MediaInfoElement.TrackUnknownSongLengthsSettingName, true);
            _settings.SetDefault(MediaInfoElement.IsFixedSizeSettingName, false);
            _settings.SetDefault(MediaInfoElement.SizeSettingName, 80);
        }

        private void Element_VisibleChanged(object sender, EventArgs e)
        {
            CalculateSize();
        }

        private void Element_PreferredSizeChanged(object sender, EventArgs e)
        {
            CalculateSize();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            Rectangle drawrect = new Rectangle(0, 0, this.Width, this.Height);

            bool stylesEnabled = VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser;

            if (stylesEnabled && VisualStyleRenderer.IsElementDefined(VisualStyleElement.Taskbar.BackgroundBottom.Normal))
            {
                pevent.Graphics.Clear(Color.FromArgb(0, 0, 0, 0));

                //VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.Taskbar.BackgroundBottom.Normal);
                //renderer.DrawBackground(pevent.Graphics, drawrect);

                if (Environment.OSVersion.Version >= new Version(6, 2))
                {
                    // Win10 - No Fill
                }
                else  if (Environment.OSVersion.Version >= new Version(6, 2))
                {
                    // Win8
                    pevent.Graphics.DrawLine(new Pen(Color.FromArgb(69, 0, 0, 0), 1), new Point(0, 0), new Point(drawrect.Width, 0));
                    LinearGradientBrush gradient = new LinearGradientBrush(new Point(0, 0), new Point(0, drawrect.Height), Color.FromArgb(48, 0, 0, 0), Color.FromArgb(58, 0, 0, 0));
                    pevent.Graphics.FillRectangle(gradient, new Rectangle(0, 1, drawrect.Width, drawrect.Height));
                }
                else
                {
                    // Win7
                    pevent.Graphics.DrawLine(new Pen(Color.FromArgb(145, 0, 0, 0), 1), new Point(0, 0), new Point(drawrect.Width, 0));
                    pevent.Graphics.DrawLine(new Pen(Color.FromArgb(103, 255, 255, 255), 1), new Point(0, 1), new Point(drawrect.Width, 1));
                    pevent.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(58, 0, 0, 0)), new Rectangle(0, 2, drawrect.Width, drawrect.Height - 2));
                }
                /*
                Image im = new Bitmap(drawrect.Width, drawrect.Height);
                Graphics g = Graphics.FromImage(im);

                renderer.DrawBackground(g, drawrect);
                
                System.Drawing.Imaging.ImageAttributes ia = new System.Drawing.Imaging.ImageAttributes();
                System.Drawing.Imaging.ColorMatrix cm = new System.Drawing.Imaging.ColorMatrix();
                cm.Matrix33 = 0.8f;
                ia.SetColorMatrix(cm);

                pevent.Graphics.DrawImage(im, new Rectangle(0, 0, im.Width, im.Height), 0, 0, im.Width, im.Height, GraphicsUnit.Pixel, ia);
                 * */

            }
            else
            {
                using (SolidBrush brush = new SolidBrush(SystemColors.ButtonFace))
                {
                    pevent.Graphics.FillRectangle(brush, drawrect);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Element element in _elements)
            {
                element.UpdateInfo();
            }
        }

        private void CalculateSize()
        {
            int nWidth = 0;

            foreach (Element element in _elements)
            {
                if (element.Visible)
                {
                    nWidth += element.PreferredSize.Width;
                    nWidth += 1;
                }
            }

            nWidth -= 1;

            if (Width != nWidth)
            {
                Width = nWidth;
            }
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);

            int left = 0;
            foreach (var element in _elements)
            {
                if (element.Visible)
                {
                    element.Width = element.PreferredSize.Width;
                    element.Height = Height - 1; // Win7
                    element.Left = left;    
                    element.Top = 1; // Win7
                    left += element.Width;
                }
            }
        }


        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm.ShowOptions();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
