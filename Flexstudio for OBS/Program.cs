using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_SHOWNORMAL = 1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appName = Application.ProductName;
            string appVersion = Application.ProductVersion;
            string mutexName = appName + "_" + appVersion;

            // Declare the Mutex and check if another instance is already running.
            using (Mutex mutex = new Mutex(false, mutexName, out bool isNewInstance))
            {
                if (isNewInstance)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                }
                else
                {
                    // Get the process of the running instance
                    Process currentProcess = Process.GetCurrentProcess();
                    var runningProcess = Process.GetProcessesByName(currentProcess.ProcessName).FirstOrDefault(p => p.Id != currentProcess.Id);

                    if (runningProcess != null)
                    {
                        // Show the existing application instance
                        bool foregroundResult = SetForegroundWindow(runningProcess.MainWindowHandle);

                        // If SetForegroundWindow failed, try alternative methods
                        if (!foregroundResult)
                        {
                            ShowWindow(runningProcess.MainWindowHandle, SW_SHOWNORMAL);
                            foregroundResult = BringWindowToTop(runningProcess.MainWindowHandle);
                        }

                        // Ask user if they want to terminate the running instance if all attempts failed
                        if (!foregroundResult)
                        {
                            DialogResult dialogResult = MessageBox.Show("Another instance of the application is already running, but cannot be brought to the foreground. Do you want to terminate it and start a new instance?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dialogResult == DialogResult.Yes)
                            {
                                runningProcess.Kill();
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new FormMain());
                            }
                        }
                    }
                    else
                    {
                        // Show an error message if you prefer
                        MessageBox.Show("Another instance of the application is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
