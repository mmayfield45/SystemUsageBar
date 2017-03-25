using System;
using System.Collections.Generic;
using System.Text;

namespace SystemUsageBar
{
    interface IMediaInfoProvider
    {
        MediaPlayerInfo GetMediaInfo();
        MediaPlayerStatus Status { get; }
    }

    public enum MediaPlayerStatus : int
    {
        NotRunning = -1,
        Stopped = 0,
        Playing = 1,
        Paused = 3,
    }
}
