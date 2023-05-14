using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    public partial class FormOBSversions : Form, IMainFormDependent
    {
        public string menuTitle = trans.Me("OBS versions");
        public FormMain MainFormReference { get; set; }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_SHOWNORMAL = 1;

        public FormOBSversions()
        {
            InitializeComponent();

            gridOBSversions.Columns["StartOBS"].DefaultCellStyle.NullValue = trans.Me("StartOBS"); // Set the start button text
            gridOBSversions.Columns["Default"].DefaultCellStyle.NullValue = null; // Set the start button text
            LoadObsVersions();

            trans.UpdateAllControlTexts(this.Controls);

            refreshBtn.TextChanged += HelperFunctions.Button_TextChanged;
            addNewOBSbtn.TextChanged += HelperFunctions.Button_TextChanged;
            Shown += (sender, args) => {
                for (int rowIndex = 0; rowIndex < gridOBSversions.Rows.Count; rowIndex++)
                {
                    LoadRunningProcessesForRow(rowIndex);
                }
            };
        }

        private void LoadObsVersions()
        {
            var obsVersions = HelperFunctions.FindObsVersions();

            // Find existing rows and update them
            foreach (var version in obsVersions)
            {
                var existingRow = gridOBSversions.Rows.Cast<DataGridViewRow>().FirstOrDefault(row => ((ObsVersionInfo)row.Tag).FolderName == version.FolderName);

                if (existingRow != null)
                {
                    existingRow.Tag = version;
                    existingRow.Cells["OBSversion"].Value = version.ObsVersion;
                }
                else
                {
                    // Add a new row for a new OBS version
                    int rowIndex = gridOBSversions.Rows.Add(null, null, version.FolderName, version.ObsVersion, null);
                    gridOBSversions.Rows[rowIndex].Tag = version;
                    gridOBSversions.Rows[rowIndex].Cells["runningImage"].Value = Properties.Resources.redicon;

                    // Check if a new process is running
                    //LoadRunningProcessesForRow(rowIndex);

                    // Set checkmark for default OBS version if set
                    if (sett.ing.HasKeyWithValue("DefaultOBSpath"))
                    {
                        setDefaultIcon();
                    }
                }
            }

            // Remove rows for deleted OBS versions
            for (int i = gridOBSversions.Rows.Count - 1; i >= 0; i--)
            {
                var row = gridOBSversions.Rows[i];
                if (!obsVersions.Any(version => version.FolderName == ((ObsVersionInfo)row.Tag).FolderName))
                {
                    gridOBSversions.Rows.RemoveAt(i);
                    GlobalState.ObsProcesses.Remove(((ObsVersionInfo)row.Tag).FolderName);
                }
            }
        }

        private void gridOBSversions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) // Start button column
            {
                var obsVersion = (ObsVersionInfo)gridOBSversions.Rows[e.RowIndex].Tag;
                string obsPath = HelperFunctions.pathToDrivePath(obsVersion);

                // Check if the process is already running
                if (GlobalState.ObsProcesses.TryGetValue(obsVersion.FolderName, out var existingProcess) && HelperFunctions.IsProcessRunning(existingProcess.Id))
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
                        DialogResult dialogResult = MessageBox.Show(trans.Me("obsVersionRunningForegroundErrorHint"), trans.Me("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

                var startInfo = new ProcessStartInfo
                {
                    FileName = obsPath,
                    WorkingDirectory = Path.GetDirectoryName(obsPath),
                    UseShellExecute = false,
                    Arguments = !obsVersion.isLocal ? "--portable" : string.Empty
                };

                var process = Process.Start(startInfo);
                process.EnableRaisingEvents = true;
                process.Exited += (senderObj, eArgs) => MainFormReference.Process_Exited(senderObj, gridOBSversions, obsVersion.FolderName);
                lock (GlobalState.ObsProcessesLock)
                {
                    GlobalState.ObsProcesses[obsVersion.FolderName] = process;
                }

                // Save the process ID to a file
                SavePidToFile(e.RowIndex, process.Id);

                // Set the green icon when starting a process
                MainFormReference.SetProcessStatusIcon(gridOBSversions, e.RowIndex, true);
            }
        }

        private void gridOBSversions_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridOBSversions.ClearSelection();
                gridOBSversions.Rows[e.RowIndex].Selected = true;
                contextGridOBSversions.Show(Cursor.Position);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridOBSversions.SelectedRows.Count > 0)
            {
                var obsVersion = (ObsVersionInfo)gridOBSversions.SelectedRows[0].Tag;
                // Perform update for the selected version
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridOBSversions.SelectedRows.Count > 0)
            {
                var obsVersion = (ObsVersionInfo)gridOBSversions.SelectedRows[0].Tag;
                if (obsVersion.isLocal)
                {
                    UsrMsg.Show("obsVersionLocalDeleteHint", MessageType.Error);
                    return;
                }
                
                // Check if the selected OBS version is running
                if (GlobalState.ObsProcesses.TryGetValue(obsVersion.FolderName, out var runningProcess) && HelperFunctions.IsProcessRunning(runningProcess.Id))
                {
                    UsrMsg.Show("obsVersionRunningDeleteHint", MessageType.Error);
                    return;
                }

                // Ask user for confirmation to delete OBS version
                if (MessageBox.Show(trans.Me("obsVersionConfirmDelete"), trans.Me("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                    return;
                }

                try
                {
                    Directory.Delete(obsVersion.RootPath, true);
                    gridOBSversions.Rows.Remove(gridOBSversions.SelectedRows[0]);
                    UsrMsg.Show("obsVersionSuccessDeleteHint", MessageType.Info);
                    if(obsVersion.isDefault)
                    {
                        sett.ing["DefaultOBSpath"] = "";
                        sett.ing["DefaultOBSversion"] = "";
                    }
                }
                catch (IOException ex)
                {
                    UsrMsg.Show("obsVersionErrorDeleteHint", MessageType.Error, ex.ToString());
                }
            }
        }

        private System.Drawing.Image GetResizedImage(System.Drawing.Image original, int width, int height)
        {
            var resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.DrawImage(original, 0, 0, width, height);
            }
            return resized;
        }

        public void UpdateProcessStatusIcons()
        {
            foreach (DataGridViewRow row in gridOBSversions.Rows)
            {
                var obsVersion = (ObsVersionInfo)row.Tag;
                if (GlobalState.ObsProcesses.TryGetValue(obsVersion.FolderName, out var process))
                {
                    MainFormReference.SetProcessStatusIcon(gridOBSversions, row.Index, process != null && !process.HasExited);
                }
                else
                {
                    MainFormReference.SetProcessStatusIcon(gridOBSversions, row.Index, false);
                }
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible)
            {
                UpdateProcessStatusIcons();
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var obsVersion = (ObsVersionInfo)gridOBSversions.SelectedRows[0].Tag;
            Process.Start(obsVersion.RootPath);
        }

        private async void addNewOBSbtn_Click(object sender, EventArgs e)
        {
            try
            {
                var releases = await OBSUpdates.FetchLastReleasesAsync(20);
                if (releases.Count == 0)
                {
                    UsrMsg.Show("obsVersionNoConnectionError", MessageType.Error);
                }
                else
                {
                    var downloadObsVersionForm = new DownloadObsVersionForm(releases);
                    downloadObsVersionForm.ShowDialog();
                    LoadObsVersions();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, trans.Me("Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadObsVersions();
        }

        private void SavePidToFile(int rowIndex, int processId)
        {
            var obsVersion = (ObsVersionInfo)gridOBSversions.Rows[rowIndex].Tag;
            if (!obsVersion.isLocal)
            {
                var pidFilePath = Path.Combine(Path.GetDirectoryName(obsVersion.ObsExePath), "obs_pid.txt");

                File.WriteAllText(pidFilePath, processId.ToString());
            }
        }

        private void LoadRunningProcessesForRow(int rowIndex)
        {
            var row = gridOBSversions.Rows[rowIndex];
            var obsVersion = (ObsVersionInfo)row.Tag;
            var pidFilePath = Path.Combine(Path.GetDirectoryName(obsVersion.ObsExePath), "obs_pid.txt");

            if (File.Exists(pidFilePath))
            {
                var pidText = File.ReadAllText(pidFilePath);
                if (int.TryParse(pidText, out int processId))
                {
                    if (HelperFunctions.IsProcessRunning(processId))
                    {
                        try
                        {
                            var process = Process.GetProcessById(processId);
                            process.EnableRaisingEvents = true;

                            lock (GlobalState.ObsProcessesLock)
                            {
                                if (!GlobalState.ObsProcesses.ContainsKey(obsVersion.FolderName))
                                {
                                    process.Exited += (senderObj, eArgs) => MainFormReference.Process_Exited(senderObj, gridOBSversions, obsVersion.FolderName);
                                    GlobalState.ObsProcesses[obsVersion.FolderName] = process;
                                }
                            }
                        }
                        catch (ArgumentException)
                        {
                            // Process not found, ignore and continue
                        }
                    }
                    else
                    {
                        // If the process is not running, remove the obs_pid.txt file
                        MainFormReference.SetProcessStatusIcon(gridOBSversions, rowIndex, false);
                        File.Delete(pidFilePath);
                    }
                }
            }
        }

        private void setAsDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var obsVersion = (ObsVersionInfo)gridOBSversions.SelectedRows[0].Tag;
            
            // Get the currently selected row
            var selectedRow = gridOBSversions.SelectedRows[0];

            // Clear the icon from all rows in the "Default" column
            foreach (DataGridViewRow row in gridOBSversions.Rows)
            {
                row.Cells["Default"].Value = null;
            }

            // Set the check icon for the selected row in the "Default" column
            selectedRow.Cells["Default"].Value = checkmark();

            sett.ing["DefaultOBSpath"] = obsVersion.ObsExePath;
            sett.ing["DefaultOBSversion"] = obsVersion.ObsVersion;
            LoadObsVersions();
        }

        private void setDefaultIcon()
        {
            foreach (DataGridViewRow row in gridOBSversions.Rows)
            {
                var info = (ObsVersionInfo)row.Tag;
                if (info.ObsExePath == sett.ing["DefaultOBSpath"])
                {
                    row.Cells["Default"].Value = checkmark();
                }
            }
        }

        private Bitmap checkmark()
        {
            IconChar iconChar = IconChar.Check;
            IconFont iconFont = IconFont.Auto;
            int iconSize = 48; // Adjust the size as needed
            Bitmap iconBitmap = FormsIconHelper.ToBitmap(iconChar, iconFont, iconSize);
            return iconBitmap;
        }

    }

    public class ObsVersionInfo
    {
        public string RootPath { get; set; }
        public string FolderName { get; set; }
        public string ObsVersion { get; set; }
        public string ObsExePath { get; set; }
        public string ObsConfigPath { get; set; }
        public bool isDefault { get; set; }
        public bool isLocal { get; set; } = false;
    }
}

