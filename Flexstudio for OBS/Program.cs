using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Flexstudio_for_OBS.Logging;

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
            try
            {
                string appName = Application.ProductName;
                string appVersion = Application.ProductVersion;
                string mutexName = appName + "_" + appVersion;

                ConfigureNLog();

                // Declare the Mutex and check if another instance is already running.
                using (Mutex mutex = new Mutex(false, mutexName, out bool isNewInstance))
                {
                    if (isNewInstance)
                    {
                        if (sett.ing.isDebug)
                            Log.Debug("Application " + mutexName + " starting");
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
                            if (sett.ing.isDebug)
                                Log.Debug("Existing instance of " + mutexName + " found. Trying to bring to foreground.");

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
                                if (sett.ing.isDebug)
                                    Log.Debug("Bringing to foreground failed.");

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
            catch (Exception ex)
            {
                Log.Error(ex, "Unhandled exception occurred.");
                throw; 
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static void SetApplicationCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
