using System;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using WinApi;

namespace SystemUsageBar
{
    public class PanelInstaller : IDisposable
    {
        private IntPtr _hTaskBar = IntPtr.Zero;
        private IntPtr _hTaskPanel = IntPtr.Zero;
        private IntPtr _hTrayPanel = IntPtr.Zero;
        private SystemUsagePanel _panel;
        private readonly Timer _timer;

        public PanelInstaller()
        {
            _timer = new Timer();
            _timer.Tick += new EventHandler(AlignTaskbar);
            _timer.Interval = 500;

            InstallPanel();
        }

        public void InstallPanel()
        {
            _hTaskBar = User32.FindWindow("Shell_TrayWnd", null);

            if (_hTaskBar == IntPtr.Zero)
            {
                return;
            }

            _hTaskPanel = User32.FindWindowEx(_hTaskBar, IntPtr.Zero, "ReBarWindow32", null);
            _hTrayPanel = User32.FindWindowEx(_hTaskBar, IntPtr.Zero, "TrayNotifyWnd", null);
            
            if (_panel == null)
            {
                _panel = new SystemUsagePanel();
                _panel.Resize += new EventHandler(AlignTaskbar);
                AlignTaskbar(null, null);
                User32.SetParent(_panel.Handle, _hTaskBar);
            }
            else
            {
                User32.SetParent(_panel.Handle, _hTaskBar);
                AlignTaskbar(null, null);
            }

            _timer.Enabled = true;
        }

        private void AlignTaskbar(object sender, EventArgs e)
        {
            IntPtr hCurrTaskbar = User32.FindWindow("Shell_TrayWnd", null);
            if (hCurrTaskbar == IntPtr.Zero || _hTaskBar != hCurrTaskbar)
            {
                _hTaskBar = IntPtr.Zero;
                _hTaskPanel = IntPtr.Zero;
                _hTrayPanel = IntPtr.Zero;
                InstallPanel();
                return;
            }

            Rectangle rectTaskPanel = User32.GetRelativeRect(_hTaskPanel, _hTaskBar);
            Rectangle rectTrayPanel = User32.GetRelativeRect(_hTrayPanel, _hTaskBar);
            bool styles_enabled = VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser;

            if (styles_enabled)
            {
                User32.MoveWindow(_hTaskPanel,
                    rectTaskPanel.Left,
                    0,
                    (rectTrayPanel.Left - _panel.Width) - rectTaskPanel.Left,
                    rectTaskPanel.Height,
                    true);
            }
            else
            {
                User32.MoveWindow(_hTaskPanel,
                    60,
                    0,
                    (rectTrayPanel.Left - _panel.Width - 5) - rectTaskPanel.Left,
                    rectTaskPanel.Height,
                    true);
            }

            rectTaskPanel = User32.GetRelativeRect(_hTaskPanel, _hTaskBar);

            _panel.SuspendLayout();
            _panel.Height = rectTaskPanel.Height;
            _panel.Left = rectTaskPanel.Right;
            _panel.ResumeLayout();

        }

        public void UninstallPanel()
        {
            _panel.Dispose();

            Rectangle rectTaskPanel = User32.GetRelativeRect(_hTaskPanel, _hTaskBar);
            Rectangle rectTrayPanel = User32.GetRelativeRect(_hTrayPanel, _hTaskBar);

            bool stylesEnabled = VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser;
            if (stylesEnabled)
            {
                User32.MoveWindow(_hTaskPanel,
                    rectTaskPanel.Left,
                    0,
                    rectTrayPanel.Left - rectTaskPanel.Left,
                    rectTaskPanel.Height,
                    true);
            }
            else
            {
                User32.MoveWindow(_hTaskPanel,
                    60,
                    0,
                    rectTrayPanel.Left - rectTaskPanel.Left,
                    rectTaskPanel.Height,
                    true);
            }

            _timer.Enabled = false;
        }

        public void Dispose()
        {
            if (_timer.Enabled)
            {
                UninstallPanel();
            }
        }
    }
}
