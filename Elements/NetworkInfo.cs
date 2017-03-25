using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SystemUsageBar.Elements
{
    public class NetworkInfo
    {
        private readonly TimeSpan Over = TimeSpan.FromSeconds(1);

        private object _lock = new object();
        private NetworkInterface[] _nics = null;
        private List<NetworkSnapshot> _snapshots = new List<NetworkSnapshot>();

        public Task<NetworkInfoData> GetNetworkInfoAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    lock (_lock)
                    {
                        return GetNetworkInfo();
                    }
                }
                catch (Exception)
                {
                    return new NetworkInfoData();
                }
            });
        }

        private NetworkInfoData GetNetworkInfo()
        {
            AddSnapshot();

            if (_snapshots.Count <= 1)
            {
                return new NetworkInfoData();
            }
            else
            {
                NetworkSnapshot start = _snapshots[0];
                NetworkSnapshot end = _snapshots[_snapshots.Count - 1];
                TimeSpan duration = end.At.Subtract(start.At);

                ulong rx = (ulong)Math.Ceiling((end.Rx - start.Rx) / duration.TotalSeconds);
                ulong tx = (ulong)Math.Ceiling((end.Tx - start.Tx) / duration.TotalSeconds);

                TrimSnapshots();

                return new NetworkInfoData() { RxPerSecond = rx, TxPerSecond = tx };
            }
        }

        private void AddSnapshot()
        {
            ulong _rx = 0;
            ulong _tx = 0;

            if (_nics == null)
            {
                _nics = NetworkInterface.GetAllNetworkInterfaces();
            }

            foreach (NetworkInterface ni in _nics)
            {
                var stats = ni.GetIPStatistics();
                _rx += (ulong)stats.BytesReceived;
                _tx += (ulong)stats.BytesSent;
            }

            NetworkSnapshot snapshot = new NetworkSnapshot()
            {
                At = DateTime.Now,
                Rx = _rx,
                Tx = _tx
            };

            _snapshots.Add(snapshot);
        }

        private void TrimSnapshots()
        {
            DateTime removeBefore = DateTime.Now.Subtract(Over);

            while (_snapshots.Count > 0 &&  _snapshots[0].At < removeBefore)
            {
                _snapshots.RemoveAt(0);
            }
        }

        public struct NetworkSnapshot
        {
            public DateTime At { get; set; }
            public ulong Rx { get; set; }
            public ulong Tx { get; set; }
        }
    }

    public struct NetworkInfoData
    {
        public ulong RxPerSecond { get; set; }
        public ulong TxPerSecond { get; set; }
    }
}
