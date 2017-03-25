using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ComTypes = System.Runtime.InteropServices.ComTypes;

namespace WinApi
{
    public static class Kernal32
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetSystemTimes(
                    out ComTypes.FILETIME idleTime,
                    out ComTypes.FILETIME kernelTime,
                    out ComTypes.FILETIME userTime
                    );

        public static DateTime FiletimeToDateTime(ComTypes.FILETIME fileTime)
        {
            long hFT2 = (((long)fileTime.dwHighDateTime) << 32) | ((uint)fileTime.dwLowDateTime);
            return DateTime.FromFileTimeUtc(hFT2);
        }

        public static ComTypes.FILETIME DateTimeToFiletime(DateTime time)
        {
            ComTypes.FILETIME ft;
            long hFT1 = time.ToFileTimeUtc();
            ft.dwLowDateTime = (int)(hFT1 & 0xFFFFFFFF);
            ft.dwHighDateTime = (int)(hFT1 >> 32);
            return ft;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GlobalMemoryStatusEx([In, Out] Structures.MemoryStatusEx status);
    }
}
