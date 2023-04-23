using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    public partial class FormBackup : Form
    {
        public string menuTitle = "Backups";
        public FormMain MainFormReference { get; set; }

        public FormBackup()
        {
            InitializeComponent();
            HelperFunctions.GetOBSStudioInstallationPath();
            gridBackup.Columns["Backup"].DefaultCellStyle.NullValue = "Backup"; // Set the start button text
            gridBackup.Columns["Restore"].DefaultCellStyle.NullValue = "Restore"; // Set the start button text
            LoadObsVersions();

            gridBackup.CellMouseEnter += gridBackup_CellMouseEnter;

        }

        private async void gridBackup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var obsVersion = (ObsVersionInfo)gridBackup.Rows[e.RowIndex].Tag;
            string obsPath = HelperFunctions.pathToDrivePath(obsVersion.ObsExePath);
            // Check if the process is already running
            if (GlobalState.ObsProcesses.TryGetValue(e.RowIndex, out var existingProcess) && HelperFunctions.IsProcessRunning(existingProcess.Id))
            {
                MessageBox.Show("This OBS version is still running.");
                return;
            }

            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                // Backup
                var backupPaths = new Dictionary<string, string>();

                DateTime now = DateTime.Now;
                string dateTimeString = now.ToString("yyyyMMdd_HHmm");

                string backupZipPath = AppDomain.CurrentDomain.BaseDirectory + @"backups\" + obsVersion.FolderName + @"\";
                string backupZipName = "backup_" + dateTimeString;
                string backupZipExt = ".zip";

                if (!Convert.ToBoolean(gridBackup.Rows[e.RowIndex].Cells[2].Value) && !Convert.ToBoolean(gridBackup.Rows[e.RowIndex].Cells[3].Value))
                {
                    UsrMsg.Show("You need to select at least one item to be included in the Backup!", MessageType.Warning);
                    return;
                }

                if (Convert.ToBoolean(gridBackup.Rows[e.RowIndex].Cells[2].Value))
                {
                    // include OBS profile
                    backupPaths.Add(obsVersion.RootPath + @"\config", obsVersion.FolderName + @"\config");
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
                    progressBarZip.CustomText = $"{progressInfo.OperationType} {progressInfo.ProgressPercentage:0.00}% | Remaining: {progressInfo.TimeRemaining.TotalSeconds}s";
                });

                progressBarZip.FillColor = Color.Blue;
                progressBarZip.Show();

                // Call the function
                var result = await HelperFunctions.CreateZipWithMultipleFoldersAsync(backupPaths, backupZipPath + backupZipName + backupZipExt, cancellationTokenSource.Token, downloadProgress);

                if (result.Item1)
                {
                    // Success
                    UsrMsg.Show("Backup " + backupZipName + backupZipExt + " sucessfully created.", MessageType.Default);
                }
                else
                {
                    // Failure, handle the error
                    UsrMsg.Show("Backup could not be created. Error: " + result.Item2, MessageType.Error);
                }
                HelperFunctions.resetProgressBar(progressBarZip);
            }
            else if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                // Restore
            }
        }


        private void LoadObsVersions()
        {
            var obsVersions = HelperFunctions.FindObsVersions();

            // Find existing rows and update them
            foreach (var version in obsVersions)
            {
                if (Directory.Exists(version.RootPath + @"\config\obs-studio")) 
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
                ttCellPath.Hide(this);
                return;
            }

            if (e.ColumnIndex == 0)
            {
                // Get the cell
                DataGridViewCell cell = gridBackup.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Get the cell's screen coordinates
                Rectangle cellRect = gridBackup.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point tooltipLocation = gridBackup.PointToScreen(new Point(cellRect.X, cellRect.Y + cellRect.Height)); // Add cell height to Y-coordinate

                var obsVersion = (ObsVersionInfo)gridBackup.Rows[e.RowIndex].Tag;
                // Set the tooltip text and show it
                ttCellPath.Show("Path to OBS version: " + obsVersion.RootPath, this, this.PointToClient(tooltipLocation), 3000); // Display for 3 seconds
            }
            else
            {
                // Hide the tooltip if the mouse is not over the desired cell
                ttCellPath.Hide(this);
            }
        }


    }
}
