
namespace Flexstudio_for_OBS
{
    partial class FormBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridBackup = new System.Windows.Forms.DataGridView();
            this.FolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSversion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OBS = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Backup = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Restore = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridBackup)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBackup
            // 
            this.gridBackup.AllowUserToAddRows = false;
            this.gridBackup.AllowUserToDeleteRows = false;
            this.gridBackup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FolderName,
            this.OBSversion,
            this.Profile,
            this.OBS,
            this.Backup,
            this.Restore});
            this.gridBackup.Location = new System.Drawing.Point(12, 12);
            this.gridBackup.Name = "gridBackup";
            this.gridBackup.Size = new System.Drawing.Size(707, 365);
            this.gridBackup.TabIndex = 0;
            this.gridBackup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBackup_CellContentClick);
            // 
            // FolderName
            // 
            this.FolderName.HeaderText = "Folder";
            this.FolderName.Name = "FolderName";
            // 
            // OBSversion
            // 
            this.OBSversion.HeaderText = "Version";
            this.OBSversion.Name = "OBSversion";
            // 
            // Profile
            // 
            this.Profile.HeaderText = "include Profile";
            this.Profile.Name = "Profile";
            // 
            // OBS
            // 
            this.OBS.HeaderText = "include OBS";
            this.OBS.Name = "OBS";
            // 
            // Backup
            // 
            this.Backup.HeaderText = "";
            this.Backup.Name = "Backup";
            // 
            // Restore
            // 
            this.Restore.HeaderText = "";
            this.Restore.Name = "Restore";
            this.Restore.Text = "";
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(731, 436);
            this.Controls.Add(this.gridBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormBackup";
            this.Text = "FormBackup";
            ((System.ComponentModel.ISupportInitialize)(this.gridBackup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBackup;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSversion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Profile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OBS;
        private System.Windows.Forms.DataGridViewButtonColumn Backup;
        private System.Windows.Forms.DataGridViewButtonColumn Restore;
    }
}