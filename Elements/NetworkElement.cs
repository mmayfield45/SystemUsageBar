using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SystemUsageBar.Elements
{
    class NetworkElement : Element
    {
        private readonly NetworkInfo _networkInfo;
        private readonly GraphDrawer _graphDrawer;

        private ulong _rx;
        private ulong _tx;
        private string _strRx = null;
        private string _strTx = null;

        public NetworkElement()
        {
            _graphDrawer = new GraphDrawer();           
            _graphDrawer.Color = Color.CornflowerBlue;

            _networkInfo = new NetworkInfo();

            CalculateSize();
        }

        public override async void UpdateInfo()
        {
            base.UpdateInfo();

            NetworkInfoData info = await _networkInfo.GetNetworkInfoAsync();
            
            if (info.RxPerSecond != _rx)
            {
                _rx = info.RxPerSecond;
                _strRx = info.RxPerSecond == 0 ? null: "Rx: " + GetBytesReadable(info.RxPerSecond);
            }

            if (info.TxPerSecond != _tx)
            {
                _tx = info.TxPerSecond;
                _strTx = info.TxPerSecond == 0 ? null: "Tx: " + GetBytesReadable(info.TxPerSecond);
            }

            _graphDrawer.AddReading(_rx + _tx);

            Invalidate();
        }

        private void CalculateSize()
        {
            using (Bitmap bitmap = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bitmap))
            using (Font f = new Font(SystemFonts.SmallCaptionFont.FontFamily, 9, FontStyle.Bold))
            {
                SizeF oSize = g.MeasureString("Rx: 999.9 KB", f);
                double size = Math.Min(oSize.Width, 150);
                PreferredSize = new Size((int)Math.Ceiling(size) + 8, 0);
            }

            _graphDrawer.MaxReadings = PreferredSize.Width;
        }

        protected override void DrawContents(Graphics g, Rectangle rect)
        {
            base.DrawContents(g, rect);

            g.SmoothingMode = SmoothingMode.HighQuality;

            _graphDrawer.Draw(g, rect);

            if ((_strRx != null || _strTx != null) && IsMouseOver)
            {
                using (StringFormat sf = new StringFormat())
                using (Font f = new Font(SystemFonts.SmallCaptionFont.FontFamily, 9))
                {
                    sf.Trimming = StringTrimming.EllipsisCharacter;
                    sf.Alignment = StringAlignment.Far;

                    Color c = ForeColor;

                    using (SolidBrush br = new SolidBrush(c))
                    using (Pen p = new Pen(Color.FromArgb(48, 0, 0, 0), 2f))
                    {
                        if (_strRx != null)
                        {
                            GraphicsPath textPath = new GraphicsPath();
                            textPath.AddString(_strRx, f.FontFamily, (int)FontStyle.Bold, f.SizeInPoints * 1.33f, new RectangleF(rect.X, rect.Y - 1 + 3, rect.Width, f.Height), sf);
                            g.DrawPath(p, textPath);
                            g.FillPath(br, textPath);
                        }

                        if (_strTx != null)
                        {
                            GraphicsPath textPath = new GraphicsPath();
                            textPath.AddString(_strTx, f.FontFamily, (int)FontStyle.Bold, f.SizeInPoints * 1.33f, new RectangleF(rect.X, rect.Bottom - f.Height + 1 - 4, rect.Width, f.Height), sf);
                            g.DrawPath(p, textPath);
                            g.FillPath(br, textPath);
                        }
                    }
                }
            }
        }

        private static string GetBytesReadable(ulong length)
        {
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (length >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (length >> 50);
            }
            else if (length >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (length >> 40);
            }
            else if (length >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (length >> 30);
            }
            else if (length >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (length >> 20);
            }
            else if (length >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (length >> 10);
            }
            else if (length >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = length;
            }
            else
            {
                return length.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.#") + " " + suffix;
        }
    }
}
