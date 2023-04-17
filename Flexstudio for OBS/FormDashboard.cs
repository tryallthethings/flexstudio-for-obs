using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    public partial class FormDashboard : Form
    {
        public string menuTitle = "Dashboard";
        public List<char> driveAvail = new List<char>();
        public FormMain MainFormReference { get; set; }

        public FormDashboard()
        {
            InitializeComponent();
            RefreshDrives();
            if (!FormMain.isMapped)
            {
                CanMapDrive();
                btnStartOBS.Enabled = false;
                try
                {
                    // Drive letter is available
                    if (bool.Parse(sett.ing["autoMapDefaultDrive"]) && CanMapDrive())
                    {
                        // Default mapping enabled - let's do it
                        MapDrive();
                    }
                    else
                    {
                        // Default mapping not enabled or no valid drive letter set / found - skipping
                    }
                }
                catch (Exception ex)
                {
                    UsrMsg.Show("Invalid setting for parameter 'autoMapDefaultDrive' detected. Error: " + ex.ToString(), MessageType.Error);
                }
            } 
            else
            {
                btnMapDrive.Text = "Remove drive";
                LbldefaultDrive.Text = sett.ing["defaultDrive"];
                btnStartOBS.Enabled = true;
            }

            if (sett.ing.HasKeyWithValue("DefaultOBSversion"))
            {
                lblDefaultOBS.Text = sett.ing["DefaultOBSversion"];
            }
            else
            {
                lblDefaultOBS.Text = "not set";
            }
            AutoScaleDimensions = new SizeF(96F, 96F);
        }

        // Function to map the default drive
        private void MapDrive()
        {
            driveMapResponse output = HelperFunctions.CreateSubstDrive(char.Parse(sett.ing["defaultDrive"]), AppDomain.CurrentDomain.BaseDirectory);
            if (!output.success)
            {
                UsrMsg.Show(output.Message + ": " + output.Error, MessageType.Error);
            }
            else
            {
                UsrMsg.Show(output.Message + ": " + output.Error, MessageType.Info);
                FormMain.isMapped = true;
                btnStartOBS.Enabled = true;
            }
        }

        // Function to remove the default drive
        private void RemoveDrive()
        {
            driveMapResponse output = HelperFunctions.RemoveSubstDrive(char.Parse(sett.ing["defaultDrive"]));
            if (!output.success)
            {
                UsrMsg.Show(output.Message + ": " + output.Error, MessageType.Error);
            }
            else
            {
                UsrMsg.Show(output.Message + ": " + output.Error, MessageType.Info);
                FormMain.isMapped = false;
                btnStartOBS.Enabled = false;
            }
        }

        // Check, if a default drive is selected and can be mapped
        private bool CanMapDrive()
        {
            if (!sett.ing.HasKeyWithValue("defaultDrive"))
            {
                // no default drive set.
                UsrMsg.Show("No default drive letter is set. Please check settings", MessageType.Warning);
                LbldefaultDrive.Text = "";
                return false;
            }
            else
            {
                // check if we still have an active subst drive and remove it
                if (HelperFunctions.IsSubstDrive(char.Parse(sett.ing["defaultDrive"])))
                {
                    RemoveDrive();
                    UsrMsg.Show("Removed mapped drive " + sett.ing["defaultDrive"].ToUpper() + ":", MessageType.Warning);
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
                        LbldefaultDrive.Text = sett.ing["defaultDrive"];
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
            driveAvail = FormSettings.getAvailableDriveLetters(FormMain.isMapped);
        }

        private void btnMapDrive_Click(object sender, EventArgs e)
        {
            if (FormMain.isMapped)
            {
                RemoveDrive();
                btnMapDrive.Text = "Map default drive";
            }
            else
            {
                if (CanMapDrive())
                {
                    MapDrive();
                    btnMapDrive.Text = "Remove drive";
                }
            }
        }

        private void btnStartOBS_Click(object sender, EventArgs e)
        {
            /*
            if (GlobalState.ObsProcesses.TryGetValue(e.RowIndex, out var existingProcess) && IsProcessRunning(existingProcess.Id))
            {
                MessageBox.Show("This OBS version is already running.");
                return;
            }*/

            if (sett.ing.HasKeyWithValue("DefaultOBSpath"))
            {
                string obsPath = HelperFunctions.pathToDrivePath(sett.ing["DefaultOBSpath"]);
                var startInfo = new ProcessStartInfo
                {
                    FileName = obsPath,
                    WorkingDirectory = Path.GetDirectoryName(obsPath),
                    UseShellExecute = false,
                    Arguments = "--portable"
                };

                var process = Process.Start(startInfo);
                process.EnableRaisingEvents = true;
                //process.Exited += (senderObj, eArgs) => MainFormReference.Process_Exited(senderObj, gridOBSversions);
                //GlobalState.ObsProcesses[e.RowIndex] = process;

                // Save the process ID to a file
                HelperFunctions.SavePidToFile(obsPath, process.Id.ToString());

            }
            else
            {
                UsrMsg.Show("You didn't select a default OBS version yet. Please do it in the OBS versions menu.", MessageType.Error);
            }
        }
    }
}
