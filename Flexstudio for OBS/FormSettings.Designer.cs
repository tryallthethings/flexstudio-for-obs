
namespace Flexstudio_for_OBS
{
    partial class FormSettings
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
            this.cbbDriveLetter = new System.Windows.Forms.ComboBox();
            this.cbAutoMapDefaultDrive = new System.Windows.Forms.CheckBox();
            this.cbAutoRemoveDefaultDrive = new System.Windows.Forms.CheckBox();
            this.cbAutoStartOBS = new System.Windows.Forms.CheckBox();
            this.lblDefaultDrive = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.TableLayoutPanel();
            this.cbCheckUpdatesDaily = new System.Windows.Forms.CheckBox();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbDriveLetter
            // 
            this.cbbDriveLetter.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbbDriveLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDriveLetter.Font = new System.Drawing.Font("Roboto", 12F);
            this.cbbDriveLetter.FormattingEnabled = true;
            this.cbbDriveLetter.Location = new System.Drawing.Point(270, 64);
            this.cbbDriveLetter.Margin = new System.Windows.Forms.Padding(2);
            this.cbbDriveLetter.Name = "cbbDriveLetter";
            this.cbbDriveLetter.Size = new System.Drawing.Size(54, 32);
            this.cbbDriveLetter.TabIndex = 4;
            this.cbbDriveLetter.Tag = "defaultDrive";
            this.cbbDriveLetter.SelectedValueChanged += new System.EventHandler(this.SettingValueChanged);
            // 
            // cbAutoMapDefaultDrive
            // 
            this.cbAutoMapDefaultDrive.AutoSize = true;
            this.cbAutoMapDefaultDrive.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbAutoMapDefaultDrive.ForeColor = System.Drawing.Color.LightGray;
            this.cbAutoMapDefaultDrive.Location = new System.Drawing.Point(27, 90);
            this.cbAutoMapDefaultDrive.Margin = new System.Windows.Forms.Padding(2);
            this.cbAutoMapDefaultDrive.Name = "cbAutoMapDefaultDrive";
            this.cbAutoMapDefaultDrive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoMapDefaultDrive.Size = new System.Drawing.Size(212, 24);
            this.cbAutoMapDefaultDrive.TabIndex = 6;
            this.cbAutoMapDefaultDrive.Tag = "autoMapDefaultDrive";
            this.cbAutoMapDefaultDrive.Text = "cbAutoMapDefaultDrive";
            this.cbAutoMapDefaultDrive.UseVisualStyleBackColor = true;
            // 
            // cbAutoRemoveDefaultDrive
            // 
            this.cbAutoRemoveDefaultDrive.AutoSize = true;
            this.cbAutoRemoveDefaultDrive.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbAutoRemoveDefaultDrive.ForeColor = System.Drawing.Color.LightGray;
            this.cbAutoRemoveDefaultDrive.Location = new System.Drawing.Point(27, 130);
            this.cbAutoRemoveDefaultDrive.Margin = new System.Windows.Forms.Padding(2);
            this.cbAutoRemoveDefaultDrive.Name = "cbAutoRemoveDefaultDrive";
            this.cbAutoRemoveDefaultDrive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoRemoveDefaultDrive.Size = new System.Drawing.Size(239, 21);
            this.cbAutoRemoveDefaultDrive.TabIndex = 7;
            this.cbAutoRemoveDefaultDrive.Tag = "autoRemoveDefaultDrive";
            this.cbAutoRemoveDefaultDrive.Text = "cbAutoRemoveDefaultDrive";
            this.cbAutoRemoveDefaultDrive.UseVisualStyleBackColor = true;
            // 
            // cbAutoStartOBS
            // 
            this.cbAutoStartOBS.AutoSize = true;
            this.cbAutoStartOBS.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbAutoStartOBS.ForeColor = System.Drawing.Color.LightGray;
            this.cbAutoStartOBS.Location = new System.Drawing.Point(27, 155);
            this.cbAutoStartOBS.Margin = new System.Windows.Forms.Padding(2);
            this.cbAutoStartOBS.Name = "cbAutoStartOBS";
            this.cbAutoStartOBS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoStartOBS.Size = new System.Drawing.Size(156, 21);
            this.cbAutoStartOBS.TabIndex = 8;
            this.cbAutoStartOBS.Tag = "autoStartDefaultOBS";
            this.cbAutoStartOBS.Text = "cbAutoStartOBS";
            this.cbAutoStartOBS.UseVisualStyleBackColor = true;
            // 
            // lblDefaultDrive
            // 
            this.lblDefaultDrive.AutoSize = true;
            this.lblDefaultDrive.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDefaultDrive.Font = new System.Drawing.Font("Roboto", 10F);
            this.lblDefaultDrive.ForeColor = System.Drawing.Color.LightGray;
            this.lblDefaultDrive.Location = new System.Drawing.Point(46, 62);
            this.lblDefaultDrive.Margin = new System.Windows.Forms.Padding(21, 0, 2, 0);
            this.lblDefaultDrive.Name = "lblDefaultDrive";
            this.lblDefaultDrive.Size = new System.Drawing.Size(119, 26);
            this.lblDefaultDrive.TabIndex = 5;
            this.lblDefaultDrive.Text = "lblDefaultDrive";
            this.lblDefaultDrive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSettings
            // 
            this.pnlSettings.ColumnCount = 2;
            this.pnlSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSettings.Controls.Add(this.lblDefaultDrive, 0, 0);
            this.pnlSettings.Controls.Add(this.cbAutoMapDefaultDrive, 0, 1);
            this.pnlSettings.Controls.Add(this.cbAutoStartOBS, 0, 3);
            this.pnlSettings.Controls.Add(this.cbAutoRemoveDefaultDrive, 0, 2);
            this.pnlSettings.Controls.Add(this.cbbDriveLetter, 1, 0);
            this.pnlSettings.Controls.Add(this.cbCheckUpdatesDaily, 0, 4);
            this.pnlSettings.Location = new System.Drawing.Point(15, 15);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Padding = new System.Windows.Forms.Padding(25, 62, 25, 0);
            this.pnlSettings.RowCount = 10;
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlSettings.Size = new System.Drawing.Size(698, 329);
            this.pnlSettings.TabIndex = 9;
            // 
            // cbCheckUpdatesDaily
            // 
            this.cbCheckUpdatesDaily.AutoSize = true;
            this.cbCheckUpdatesDaily.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbCheckUpdatesDaily.ForeColor = System.Drawing.Color.LightGray;
            this.cbCheckUpdatesDaily.Location = new System.Drawing.Point(27, 180);
            this.cbCheckUpdatesDaily.Margin = new System.Windows.Forms.Padding(2);
            this.cbCheckUpdatesDaily.Name = "cbCheckUpdatesDaily";
            this.cbCheckUpdatesDaily.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbCheckUpdatesDaily.Size = new System.Drawing.Size(197, 21);
            this.cbCheckUpdatesDaily.TabIndex = 9;
            this.cbCheckUpdatesDaily.Tag = "checkUpdatesDaily";
            this.cbCheckUpdatesDaily.Text = "cbCheckUpdatesDaily";
            this.cbCheckUpdatesDaily.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(855, 512);
            this.Controls.Add(this.pnlSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbbDriveLetter;
        private System.Windows.Forms.CheckBox cbAutoMapDefaultDrive;
        private System.Windows.Forms.CheckBox cbAutoRemoveDefaultDrive;
        private System.Windows.Forms.CheckBox cbAutoStartOBS;
        private System.Windows.Forms.Label lblDefaultDrive;
        private System.Windows.Forms.TableLayoutPanel pnlSettings;
        private System.Windows.Forms.CheckBox cbCheckUpdatesDaily;
    }
}