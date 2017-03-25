using SystemUsageBar.MediaInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SystemUsageBar
{
    sealed class TrackLengthRecorder
    {
        private readonly string SavePath = System.IO.Path.Combine(Settings.SettingsDirectory, "SavedSongLengths.xml");

        private SavedSongLengths _dsSavedSongLengths = new SavedSongLengths();
        private MediaPlayerInfo _recordingTrack;
        private Stopwatch _sw;

        public bool IsRecording { get; private set; }

        public TrackLengthRecorder()
        {
            try
            {
                if (System.IO.File.Exists(SavePath))
                {
                    _dsSavedSongLengths.ReadXml(SavePath);
                }
            }
            catch(Exception)
            { }
        }

        public void BeginRecordingTrackLength(MediaPlayerInfo info)
        {
            if (!IsRecordableSong(info))
                return;

            _recordingTrack = info;
            _sw = new Stopwatch();
            this.IsRecording = true;
            _sw.Start();
        }

        public void EndRecordingTrackLength()
        {
            if (this.IsRecording)
            {
                _sw.Stop();
                SaveTrackLength(_recordingTrack, (int)_sw.Elapsed.TotalSeconds);
                this.IsRecording = false;
                _recordingTrack = null;
                _sw = null;
            }
        }

        private void SaveTrackLength(MediaPlayerInfo info, int length)
        {
            SavedSongLengths.SavedSongLengthRow drSavedSongLen = _dsSavedSongLengths.SavedSongLength.FindByartisttitle(info.Artist, info.Title);
            if (drSavedSongLen == null)
            {
                drSavedSongLen = _dsSavedSongLengths.SavedSongLength.NewSavedSongLengthRow();
                drSavedSongLen.artist = info.Artist;
                drSavedSongLen.title = info.Title;
                drSavedSongLen.length = 0;
                _dsSavedSongLengths.SavedSongLength.AddSavedSongLengthRow(drSavedSongLen);
            }
            if (length > drSavedSongLen.length)
            {
                drSavedSongLen.length = length;
                try
                {
                    _dsSavedSongLengths.WriteXml("SavedSongLengths.xml");
                }
                catch (Exception)
                { }
            }
        }

        public int? GetTrackLength(MediaPlayerInfo info)
        {
            if(info.Artist == null || info.Title == null)
                return null;

            SavedSongLengths.SavedSongLengthRow drSavedSongLen = _dsSavedSongLengths.SavedSongLength.FindByartisttitle(info.Artist, info.Title);
            if (drSavedSongLen != null)
                return drSavedSongLen.length;

            return null;
        }

        public static bool IsRecordableSong(MediaPlayerInfo info)
        {
            if(string.IsNullOrEmpty(info.Title))
                return false;

            if(string.IsNullOrEmpty(info.Artist))
                return false;

            /*
            if(info.Full != null && info.Full.Contains("Buffer"))
                return false;
            */
            return true;
        }
    }
}
