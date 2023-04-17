
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
            this.pnlMenu.Location = new System.Drawing.Point(0, 60);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(249, 741);
            this.pnlMenu.TabIndex = 1;
            // 
            // pnlNavIndicator
            // 
            this.pnlNavIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(99)))), ((int)(((byte)(135)))));
            this.pnlNavIndicator.Location = new System.Drawing.Point(3, 144);
            this.pnlNavIndicator.Name = "pnlNavIndicator";
            this.pnlNavIndicator.Size = new System.Drawing.Size(2, 100);
            this.pnlNavIndicator.TabIndex = 10;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.LightGray;
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Gears;
            this.btnSettings.IconColor = System.Drawing.Color.White;
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.Location = new System.Drawing.Point(0, 677);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(249, 64);
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
            this.btnBackup.ForeColor = System.Drawing.Color.LightGray;
            this.btnBackup.IconChar = FontAwesome.Sharp.IconChar.CloudUploadAlt;
            this.btnBackup.IconColor = System.Drawing.Color.White;
            this.btnBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackup.Location = new System.Drawing.Point(0, 243);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBackup.Size = new System.Drawing.Size(249, 64);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "Backup";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBackup.UseVisualStyleBackColor = true;
            // 
            // btnOBSversions
            // 
            this.btnOBSversions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOBSversions.FlatAppearance.BorderSize = 0;
            this.btnOBSversions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOBSversions.ForeColor = System.Drawing.Color.LightGray;
            this.btnOBSversions.IconChar = FontAwesome.Sharp.IconChar.CodeMerge;
            this.btnOBSversions.IconColor = System.Drawing.Color.White;
            this.btnOBSversions.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOBSversions.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOBSversions.Location = new System.Drawing.Point(0, 179);
            this.btnOBSversions.Name = "btnOBSversions";
            this.btnOBSversions.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnOBSversions.Size = new System.Drawing.Size(249, 64);
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
            this.btnDashboard.ForeColor = System.Drawing.Color.LightGray;
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.TachographDigital;
            this.btnDashboard.IconColor = System.Drawing.Color.White;
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDashboard.Location = new System.Drawing.Point(0, 115);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(249, 64);
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
            this.pnlSideMenuHeader.Name = "pnlSideMenuHeader";
            this.pnlSideMenuHeader.Size = new System.Drawing.Size(249, 115);
            this.pnlSideMenuHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENU";
            // 
            // pnlHeading
            // 
            this.pnlHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.pnlHeading.Controls.Add(this.lblTabTitle);
            this.pnlHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeading.Location = new System.Drawing.Point(249, 60);
            this.pnlHeading.Name = "pnlHeading";
            this.pnlHeading.Size = new System.Drawing.Size(1033, 42);
            this.pnlHeading.TabIndex = 2;
            // 
            // lblTabTitle
            // 
            this.lblTabTitle.AutoSize = true;
            this.lblTabTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblTabTitle.Location = new System.Drawing.Point(10, 6);
            this.lblTabTitle.Name = "lblTabTitle";
            this.lblTabTitle.Size = new System.Drawing.Size(153, 29);
            this.lblTabTitle.TabIndex = 1;
            this.lblTabTitle.Text = "current Menu";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(249, 144);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1033, 657);
            this.pnlContent.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.pnlTop.Controls.Add(this.btnGithub);
            this.pnlTop.Controls.Add(this.lblAppname);
            this.pnlTop.Controls.Add(this.btnWindowMinimize);
            this.pnlTop.Controls.Add(this.btnWindowMaximize);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.pictureBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1282, 60);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // btnGithub
            // 
            this.btnGithub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGithub.IconChar = FontAwesome.Sharp.IconChar.Github;
            this.btnGithub.IconColor = System.Drawing.Color.White;
            this.btnGithub.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGithub.Location = new System.Drawing.Point(1044, 4);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGithub.Size = new System.Drawing.Size(50, 50);
            this.btnGithub.TabIndex = 15;
            this.btnGithub.UseVisualStyleBackColor = true;
            this.btnGithub.Click += new System.EventHandler(this.btnGithub_Click);
            // 
            // lblAppname
            // 
            this.lblAppname.AutoSize = true;
            this.lblAppname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppname.ForeColor = System.Drawing.Color.LightGray;
            this.lblAppname.Location = new System.Drawing.Point(124, 13);
            this.lblAppname.Name = "lblAppname";
            this.lblAppname.Size = new System.Drawing.Size(93, 32);
            this.lblAppname.TabIndex = 14;
            this.lblAppname.Text = "label2";
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
            this.btnWindowMinimize.IconSize = 30;
            this.btnWindowMinimize.Location = new System.Drawing.Point(1147, 0);
            this.btnWindowMinimize.Name = "btnWindowMinimize";
            this.btnWindowMinimize.Size = new System.Drawing.Size(45, 25);
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
            this.btnWindowMaximize.IconSize = 30;
            this.btnWindowMaximize.Location = new System.Drawing.Point(1192, 0);
            this.btnWindowMaximize.Name = "btnWindowMaximize";
            this.btnWindowMaximize.Size = new System.Drawing.Size(45, 25);
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
            this.btnClose.IconSize = 30;
            this.btnClose.Location = new System.Drawing.Point(1237, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 25);
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
            this.btnMsg.Name = "btnMsg";
            this.btnMsg.Size = new System.Drawing.Size(1033, 42);
            this.btnMsg.TabIndex = 1;
            this.btnMsg.UseVisualStyleBackColor = true;
            // 
            // pnlMsg
            // 
            this.pnlMsg.Controls.Add(this.btnMsg);
            this.pnlMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMsg.Location = new System.Drawing.Point(249, 102);
            this.pnlMsg.Name = "pnlMsg";
            this.pnlMsg.Size = new System.Drawing.Size(1033, 42);
            this.pnlMsg.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1282, 801);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMsg);
            this.Controls.Add(this.pnlHeading);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private FontAwesome.Sharp.IconButton btnWindowMinimize;
        private FontAwesome.Sharp.IconButton btnWindowMaximize;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Panel pnlSideMenuHeader;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnMsg;
        private System.Windows.Forms.Panel pnlMsg;
        private System.Windows.Forms.Label lblAppname;
        private FontAwesome.Sharp.IconButton btnGithub;
    }
}

