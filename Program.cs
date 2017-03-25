using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace SystemUsageBar
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ExitExistingProcess();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (PanelInstaller pi = new PanelInstaller())
            {
                pi.InstallPanel();

                Application.Run();
            }

            Settings.Current.Save();
        }

        private static void ExitExistingProcess()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
            foreach (Process pr in processes)
            {
                if (currentProcess.Id != pr.Id &&
                    pr.MainModule.FileName == currentProcess.MainModule.FileName)
                {
                    pr.Kill();
                }
            }
        }
    }
}