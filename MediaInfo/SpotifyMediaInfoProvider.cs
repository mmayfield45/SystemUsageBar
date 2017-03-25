using WinApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SystemUsageBar
{
    class SpotifyMediaInfoProvider : IMediaInfoProvider
    {
        const string lpClassName = "SpotifyMainWindow";
        const string SpotifyDefaultTitle = "Spotify";

        public MediaPlayerInfo GetMediaInfo()
        {
            IntPtr hwnd = User32.FindWindow(lpClassName, null);

            if (hwnd.Equals(IntPtr.Zero)) 
                return MediaPlayerInfo.Empty;

            string strTitle = User32.GetWindowText(hwnd);

            if (string.IsNullOrEmpty(strTitle)) return MediaPlayerInfo.Empty;

            MediaPlayerInfo info = new MediaPlayerInfo();

            if (strTitle == SpotifyDefaultTitle)
            {
                info.Status = MediaPlayerStatus.Stopped;
                info.Full = strTitle;
                return info;
            }

            info.Status = MediaPlayerStatus.Playing;
            info.Full = strTitle;


            Regex artistTitle = new Regex(@"^(.+) - (.+)$");
            MatchCollection col = artistTitle.Matches(strTitle);
            if (col.Count > 0)
            {
                info.Artist = col[0].Groups[1].Value;
                info.Title = col[0].Groups[2].Value;
            }

            return info;
        }

        public MediaPlayerStatus Status
        {
            get 
            {
                IntPtr hwnd = User32.FindWindow(lpClassName, null);

                if (hwnd.Equals(IntPtr.Zero))
                    return MediaPlayerStatus.NotRunning;

                string strTitle = User32.GetWindowText(hwnd);

                if(strTitle == SpotifyDefaultTitle)
                {
                    return MediaPlayerStatus.Playing;
                }

                return MediaPlayerStatus.Stopped;
            }
        }

    }
}
