using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using WinApi.Structures;

namespace WinApi
{
    public static class User32
    {
        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string className, string windowName);

        public static IntPtr FindWindowByCaption(string windowName)
        {
            return FindWindow(null, windowName);
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT rect);

        public static Rectangle GetRelativeRect(IntPtr hWndChild, IntPtr hWndParent)
        {
            RECT child = new RECT();
            GetWindowRect(hWndChild, out child);

            RECT parent = new RECT();
            GetWindowRect(hWndParent, out parent);

            return new RECT(child.Left - parent.Left, child.Top - parent.Top, child.Right - parent.Left, child.Bottom - parent.Top);
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, string lpString, int cch);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        public static string GetWindowText(IntPtr hWnd)
        {
            int len = GetWindowTextLength(hWnd);

            if (len <= 0)
                return string.Empty;

            string text = new string((char)0, len+1);
            int retLength = GetWindowText(hWnd, text, len+1);

            if (retLength > text.Length) return string.Empty;

            return text.Substring(0, retLength);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessageA(IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
