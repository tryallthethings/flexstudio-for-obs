
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
            this.btnMapDrive = new FontAwesome.Sharp.IconButton();
            this.cbbDriveLetter = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAutoMapDefaultDrive = new System.Windows.Forms.CheckBox();
            this.cbAutoRemoveDefaultDrive = new System.Windows.Forms.CheckBox();
            this.cbAutoStartOBS = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMapDrive
            // 
            this.btnMapDrive.AutoSize = true;
            this.btnMapDrive.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMapDrive.FlatAppearance.BorderSize = 0;
            this.btnMapDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapDrive.ForeColor = System.Drawing.Color.LightGray;
            this.btnMapDrive.IconChar = FontAwesome.Sharp.IconChar.HardDrive;
            this.btnMapDrive.IconColor = System.Drawing.Color.White;
            this.btnMapDrive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMapDrive.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMapDrive.Location = new System.Drawing.Point(55, 13);
            this.btnMapDrive.Name = "btnMapDrive";
            this.btnMapDrive.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMapDrive.Size = new System.Drawing.Size(232, 54);
            this.btnMapDrive.TabIndex = 3;
            this.btnMapDrive.Text = "Set default drive letter";
            this.btnMapDrive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMapDrive.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMapDrive.UseVisualStyleBackColor = true;
            // 
            // cbbDriveLetter
            // 
            this.cbbDriveLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDriveLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDriveLetter.FormattingEnabled = true;
            this.cbbDriveLetter.Location = new System.Drawing.Point(518, 27);
            this.cbbDriveLetter.Name = "cbbDriveLetter";
            this.cbbDriveLetter.Size = new System.Drawing.Size(64, 60);
            this.cbbDriveLetter.TabIndex = 4;
            this.cbbDriveLetter.Tag = "defaultDrive";
            this.cbbDriveLetter.SelectedValueChanged += new System.EventHandler(this.SettingValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMapDrive);
            this.panel1.Controls.Add(this.cbbDriveLetter);
            this.panel1.Location = new System.Drawing.Point(161, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 100);
            this.panel1.TabIndex = 5;
            // 
            // cbAutoMapDefaultDrive
            // 
            this.cbAutoMapDefaultDrive.AutoSize = true;
            this.cbAutoMapDefaultDrive.ForeColor = System.Drawing.Color.White;
            this.cbAutoMapDefaultDrive.Location = new System.Drawing.Point(161, 423);
            this.cbAutoMapDefaultDrive.Name = "cbAutoMapDefaultDrive";
            this.cbAutoMapDefaultDrive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoMapDefaultDrive.Size = new System.Drawing.Size(330, 24);
            this.cbAutoMapDefaultDrive.TabIndex = 6;
            this.cbAutoMapDefaultDrive.Tag = "autoMapDefaultDrive";
            this.cbAutoMapDefaultDrive.Text = "Automatically map default drive on startup";
            this.cbAutoMapDefaultDrive.UseVisualStyleBackColor = true;
            // 
            // cbAutoRemoveDefaultDrive
            // 
            this.cbAutoRemoveDefaultDrive.AutoSize = true;
            this.cbAutoRemoveDefaultDrive.ForeColor = System.Drawing.Color.White;
            this.cbAutoRemoveDefaultDrive.Location = new System.Drawing.Point(161, 466);
            this.cbAutoRemoveDefaultDrive.Name = "cbAutoRemoveDefaultDrive";
            this.cbAutoRemoveDefaultDrive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoRemoveDefaultDrive.Size = new System.Drawing.Size(357, 24);
            this.cbAutoRemoveDefaultDrive.TabIndex = 7;
            this.cbAutoRemoveDefaultDrive.Tag = "autoRemoveDefaultDrive";
            this.cbAutoRemoveDefaultDrive.Text = "Automatically remove drive on closing this app";
            this.cbAutoRemoveDefaultDrive.UseVisualStyleBackColor = true;
            // 
            // cbAutoStartOBS
            // 
            this.cbAutoStartOBS.AutoSize = true;
            this.cbAutoStartOBS.ForeColor = System.Drawing.Color.White;
            this.cbAutoStartOBS.Location = new System.Drawing.Point(161, 508);
            this.cbAutoStartOBS.Name = "cbAutoStartOBS";
            this.cbAutoStartOBS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbAutoStartOBS.Size = new System.Drawing.Size(310, 24);
            this.cbAutoStartOBS.TabIndex = 8;
            this.cbAutoStartOBS.Tag = "autoStartDefaultOBS";
            this.cbAutoStartOBS.Text = "Automatically start default OBS version";
            this.cbAutoStartOBS.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1026, 615);
            this.Controls.Add(this.cbAutoStartOBS);
            this.Controls.Add(this.cbAutoRemoveDefaultDrive);
            this.Controls.Add(this.cbAutoMapDefaultDrive);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnMapDrive;
        private System.Windows.Forms.ComboBox cbbDriveLetter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbAutoMapDefaultDrive;
        private System.Windows.Forms.CheckBox cbAutoRemoveDefaultDrive;
        private System.Windows.Forms.CheckBox cbAutoStartOBS;
    }
}