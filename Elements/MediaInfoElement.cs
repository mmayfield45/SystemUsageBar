using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SystemUsageBar
{
    class MediaInfoElement : Element
    {
        public const string MediaInfoSettingsSectionName = "MediaInfo";
        public const string ProgressColorSettingName = "ProgressColor";
        public const string TrackingColorSettingName = "TrackingColor";
        public const string TrackUnknownSongLengthsSettingName = "TrackUnknownSongLengths";
        public const string IsFixedSizeSettingName = "IsFixedSize";
        public const string SizeSettingName = "Size";

        private readonly Settings.SettingsSection _settings = Settings.Current.GetSection(MediaInfoSettingsSectionName);

        private string _strTop = "Loading..";
        private string _strBottom = "Loading..";
        private MediaPlayerInfo _info = MediaPlayerInfo.Empty;

        private DateTime _dtStartLastTrack = DateTime.MinValue;
        private TrackLengthRecorder _trackLengthRecorder = null;

        public MediaInfoElement()
            : base()
        {
            _settings.SettingChanging += new System.Configuration.SettingChangingEventHandler(OnSettingChanging);

            this.Visible = false;
            this.UpdateInfo();
        }

        private void OnSettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            if (e.SettingName == TrackUnknownSongLengthsSettingName)
            {
                bool trackUnknownSongLengthsSetting = (bool)e.NewValue;
                if (!trackUnknownSongLengthsSetting && _trackLengthRecorder != null)
                {
                    if (_trackLengthRecorder.IsRecording)
                    {
                        _trackLengthRecorder.EndRecordingTrackLength();
                    }
                    _dtStartLastTrack = DateTime.MinValue;
                    _trackLengthRecorder = null;
                }
            }

            this.Invalidate();
        }


        public override void UpdateInfo()
        {
            base.UpdateInfo();

            MediaPlayerInfo info = MediaManager.GetMediaInfo();

            if (info.Title != _info.Title || info.Artist != _info.Artist || info.Other != _info.Other)
            {
                // Song has changed
                if (_trackLengthRecorder != null && _trackLengthRecorder.IsRecording)
                {
                    _trackLengthRecorder.EndRecordingTrackLength();
                }

                if (_settings.GetBool(TrackUnknownSongLengthsSettingName) && info.TrackLength == null && TrackLengthRecorder.IsRecordableSong(info))
                {
                    // Start recording unknown song length
                    if (_trackLengthRecorder == null)
                    {
                        _trackLengthRecorder = new TrackLengthRecorder();
                    }
                    _trackLengthRecorder.BeginRecordingTrackLength(info);
                }

                _dtStartLastTrack = DateTime.Now;

                _strTop = info.Title;
                _strBottom = string.IsNullOrEmpty(info.Artist) ? info.Other : info.Artist;

                CalculateSize();

            }

            _info = info;

            if (_settings.GetBool(TrackUnknownSongLengthsSettingName) && _trackLengthRecorder != null && _info.TrackLength == null && 
                TrackLengthRecorder.IsRecordableSong(_info) && _dtStartLastTrack != DateTime.MinValue)
            {
                // we figure out the time
                int? length = _trackLengthRecorder.GetTrackLength(_info);
                if(length != null)
                {
                    _info.TrackLength = length.Value;
                    int nPosSeconds = (int)DateTime.Now.Subtract(_dtStartLastTrack).TotalSeconds;
                    _info.TrackPosition = nPosSeconds * 1000;
                    if (nPosSeconds > _info.TrackLength)
                    {
                        _info.TrackLength = nPosSeconds;
                    }
                }
            }

            this.Visible = !(_info.Status == MediaPlayerStatus.NotRunning || _info.Status == MediaPlayerStatus.Stopped);

            if (_info.Status != MediaPlayerStatus.Playing && _trackLengthRecorder != null && _trackLengthRecorder.IsRecording)
            {
                // stop saving track lengths if we are not playing
                _trackLengthRecorder.EndRecordingTrackLength();
                _dtStartLastTrack = DateTime.MinValue;
            }

            this.Invalidate();
        }

        private void CalculateSize()
        {
            if (_settings.GetBool(IsFixedSizeSettingName))
            {
                this.PreferredSize = new Size(_settings.GetInt32(SizeSettingName), 0);
                return;
            }

            using (Bitmap bitmap = new System.Drawing.Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bitmap))
            using (Font f = new Font(SystemFonts.SmallCaptionFont.FontFamily, 10, FontStyle.Bold))
            {
                SizeF oSize = g.MeasureString(_strTop, f);
                SizeF oSize2 = g.MeasureString(_strBottom, f);

                double size = Math.Max(oSize.Width, oSize2.Width);
                size = Math.Min(size, 300);

                this.PreferredSize = new Size((int)Math.Ceiling(size) + 8, 0);
            }

        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_settings.GetBool(IsFixedSizeSettingName))
            {
                this.Invalidate();
            }
        }

        protected override void DrawContents(System.Drawing.Graphics g, System.Drawing.Rectangle rect)
        {
            base.DrawContents(g, rect);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

            if (_info.TrackPosition != null && _info.TrackLength != null && _info.TrackLength.Value > 0)
            {              
                float fPos = _info.TrackPosition.Value / (_info.TrackLength.Value * 1000.0f);
                int nPos = (int)(rect.Width * fPos);
                if (nPos > rect.Width)
                {
                    nPos = rect.Width;
                }
                if (fPos == 1.0)
                {
                    using (LinearGradientBrush bra = new LinearGradientBrush(rect, Color.FromArgb(64, _settings.GetColor(ProgressColorSettingName)), Color.Transparent, 90))
                    {
                        g.FillRectangle(bra, rect);
                    }
                }
                else
                {
                    Rectangle gradRect = new Rectangle(nPos - 50, rect.Y, 50, rect.Height);
                    using (LinearGradientBrush br = new LinearGradientBrush(gradRect, Color.FromArgb(64, _settings.GetColor(ProgressColorSettingName)), Color.Transparent, 180))
                    {
                        g.FillRectangle(br, gradRect);
                    }
                    using (SolidBrush br = new SolidBrush(Color.FromArgb(32, _settings.GetColor(ProgressColorSettingName))))
                    {
                        g.FillRectangle(br, new Rectangle(rect.X, rect.Y, nPos, rect.Height));
                    }
                }
            }
            else if (_trackLengthRecorder!= null && _trackLengthRecorder.IsRecording)
            {
                // new song - unknown length
                using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(64, _settings.GetColor(TrackingColorSettingName)), Color.Transparent, 90))
                {
                    g.FillRectangle(br, rect);
                }
            }

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            using (StringFormat sf = new StringFormat())
            using (Font f = new Font(SystemFonts.SmallCaptionFont.FontFamily, 10))
            {
                sf.Trimming = StringTrimming.EllipsisCharacter;
                sf.Alignment = StringAlignment.Center;

                Color c = this.ForeColor;
                if(_info.Status != MediaPlayerStatus.Playing)
                {
                    c = Color.FromArgb(164, c);
                }

                using (SolidBrush br = new SolidBrush(c))
                using (Pen p = new Pen(Color.FromArgb(48, 0, 0, 0), 2f))
                {
                    if (!string.IsNullOrEmpty(_strTop) && !string.IsNullOrEmpty(_strBottom))
                    {
                        // win7
                        GraphicsPath textPath = new GraphicsPath();
                        textPath.AddString(_strTop, f.FontFamily, (int)FontStyle.Bold, f.SizeInPoints * 1.33f, new RectangleF(rect.X, rect.Y - 1 + 2, rect.Width, f.Height), sf);
                        g.DrawPath(p, textPath);
                        g.FillPath(br, textPath);
                        

                        sf.LineAlignment = StringAlignment.Far;

                        textPath = new GraphicsPath();
                        textPath.AddString(_strBottom, f.FontFamily, (int)FontStyle.Bold, f.SizeInPoints * 1.33f, new RectangleF(rect.X, rect.Bottom - f.Height + 1 - 3, rect.Width, f.Height), sf);
                        g.DrawPath(p, textPath);
                        g.FillPath(br, textPath);

                        //g.DrawString(_strTop, f, br, new System.Drawing.RectangleF
                        //        (rect.X, rect.Y - 1, rect.Width, f.Height), sf);

                        //sf.LineAlignment = StringAlignment.Far;

                        //g.DrawString(_strBottom, f, br, new System.Drawing.RectangleF
                        //        (rect.X, rect.Bottom - f.Height + 1, rect.Width, f.Height), sf);
                    }
                    else
                    {
                        sf.LineAlignment = StringAlignment.Center;

                        // win7
                        GraphicsPath textPath = new GraphicsPath();
                        textPath.AddString(string.IsNullOrEmpty(_strTop) ? _strBottom : _strTop, f.FontFamily, (int)FontStyle.Bold, f.SizeInPoints * 1.33f, 
                            new RectangleF(rect.X, rect.Y, rect.Width, rect.Height), sf);
                        g.DrawPath(p, textPath);
                        g.FillPath(br, textPath);

                        //g.DrawString(string.IsNullOrEmpty(_strTop) ? _strBottom : _strTop, f, br, new System.Drawing.RectangleF
                        //                            (rect.X, rect.Y, rect.Width, rect.Height), sf);
                    }
                }
                
            }

        }
    }
}