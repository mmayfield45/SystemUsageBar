using System;
using System.Collections.Generic;
using System.Text;

namespace SystemUsageBar
{
    class MediaPlayerInfo
    {
        public MediaPlayerInfo()
        {
            Artist = string.Empty;
            Title = string.Empty;
            Other = string.Empty;
            Full = string.Empty;
            Status = MediaPlayerStatus.NotRunning;
        }

        public static readonly MediaPlayerInfo Empty = new MediaPlayerInfo();

        public string Artist { get; set; }
        public string Title { get; set; }
        public string Other { get; set; }
        public string Full { get; set; }

        public int? TrackLength { get; set; }
        public int? TrackPosition { get; set; }

        public MediaPlayerStatus Status { get; set; }        
    }
}
