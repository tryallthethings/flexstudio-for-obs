using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    public partial class FormBackup : Form
    {
        public string menuTitle = "Backups";
        public FormBackup()
        {
            InitializeComponent();
            HelperFunctions.GetOBSStudioInstallationPath();
            gridBackup.Columns["Backup"].DefaultCellStyle.NullValue = "Backup"; // Set the start button text
            gridBackup.Columns["Restore"].DefaultCellStyle.NullValue = "Restore"; // Set the start button text
            LoadObsVersions();
        }

        private void gridBackup_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                var existingRow = gridBackup.Rows.Cast<DataGridViewRow>().FirstOrDefault(row => row.Tag != null && ((ObsVersionInfo)row.Tag).FolderName == version.FolderName);

                if (existingRow != null)
                {
                    existingRow.Tag = version;
                    existingRow.Cells["OBSversion"].Value = version.ObsVersion;
                }
                else
                {
                    // Add a new row for a new OBS version
                    int rowIndex = gridBackup.Rows.Add( version.FolderName, version.ObsVersion, null,null,null,null);
                    gridBackup.Rows[rowIndex].Tag = version;
                    //gridBackup.Rows[rowIndex].Cells["runningImage"].Value = Properties.Resources.redicon;

                }
            }
        }
    }
}
