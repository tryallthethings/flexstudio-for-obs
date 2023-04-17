
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
            this.SuspendLayout();
            // 
            // cbbDriveLetter
            // 
            this.cbbDriveLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDriveLetter.Font = new System.Drawing.Font("Roboto", 14F);
            this.cbbDriveLetter.FormattingEnabled = true;
            this.cbbDriveLetter.Location = new System.Drawing.Point(193, 40);
            this.cbbDriveLetter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbDriveLetter.Name = "cbbDriveLetter";
            this.cbbDriveLetter.Size = new System.Drawing.Size(44, 31);
            this.cbbDriveLetter.TabIndex = 4;
            this.cbbDriveLetter.Tag = "defaultDrive";
            this.cbbDriveLetter.SelectedValueChanged += new System.EventHandler(this.SettingValueChanged);
            // 
            // cbAutoMapDefaultDrive
            // 
            this.cbAutoMapDefaultDrive.AutoSize = true;
            this.cbAutoMapDefaultDrive.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbAutoMapDefaultDrive.ForeColor = System.Drawing.Color.LightGray;
            this.cbAutoMapDefaultDrive.Location = new System.Drawing.Point(45, 79);
            this.cbAutoMapDefaultDrive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbAutoMapDefaultDrive.Name = "cbAutoMapDefaultDrive";
            this.cbAutoMapDefaultDrive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoMapDefaultDrive.Size = new System.Drawing.Size(292, 21);
            this.cbAutoMapDefaultDrive.TabIndex = 6;
            this.cbAutoMapDefaultDrive.Tag = "autoMapDefaultDrive";
            this.cbAutoMapDefaultDrive.Text = "Automatically map default drive on startup";
            this.cbAutoMapDefaultDrive.UseVisualStyleBackColor = true;
            // 
            // cbAutoRemoveDefaultDrive
            // 
            this.cbAutoRemoveDefaultDrive.AutoSize = true;
            this.cbAutoRemoveDefaultDrive.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbAutoRemoveDefaultDrive.ForeColor = System.Drawing.Color.LightGray;
            this.cbAutoRemoveDefaultDrive.Location = new System.Drawing.Point(45, 108);
            this.cbAutoRemoveDefaultDrive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbAutoRemoveDefaultDrive.Name = "cbAutoRemoveDefaultDrive";
            this.cbAutoRemoveDefaultDrive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoRemoveDefaultDrive.Size = new System.Drawing.Size(314, 21);
            this.cbAutoRemoveDefaultDrive.TabIndex = 7;
            this.cbAutoRemoveDefaultDrive.Tag = "autoRemoveDefaultDrive";
            this.cbAutoRemoveDefaultDrive.Text = "Automatically remove drive on closing this app";
            this.cbAutoRemoveDefaultDrive.UseVisualStyleBackColor = true;
            // 
            // cbAutoStartOBS
            // 
            this.cbAutoStartOBS.AutoSize = true;
            this.cbAutoStartOBS.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbAutoStartOBS.ForeColor = System.Drawing.Color.LightGray;
            this.cbAutoStartOBS.Location = new System.Drawing.Point(45, 136);
            this.cbAutoStartOBS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbAutoStartOBS.Name = "cbAutoStartOBS";
            this.cbAutoStartOBS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoStartOBS.Size = new System.Drawing.Size(271, 21);
            this.cbAutoStartOBS.TabIndex = 8;
            this.cbAutoStartOBS.Tag = "autoStartDefaultOBS";
            this.cbAutoStartOBS.Text = "Automatically start default OBS version";
            this.cbAutoStartOBS.UseVisualStyleBackColor = true;
            // 
            // lblDefaultDrive
            // 
            this.lblDefaultDrive.AutoSize = true;
            this.lblDefaultDrive.Font = new System.Drawing.Font("Roboto", 10F);
            this.lblDefaultDrive.ForeColor = System.Drawing.Color.LightGray;
            this.lblDefaultDrive.Location = new System.Drawing.Point(42, 49);
            this.lblDefaultDrive.Name = "lblDefaultDrive";
            this.lblDefaultDrive.Size = new System.Drawing.Size(146, 17);
            this.lblDefaultDrive.TabIndex = 5;
            this.lblDefaultDrive.Text = "Set default drive letter:";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(684, 410);
            this.Controls.Add(this.cbbDriveLetter);
            this.Controls.Add(this.lblDefaultDrive);
            this.Controls.Add(this.cbAutoStartOBS);
            this.Controls.Add(this.cbAutoRemoveDefaultDrive);
            this.Controls.Add(this.cbAutoMapDefaultDrive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbbDriveLetter;
        private System.Windows.Forms.CheckBox cbAutoMapDefaultDrive;
        private System.Windows.Forms.CheckBox cbAutoRemoveDefaultDrive;
        private System.Windows.Forms.CheckBox cbAutoStartOBS;
        private System.Windows.Forms.Label lblDefaultDrive;
    }
}