
namespace Flexstudio_for_OBS
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlNavIndicator = new System.Windows.Forms.Panel();
            this.btnSettings = new FontAwesome.Sharp.IconButton();
            this.btnBackup = new FontAwesome.Sharp.IconButton();
            this.btnOBSversions = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.pnlSideMenuHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeading = new System.Windows.Forms.Panel();
            this.lblTabTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnHelp = new FontAwesome.Sharp.IconButton();
            this.btnGithub = new FontAwesome.Sharp.IconButton();
            this.lblAppname = new System.Windows.Forms.Label();
            this.btnWindowMinimize = new FontAwesome.Sharp.IconButton();
            this.btnWindowMaximize = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnMsg = new FontAwesome.Sharp.IconButton();
            this.pnlMsg = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlSideMenuHeader.SuspendLayout();
            this.pnlHeading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.pnlMenu.Controls.Add(this.pnlNavIndicator);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnBackup);
            this.pnlMenu.Controls.Add(this.btnOBSversions);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Controls.Add(this.pnlSideMenuHeader);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 50);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(208, 619);
            this.pnlMenu.TabIndex = 1;
            // 
            // pnlNavIndicator
            // 
            this.pnlNavIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(99)))), ((int)(((byte)(135)))));
            this.pnlNavIndicator.Location = new System.Drawing.Point(2, 125);
            this.pnlNavIndicator.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNavIndicator.Name = "pnlNavIndicator";
            this.pnlNavIndicator.Size = new System.Drawing.Size(1, 84);
            this.pnlNavIndicator.TabIndex = 10;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnSettings.ForeColor = System.Drawing.Color.LightGray;
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Gears;
            this.btnSettings.IconColor = System.Drawing.Color.White;
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.IconSize = 35;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.Location = new System.Drawing.Point(0, 565);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(208, 54);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnBackup.ForeColor = System.Drawing.Color.LightGray;
            this.btnBackup.IconChar = FontAwesome.Sharp.IconChar.CloudUploadAlt;
            this.btnBackup.IconColor = System.Drawing.Color.White;
            this.btnBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBackup.IconSize = 35;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackup.Location = new System.Drawing.Point(0, 179);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnBackup.Size = new System.Drawing.Size(208, 54);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "Backup";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnOBSversions
            // 
            this.btnOBSversions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOBSversions.FlatAppearance.BorderSize = 0;
            this.btnOBSversions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOBSversions.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnOBSversions.ForeColor = System.Drawing.Color.LightGray;
            this.btnOBSversions.IconChar = FontAwesome.Sharp.IconChar.CodeMerge;
            this.btnOBSversions.IconColor = System.Drawing.Color.White;
            this.btnOBSversions.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOBSversions.IconSize = 35;
            this.btnOBSversions.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOBSversions.Location = new System.Drawing.Point(0, 125);
            this.btnOBSversions.Margin = new System.Windows.Forms.Padding(2);
            this.btnOBSversions.Name = "btnOBSversions";
            this.btnOBSversions.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnOBSversions.Size = new System.Drawing.Size(208, 54);
            this.btnOBSversions.TabIndex = 7;
            this.btnOBSversions.Text = "OBS versions";
            this.btnOBSversions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOBSversions.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOBSversions.UseVisualStyleBackColor = true;
            this.btnOBSversions.Click += new System.EventHandler(this.btnOBSversions_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.LightGray;
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.TachographDigital;
            this.btnDashboard.IconColor = System.Drawing.Color.White;
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 35;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDashboard.Location = new System.Drawing.Point(0, 71);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(208, 54);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlSideMenuHeader
            // 
            this.pnlSideMenuHeader.Controls.Add(this.label1);
            this.pnlSideMenuHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSideMenuHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenuHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSideMenuHeader.Name = "pnlSideMenuHeader";
            this.pnlSideMenuHeader.Size = new System.Drawing.Size(208, 71);
            this.pnlSideMenuHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENU";
            // 
            // pnlHeading
            // 
            this.pnlHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.pnlHeading.Controls.Add(this.lblTabTitle);
            this.pnlHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeading.Location = new System.Drawing.Point(208, 50);
            this.pnlHeading.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeading.Name = "pnlHeading";
            this.pnlHeading.Size = new System.Drawing.Size(861, 35);
            this.pnlHeading.TabIndex = 2;
            // 
            // lblTabTitle
            // 
            this.lblTabTitle.AutoSize = true;
            this.lblTabTitle.Font = new System.Drawing.Font("Roboto", 12F);
            this.lblTabTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblTabTitle.Location = new System.Drawing.Point(9, 5);
            this.lblTabTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTabTitle.Name = "lblTabTitle";
            this.lblTabTitle.Size = new System.Drawing.Size(129, 24);
            this.lblTabTitle.TabIndex = 1;
            this.lblTabTitle.Text = "current Menu";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(208, 120);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(861, 549);
            this.pnlContent.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.pnlTop.Controls.Add(this.btnHelp);
            this.pnlTop.Controls.Add(this.btnGithub);
            this.pnlTop.Controls.Add(this.lblAppname);
            this.pnlTop.Controls.Add(this.btnWindowMinimize);
            this.pnlTop.Controls.Add(this.btnWindowMaximize);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.pictureBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1069, 50);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.AutoSize = true;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.IconChar = FontAwesome.Sharp.IconChar.Question;
            this.btnHelp.IconColor = System.Drawing.Color.White;
            this.btnHelp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHelp.IconSize = 30;
            this.btnHelp.Location = new System.Drawing.Point(880, 0);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnHelp.Size = new System.Drawing.Size(45, 46);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnGithub
            // 
            this.btnGithub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGithub.AutoSize = true;
            this.btnGithub.FlatAppearance.BorderSize = 0;
            this.btnGithub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGithub.IconChar = FontAwesome.Sharp.IconChar.Github;
            this.btnGithub.IconColor = System.Drawing.Color.White;
            this.btnGithub.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGithub.IconSize = 30;
            this.btnGithub.Location = new System.Drawing.Point(830, 0);
            this.btnGithub.Margin = new System.Windows.Forms.Padding(2);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGithub.Size = new System.Drawing.Size(45, 46);
            this.btnGithub.TabIndex = 15;
            this.btnGithub.UseVisualStyleBackColor = true;
            this.btnGithub.Click += new System.EventHandler(this.btnGithub_Click);
            // 
            // lblAppname
            // 
            this.lblAppname.AutoSize = true;
            this.lblAppname.Font = new System.Drawing.Font("Roboto", 14F);
            this.lblAppname.ForeColor = System.Drawing.Color.LightGray;
            this.lblAppname.Location = new System.Drawing.Point(104, 15);
            this.lblAppname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppname.Name = "lblAppname";
            this.lblAppname.Size = new System.Drawing.Size(77, 29);
            this.lblAppname.TabIndex = 14;
            this.lblAppname.Text = "label2";
            this.lblAppname.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // btnWindowMinimize
            // 
            this.btnWindowMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWindowMinimize.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnWindowMinimize.FlatAppearance.BorderSize = 0;
            this.btnWindowMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowMinimize.ForeColor = System.Drawing.Color.LightGray;
            this.btnWindowMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnWindowMinimize.IconColor = System.Drawing.Color.White;
            this.btnWindowMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWindowMinimize.IconSize = 25;
            this.btnWindowMinimize.Location = new System.Drawing.Point(944, 1);
            this.btnWindowMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.btnWindowMinimize.Name = "btnWindowMinimize";
            this.btnWindowMinimize.Size = new System.Drawing.Size(40, 40);
            this.btnWindowMinimize.TabIndex = 13;
            this.btnWindowMinimize.UseVisualStyleBackColor = false;
            this.btnWindowMinimize.Click += new System.EventHandler(this.btnWindowMinimize_Click);
            // 
            // btnWindowMaximize
            // 
            this.btnWindowMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWindowMaximize.BackColor = System.Drawing.Color.Cyan;
            this.btnWindowMaximize.FlatAppearance.BorderSize = 0;
            this.btnWindowMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowMaximize.ForeColor = System.Drawing.Color.LightGray;
            this.btnWindowMaximize.IconChar = FontAwesome.Sharp.IconChar.UpRightFromSquare;
            this.btnWindowMaximize.IconColor = System.Drawing.Color.White;
            this.btnWindowMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWindowMaximize.IconSize = 25;
            this.btnWindowMaximize.Location = new System.Drawing.Point(986, 1);
            this.btnWindowMaximize.Margin = new System.Windows.Forms.Padding(2);
            this.btnWindowMaximize.Name = "btnWindowMaximize";
            this.btnWindowMaximize.Size = new System.Drawing.Size(40, 40);
            this.btnWindowMaximize.TabIndex = 12;
            this.btnWindowMaximize.UseVisualStyleBackColor = false;
            this.btnWindowMaximize.Click += new System.EventHandler(this.btnWindowMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 25;
            this.btnClose.Location = new System.Drawing.Point(1028, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 11;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.closeApplicationBtn_Click);
            // 
            // btnMsg
            // 
            this.btnMsg.AutoSize = true;
            this.btnMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMsg.Enabled = false;
            this.btnMsg.FlatAppearance.BorderSize = 0;
            this.btnMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMsg.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnMsg.IconColor = System.Drawing.Color.Black;
            this.btnMsg.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMsg.Location = new System.Drawing.Point(0, 0);
            this.btnMsg.Margin = new System.Windows.Forms.Padding(2);
            this.btnMsg.Name = "btnMsg";
            this.btnMsg.Size = new System.Drawing.Size(861, 35);
            this.btnMsg.TabIndex = 1;
            this.btnMsg.UseVisualStyleBackColor = true;
            // 
            // pnlMsg
            // 
            this.pnlMsg.Controls.Add(this.btnMsg);
            this.pnlMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMsg.Location = new System.Drawing.Point(208, 85);
            this.pnlMsg.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMsg.Name = "pnlMsg";
            this.pnlMsg.Size = new System.Drawing.Size(861, 35);
            this.pnlMsg.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1069, 669);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMsg);
            this.Controls.Add(this.pnlHeading);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flexstudio for OBS v.0.1";
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.pnlMenu.ResumeLayout(false);
            this.pnlSideMenuHeader.ResumeLayout(false);
            this.pnlSideMenuHeader.PerformLayout();
            this.pnlHeading.ResumeLayout(false);
            this.pnlHeading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMsg.ResumeLayout(false);
            this.pnlMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlHeading;
        private System.Windows.Forms.Label lblTabTitle;
        private System.Windows.Forms.Panel pnlContent;
        private FontAwesome.Sharp.IconButton btnOBSversions;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnBackup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlNavIndicator;
        private System.Windows.Forms.Panel pnlSideMenuHeader;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnMsg;
        private System.Windows.Forms.Panel pnlMsg;
        private System.Windows.Forms.Label lblAppname;
        private FontAwesome.Sharp.IconButton btnHelp;
        private FontAwesome.Sharp.IconButton btnGithub;
        private FontAwesome.Sharp.IconButton btnWindowMinimize;
        private FontAwesome.Sharp.IconButton btnWindowMaximize;
        private FontAwesome.Sharp.IconButton btnClose;
    }
}

