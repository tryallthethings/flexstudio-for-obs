
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
            this.components = new System.ComponentModel.Container();
            this.gridBackup = new System.Windows.Forms.DataGridView();
            this.FolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSversion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OBS = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Backup = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Restore = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ttCellPath = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBarZip = new TextProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridBackup)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBackup
            // 
            this.gridBackup.AllowUserToAddRows = false;
            this.gridBackup.AllowUserToDeleteRows = false;
            this.gridBackup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBackup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.gridBackup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FolderName,
            this.OBSversion,
            this.Profile,
            this.OBS,
            this.Backup,
            this.Restore});
            this.gridBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBackup.Location = new System.Drawing.Point(0, 0);
            this.gridBackup.Name = "gridBackup";
            this.gridBackup.RowHeadersVisible = false;
            this.gridBackup.RowHeadersWidth = 51;
            this.gridBackup.Size = new System.Drawing.Size(731, 436);
            this.gridBackup.TabIndex = 0;
            this.gridBackup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBackup_CellContentClick);
            this.gridBackup.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBackup_CellMouseLeave);
            this.gridBackup.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridBackup_CellMouseUp);
            // 
            // FolderName
            // 
            this.FolderName.HeaderText = "Folder";
            this.FolderName.MinimumWidth = 6;
            this.FolderName.Name = "FolderName";
            this.FolderName.ReadOnly = true;
            // 
            // OBSversion
            // 
            this.OBSversion.HeaderText = "OBS Version";
            this.OBSversion.MinimumWidth = 6;
            this.OBSversion.Name = "OBSversion";
            this.OBSversion.ReadOnly = true;
            // 
            // Profile
            // 
            this.Profile.HeaderText = "include Profile";
            this.Profile.MinimumWidth = 6;
            this.Profile.Name = "Profile";
            // 
            // OBS
            // 
            this.OBS.HeaderText = "include OBS";
            this.OBS.MinimumWidth = 6;
            this.OBS.Name = "OBS";
            // 
            // Backup
            // 
            this.Backup.HeaderText = "";
            this.Backup.MinimumWidth = 6;
            this.Backup.Name = "Backup";
            // 
            // Restore
            // 
            this.Restore.HeaderText = "";
            this.Restore.MinimumWidth = 6;
            this.Restore.Name = "Restore";
            this.Restore.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.progressBarZip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 34);
            this.panel1.TabIndex = 11;
            // 
            // progressBarZip
            // 
            this.progressBarZip.CustomText = null;
            this.progressBarZip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarZip.FillColor = System.Drawing.Color.RoyalBlue;
            this.progressBarZip.Location = new System.Drawing.Point(0, 0);
            this.progressBarZip.Name = "progressBarZip";
            this.progressBarZip.Size = new System.Drawing.Size(731, 34);
            this.progressBarZip.TabIndex = 1;
            this.progressBarZip.Visible = false;
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(731, 436);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormBackup";
            this.Text = "FormBackup";
            ((System.ComponentModel.ISupportInitialize)(this.gridBackup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBackup;
        private System.Windows.Forms.ToolTip ttCellPath;
        private TextProgressBar progressBarZip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSversion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Profile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OBS;
        private System.Windows.Forms.DataGridViewButtonColumn Backup;
        private System.Windows.Forms.DataGridViewButtonColumn Restore;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}