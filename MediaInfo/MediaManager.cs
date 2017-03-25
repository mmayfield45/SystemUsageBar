using System;
using System.Collections.Generic;
using System.Text;

namespace SystemUsageBar
{
    static class MediaManager
    {
        private static List<IMediaInfoProvider> _providers;
        private static IMediaInfoProvider _currentProvider;

        static MediaManager()
        {
            _providers = new List<IMediaInfoProvider>();
            _providers.Add(new SpotifyMediaInfoProvider());
            _providers.Add(new WinampMediaInfoProvider());
        }

        public static MediaPlayerInfo GetMediaInfo()
        {
            if(_currentProvider == null)
            {
                FindProvider();

                if(_currentProvider == null)
                    return MediaPlayerInfo.Empty;
            }

            MediaPlayerInfo info = _currentProvider.GetMediaInfo();

            if (info.Status != MediaPlayerStatus.Playing)
            {
                FindProvider();
                if(_currentProvider != null)
                {
                    return _currentProvider.GetMediaInfo();
                }
            }

            return info;
        }

        private static void FindProvider()
        {
            _currentProvider = null;
            IMediaInfoProvider pausedProvider = null;
            IMediaInfoProvider stopedProvider = null;

            // Find in order Playing, Pause, Stopped
            foreach (var provider in _providers)
            {
                MediaPlayerStatus stataus = provider.Status;
                if(stataus == MediaPlayerStatus.Playing)
                {
                    _currentProvider = provider;
                    return;
                }
                
                if (stataus == MediaPlayerStatus.Paused)
                {
                    pausedProvider = provider;
                }
                else if (stataus == MediaPlayerStatus.Stopped)
                {
                    stopedProvider = provider;
                }
            }

            if (pausedProvider != null)
            {
                _currentProvider = pausedProvider;
                return;
            }

            if (stopedProvider != null)
            {
                _currentProvider = stopedProvider;
                return;
            }

            _currentProvider = null;
        }
    }
}
