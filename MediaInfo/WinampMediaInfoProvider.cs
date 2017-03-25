using System;
using System.Text.RegularExpressions;

namespace SystemUsageBar
{

    class WinampMediaInfoProvider : IMediaInfoProvider
    {

        const string lpClassName = "Winamp v1.x";
        const string strTtlEnd = " - Winamp";

        const int WM_USER = 1024;//0x4A;
        const int WA_GETSTATUS = 104;
        const int WA_GETTRACKINFO = 105;

        const int TRACKINFO_POSITION = 0;
        const int TRACKINFO_LEN = 1;

        private enum WinampStatus : int
        {
            NotRunning = -1,
            Stopped = 0,
            Playing = 1,
            Paused = 3,
        }


        public MediaPlayerInfo GetMediaInfo()
        {
            IntPtr hwnd = WinApi.User32.FindWindow(lpClassName, null);

            if (hwnd.Equals(IntPtr.Zero))
                return MediaPlayerInfo.Empty;

            WinampStatus winstatus = (WinampStatus)WinApi.User32.SendMessageA(hwnd, WM_USER, 0, WA_GETSTATUS);

            if (winstatus == WinampStatus.NotRunning) 
                return MediaPlayerInfo.Empty;

            MediaPlayerInfo info = new MediaPlayerInfo();
            info.Status = (MediaPlayerStatus)winstatus;

            info.TrackPosition = WinApi.User32.SendMessageA(hwnd, WM_USER, TRACKINFO_POSITION, WA_GETTRACKINFO);
            if (info.TrackPosition == -1) 
                info.TrackPosition = null;

            info.TrackLength = WinApi.User32.SendMessageA(hwnd, WM_USER, TRACKINFO_LEN, WA_GETTRACKINFO);
            if (info.TrackLength == -1) 
                info.TrackLength = null;

            string mediaTitle = GetSongTitle(hwnd);
            info.Full = mediaTitle;

            if (mediaTitle.StartsWith("["))
            {
                int endStatPos = mediaTitle.IndexOf(']');
                info.Other = (endStatPos != -1) ? mediaTitle.Substring(0, mediaTitle.IndexOf(']') + 1) : mediaTitle;
            }
            else
            {
                Regex titleArtistOther = new Regex(@"^(.+) - ([^\(]+) \((.+?)\)?$");
                MatchCollection col = titleArtistOther.Matches(mediaTitle);
                if (col.Count > 0)
                {
                    info.Artist = col[0].Groups[1].Value;
                    info.Title = col[0].Groups[2].Value;
                    info.Other = col[0].Groups[3].Value;

                }
                else
                {
                    Regex titleArtist = new Regex(@"^(.*) - (.*)$");
                    col = titleArtist.Matches(mediaTitle);
                    if (col.Count > 0)
                    {
                        info.Artist = col[0].Groups[1].Value;
                        info.Title = col[0].Groups[2].Value;
                    }
                    else
                    {
                        info.Other = mediaTitle;
                    }
                }

            }

            return info;
        }


        private string GetSongTitle(IntPtr hwnd)
        {
            string strTitle = WinApi.User32.GetWindowText(hwnd);

            if (string.IsNullOrEmpty(strTitle)) return "Unknown";
            
            //int intName = strTitle.IndexOf(strTtlEnd);
            //int intLeft = strTitle.IndexOf("[");
            //int intRight = strTitle.IndexOf("]");

            //if ((intName >= 0) && (intLeft >= 0) && (intName < intLeft) &&
            //    (intRight >= 0) && (intLeft + 1 < intRight))
            //    return strTitle.Substring(intLeft + 1, intRight - intLeft - 1);

            //if ((strTitle.EndsWith(strTtlEnd)) && (strTitle.Length > strTtlEnd.Length))
            //    strTitle = strTitle.Substring(0, strTitle.Length - strTtlEnd.Length);

            int winampPos = strTitle.LastIndexOf(strTtlEnd);

            if(winampPos > -1)
            {
                strTitle = strTitle.Remove(winampPos);
            }

            int intDot = strTitle.IndexOf(".");
            int val;
            if ((intDot > 0) && int.TryParse(strTitle.Substring(0, intDot), out val))
                strTitle = strTitle.Remove(0, intDot + 1);

            return strTitle.Trim();
        }


        public MediaPlayerStatus Status
        {
            get
            {
                IntPtr hwnd = WinApi.User32.FindWindow(lpClassName, null);

                if (hwnd.Equals(IntPtr.Zero))
                    return MediaPlayerStatus.NotRunning;

                WinampStatus winstatus = (WinampStatus)WinApi.User32.SendMessageA(hwnd, WM_USER, 0, WA_GETSTATUS);

                return (MediaPlayerStatus)winstatus;
            }
        }
    }

}
