using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    public partial class FormBackup : Form, IMainFormDependent
    {
        public string menuTitle = trans.Me("Backups");
        public FormMain MainFormReference { get; set; }

        private System.Windows.Forms.Timer tooltipTimer;
        private Point tooltipLocation;
        private string tooltipText;

        public FormBackup()
        {
            InitializeComponent();
            HelperFunctions.GetOBSStudioInstallationPath();
            gridBackup.Columns["Backup"].DefaultCellStyle.NullValue = trans.Me("Backup"); // Set the start button text
            gridBackup.Columns["Restore"].DefaultCellStyle.NullValue = trans.Me("Restore"); // Set the start button text
            LoadObsVersions();

            gridBackup.CellMouseEnter += gridBackup_CellMouseEnter;

            // Initialize the timer and set the interval to 1000 milliseconds (1 second)
            tooltipTimer = new System.Windows.Forms.Timer();
            tooltipTimer.Interval = 1000;

            tooltipTimer.Tick += (s, e) =>
            {
                // Show the tooltip and stop the timer
                ttCellPath.Show(tooltipText, this, this.PointToClient(tooltipLocation), 3000); // Display for 3 seconds
                tooltipTimer.Stop();
            };

            trans.UpdateAllControlTexts(this.Controls);
        }

        private async void gridBackup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                var obsVersion = (ObsVersionInfo)gridBackup.Rows[e.RowIndex].Tag;
                string obsPath = HelperFunctions.pathToDrivePath(obsVersion);
                // Check if the process is already running
                if (GlobalState.ObsProcesses.TryGetValue(obsVersion.FolderName, out var existingProcess) && HelperFunctions.IsProcessRunning(existingProcess.Id))
                {
                    MessageBox.Show(trans.Me("backupOBSstillRunning"));
                    return;
                }
                // Backup
                // Disable input
                gridBackup.Enabled = false;

                var backupPaths = new Dictionary<string, string>();

                DateTime now = DateTime.Now;
                string dateTimeString = now.ToString("yyyyMMdd_HHmm");

                string backupZipPath = AppDomain.CurrentDomain.BaseDirectory + @"backups\" + obsVersion.FolderName + @"\";
                string backupZipName = "backup_" + dateTimeString;
                string backupZipExt = ".zip";

                if (!Convert.ToBoolean(gridBackup.Rows[e.RowIndex].Cells[2].Value) && !Convert.ToBoolean(gridBackup.Rows[e.RowIndex].Cells[3].Value))
                {
                    UsrMsg.Show("backupNeeds", MessageType.Warning);
                    return;
                }

                if (Convert.ToBoolean(gridBackup.Rows[e.RowIndex].Cells[2].Value))
                {
                    // include OBS profile
                    backupPaths.Add(obsVersion.ObsConfigPath, obsVersion.FolderName + @"\config");
                    backupZipName += "_config";
                }

                if (Convert.ToBoolean(gridBackup.Rows[e.RowIndex].Cells[3].Value))
                {
                    // include OBS binary and plugins
                    backupPaths.Add(obsVersion.RootPath + @"\bin", obsVersion.FolderName + @"\bin");
                    backupPaths.Add(obsVersion.RootPath + @"\data", obsVersion.FolderName + @"\data");
                    backupPaths.Add(obsVersion.RootPath + @"\obs-plugins", obsVersion.FolderName + @"\obs-plugins");
                    backupZipName += "_bin_plugins";
                }

                if (!Directory.Exists(backupZipPath)) {
                    Directory.CreateDirectory(backupZipPath);
                }
                // Create a CancellationTokenSource
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                // For download progress
                var downloadProgress = new Progress<DownloadProgressInfo>(progressInfo =>
                {
                    progressBarZip.Value = (int)progressInfo.ProgressPercentage;
                    progressBarZip.CustomText = $"{progressInfo.OperationType} {progressInfo.ProgressPercentage:0.00}% | {trans.Me("Remaining")}: {progressInfo.TimeRemaining.TotalSeconds}s";
                });

                progressBarZip.FillColor = Color.Blue;
                progressBarZip.Show();

                // Call the function
                var result = await HelperFunctions.CreateZipWithMultipleFoldersAsync(backupPaths, backupZipPath + backupZipName + backupZipExt, cancellationTokenSource.Token, downloadProgress);

                if (result.Item1)
                {
                    // Success
                    UsrMsg.Show("backupSuccessHint", MessageType.Info, null, backupZipName + backupZipExt);
                }
                else
                {
                    // Failure, handle the error
                    UsrMsg.Show("backupErrorHint", MessageType.Error, result.Item2);
                }
                HelperFunctions.resetProgressBar(progressBarZip);
                gridBackup.Enabled = true;
            }
            else if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                // Restore
                UsrMsg.Show("notImplementedYet", MessageType.Warning);
            }
        }

        private void LoadObsVersions()
        {
            var obsVersions = HelperFunctions.FindObsVersions();

            // Find existing rows and update them
            foreach (var version in obsVersions)
            {
                if (Directory.Exists(version.ObsConfigPath)) 
                {
                    // OBS version Has a config subfolder
                    var existingRow = gridBackup.Rows.Cast<DataGridViewRow>().FirstOrDefault(row => row.Tag != null && ((ObsVersionInfo)row.Tag).FolderName == version.FolderName);

                    if (existingRow != null)
                    {
                        existingRow.Tag = version;
                        existingRow.Cells["OBSversion"].Value = version.ObsVersion;
                    }
                    else
                    {
                        // Add a new row for a new OBS version
                        int rowIndex = gridBackup.Rows.Add(version.FolderName, version.ObsVersion, true, null, null, null);
                        gridBackup.Rows[rowIndex].Tag = version;
                    }
                }
            }
        }

        private void gridBackup_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the mouse is over a valid cell
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex >= gridBackup.RowCount)
            {
                tooltipTimer.Stop();
                ttCellPath.Hide(this);
                return;
            }

            // Reset the tooltip text and location
            tooltipText = string.Empty;

            // Stop the timer if it's already running
            tooltipTimer.Stop();

            // Get the cell
            DataGridViewCell cell = gridBackup.Rows[e.RowIndex].Cells[e.ColumnIndex];

            // Get the cell's screen coordinates
            Rectangle cellRect = gridBackup.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            tooltipLocation = gridBackup.PointToScreen(new Point(cellRect.X, cellRect.Y + cellRect.Height)); // Add cell height to Y-coordinate
            var obsVersion = (ObsVersionInfo)gridBackup.Rows[e.RowIndex].Tag;

            switch (e.ColumnIndex)
            {
                case 0:
                    tooltipText = trans.Me("Path to OBS version") + ": " + obsVersion.RootPath;
                    break;
                case 1:
                    ttCellPath.Hide(this);
                    return;
                case 2:
                    tooltipText = trans.Me("backupOBSprofileHint");
                    break;
                case 3:
                    tooltipText = trans.Me("backupOBSbinariesHint");
                    break;
                case 4:
                    ttCellPath.Hide(this);
                    return;
                case 5:
                    ttCellPath.Hide(this);
                    return;
                default:
                    ttCellPath.Hide(this);
                    return;
            }

            // Start the timer
            tooltipTimer.Start();
        }

        private void gridBackup_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Stop the timer and clear the tooltip when the mouse leaves the cell
            tooltipTimer.Stop();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < gridBackup.RowCount)
            {
                DataGridViewCell cell = gridBackup.Rows[e.RowIndex].Cells[e.ColumnIndex];
                SetCellToolTip(cell, "");
            }
        }

        private void SetCellToolTip(DataGridViewCell cell, string tooltipText)
        {
            if (cell != null)
            {
                cell.ToolTipText = tooltipText;
            }
        }

        private void gridBackup_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Make sure the clicked cell is valid
            {
                DataGridViewCell cell = gridBackup.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    bool currentValue = Convert.ToBoolean(cell.Value);
                    cell.Value = !currentValue;

                    // Use EndEdit to commit the change made by the user
                    gridBackup.EndEdit();
                }
            }
        }
    }
}
