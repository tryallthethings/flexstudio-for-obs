using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    public partial class FormDashboard : Form, IMainFormDependent
    {
        public string menuTitle = "Dashboard";
        public FormMain MainFormReference { get; set; }
        public List<char> driveAvail = new List<char>();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_SHOWNORMAL = 1;

        public FormDashboard()
        {
            InitializeComponent();
            UsrMsg.Reset();
            RefreshDrives();
            trans.UpdateAllControlTexts(this.Controls);

            if (sett.ing.HasKeyWithValue("defaultDrive"))
                sett.ing.DriveIsMapped = HelperFunctions.CheckSubstDrive(char.Parse(sett.ing["defaultDrive"]));

            if (!sett.ing.DriveIsMapped)
            {
                CanMapDrive();
                btnStartOBS.Enabled = false;
                try
                {
                    // Drive letter is available
                    if (bool.Parse(sett.ing["autoMapDefaultDrive"]) && CanMapDrive() && sett.ing.isFirstStart)
                    {
                        // Default mapping enabled - let's do it
                        MapDrive();
                        if (sett.ing.HasKeyWithValue("autoStartDefaultOBS"))
                        {
                            if (bool.Parse(sett.ing["autoStartDefaultOBS"]))
                            {
                                btnStartOBS_Click(null, null);
                                sett.ing.isFirstStart = false;
                            }
                        }
                    }
                    else
                    {
                        // Default mapping not enabled or no valid drive letter set / found - skipping
                    }
                }
                catch (Exception ex)
                {
                    UsrMsg.Show("dashboardInvalidSettingHint", MessageType.Error, ex.ToString());
                }
            }
            else
            {
                btnMapDrive.Text = trans.Me("Remove drive");
                lblDefaultDriveDashboard.Text = sett.ing["defaultDrive"] + @":\";
                btnStartOBS.Enabled = true;
            }

            if (sett.ing.HasKeyWithValue("DefaultOBSversion"))
            {
                if (Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sett.ing["DefaultOBSversion"])))
                {
                    lblDefaultOBS.Text = sett.ing["DefaultOBSversion"];

                    // Default OBS version set. Let's check, if it's already running
                    var obsVersion = HelperFunctions.FindObsVersionInPath(sett.ing["DefaultOBSpath"]);
                    Process proc = HelperFunctions.OBSrunningForFolder(obsVersion);
                    if (proc != null)
                    {
                        lock (GlobalState.ObsProcessesLock)
                        {
                            if (!GlobalState.ObsProcesses.ContainsKey(obsVersion.FolderName))
                            {
                                proc.Exited += (senderObj, eArgs) => MainFormReference.Process_Exited(senderObj, null, obsVersion.FolderName);
                                GlobalState.ObsProcesses[obsVersion.FolderName] = proc;
                            }
                        }
                    }
                }
                else
                {
                    UsrMsg.Show("defaultOBSversionRemoved", MessageType.Error);
                    sett.ing["DefaultOBSversion"] = "";
                    lblDefaultOBS.Text = trans.Me("dashboardOBSdefaultVersionNotSetHint");
                }
            }
            else
            {
                lblDefaultOBS.Text = trans.Me("dashboardOBSdefaultVersionNotSetHint");
            }

        }

        // Function to map the default drive
        private void MapDrive()
        {
            driveMapResponse output = HelperFunctions.CreateSubstDrive(char.Parse(sett.ing["defaultDrive"]), AppDomain.CurrentDomain.BaseDirectory);
            if (!output.success)
            {
                UsrMsg.Show(output.Message, MessageType.Error, output.Error);
            }
            else
            {
                UsrMsg.Show(output.Message, MessageType.Info, output.Error);
                sett.ing.DriveIsMapped = true;
                btnStartOBS.Enabled = true;
            }
        }

        // Function to remove the default drive
        private void RemoveDrive()
        {
            driveMapResponse output = HelperFunctions.RemoveSubstDrive(char.Parse(sett.ing["defaultDrive"]));
            if (!output.success)
            {
                UsrMsg.Show(output.Message, MessageType.Error, output.Error);
            }
            else
            {
                UsrMsg.Show(output.Message, MessageType.Info, output.Error);
                sett.ing.DriveIsMapped = false;
                btnStartOBS.Enabled = false;
            }
        }

        // Check, if a default drive is selected and can be mapped
        private bool CanMapDrive()
        {
            if (!sett.ing.HasKeyWithValue("defaultDrive"))
            {
                // no default drive set.
                UsrMsg.Show("NoDefaultDriveSet", MessageType.Warning);
                lblDefaultDriveDashboard.Text = "";
                return false;
            }
            else
            {
                // check if we still have an active subst drive and remove it
                if (HelperFunctions.IsSubstDrive(char.Parse(sett.ing["defaultDrive"])))
                {
                    RemoveDrive();
                    UsrMsg.Show("dashboardRemovedMappedDriveSuccess", MessageType.Warning, null, sett.ing["defaultDrive"].ToUpper());
                }
                else
                {
                    UsrMsg.Reset();
                }
                
                RefreshDrives();

                try
                {
                    if (driveAvail.Contains(char.Parse(sett.ing["defaultDrive"])))
                    {
                        lblDefaultDriveDashboard.Text = sett.ing["defaultDrive"];
                        return true;
                    }
                    else
                    {
                        UsrMsg.Show("Drive with the letter " + sett.ing["defaultDrive"].ToUpper() + " is not available. Please check.", MessageType.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    UsrMsg.Show("Invalid setting for parameter 'defaultDrive' detected. Error: " + ex.ToString(), MessageType.Error);
                    return false;
                }
            }
        }

        // Refresh available drive letters
        private void RefreshDrives()
        {
            driveAvail = FormSettings.getAvailableDriveLetters(sett.ing.DriveIsMapped);
        }

        private void btnMapDrive_Click(object sender, EventArgs e)
        {
            if (sett.ing.DriveIsMapped)
            {
                if (GlobalState.ObsProcesses.Count > 0)
                {
                    UsrMsg.Show("obsStillRunning", MessageType.Error);
                }
                else
                {
                    RemoveDrive();
                    btnMapDrive.Text = trans.Me("Map default drive");
                }
            }
            else
            {
                if (CanMapDrive())
                {
                    MapDrive();
                    btnMapDrive.Text = trans.Me("Remove drive");
                }
            }
        }

        private void btnStartOBS_Click(object sender, EventArgs e)
        {
            if (sett.ing.HasKeyWithValue("DefaultOBSpath"))
            {
                var obsVersion = HelperFunctions.FindObsVersionInPath(sett.ing["DefaultOBSpath"]);
                string obsPath = "";

                if (obsVersion.isLocal)
                {
                    // Local OBS version
                    obsPath = sett.ing["DefaultOBSpath"];
                }
                else
                {
                    obsPath = HelperFunctions.pathToDrivePath(sett.ing["DefaultOBSpath"]);
                }

                if (GlobalState.ObsProcesses.TryGetValue(obsVersion.FolderName, out var existingProcess) && HelperFunctions.IsProcessRunning(existingProcess.Id))
                {
                    // Check if the process is already running
                    if (existingProcess != null)
                    {
                        // Try to bring the window to the foreground
                        bool foregroundResult = SetForegroundWindow(existingProcess.MainWindowHandle);

                        // If SetForegroundWindow failed, try alternative methods
                        if (!foregroundResult)
                        {
                            ShowWindow(existingProcess.MainWindowHandle, SW_SHOWNORMAL);
                            foregroundResult = BringWindowToTop(existingProcess.MainWindowHandle);
                        }

                        // If all attempts failed, ask the user to terminate the process and start a new one
                        if (!foregroundResult)
                        {
                            DialogResult dialogResult = MessageBox.Show(trans.Me("dashboardUnresponsiveOBSinstanceWarning"), trans.Me("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dialogResult == DialogResult.Yes)
                            {
                                existingProcess.Kill();
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            UsrMsg.Show("OBSversionAlreadyRunning", MessageType.Info);
                            return;
                        }
                    }
                } 
                else
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = obsPath,
                        WorkingDirectory = Path.GetDirectoryName(obsPath),
                        UseShellExecute = false,
                        Arguments = !obsVersion.isLocal ? "--portable" : string.Empty
                    };

                    var process = Process.Start(startInfo);
                    process.EnableRaisingEvents = true;
                    process.Exited += (senderObj, eArgs) => MainFormReference.Process_Exited(senderObj, null, obsVersion.FolderName);
                    lock (GlobalState.ObsProcessesLock)
                    {
                        GlobalState.ObsProcesses[obsVersion.FolderName] = process;
                    }

                    // Save the process ID to a file
                    if (!obsVersion.isLocal)
                        HelperFunctions.SavePidToFile(obsPath, process.Id.ToString());
                }
            }
            else
            {
                UsrMsg.Show("dashboardNoDefaultOBSerror", MessageType.Error);
            }
        }

        private void gitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/tryallthethings/flexstudio-for-obs");
        }
    }
}
