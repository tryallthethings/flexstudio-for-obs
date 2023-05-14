
namespace Flexstudio_for_OBS
{
    partial class FormDashboard
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
            this.lblDefaultDriveDashboard = new System.Windows.Forms.Label();
            this.lblDefaultOBS = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartOBS = new RoundedIconButton();
            this.btnMapDrive = new RoundedIconButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.gitHubLink = new System.Windows.Forms.LinkLabel();
            this.lblAppHint = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDefaultDriveDashboard
            // 
            this.lblDefaultDriveDashboard.AutoSize = true;
            this.lblDefaultDriveDashboard.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDefaultDriveDashboard.Font = new System.Drawing.Font("Roboto", 12F);
            this.lblDefaultDriveDashboard.ForeColor = System.Drawing.Color.LightGray;
            this.lblDefaultDriveDashboard.Location = new System.Drawing.Point(267, 0);
            this.lblDefaultDriveDashboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDefaultDriveDashboard.Name = "lblDefaultDriveDashboard";
            this.lblDefaultDriveDashboard.Size = new System.Drawing.Size(49, 49);
            this.lblDefaultDriveDashboard.TabIndex = 4;
            this.lblDefaultDriveDashboard.Text = "XXX";
            this.lblDefaultDriveDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefaultOBS
            // 
            this.lblDefaultOBS.AutoSize = true;
            this.lblDefaultOBS.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDefaultOBS.Font = new System.Drawing.Font("Roboto", 12F);
            this.lblDefaultOBS.ForeColor = System.Drawing.Color.LightGray;
            this.lblDefaultOBS.Location = new System.Drawing.Point(267, 49);
            this.lblDefaultOBS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDefaultOBS.Name = "lblDefaultOBS";
            this.lblDefaultOBS.Size = new System.Drawing.Size(49, 49);
            this.lblDefaultOBS.TabIndex = 5;
            this.lblDefaultOBS.Text = "XXX";
            this.lblDefaultOBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnStartOBS, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDefaultOBS, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDefaultDriveDashboard, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMapDrive, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(586, 98);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnStartOBS
            // 
            this.btnStartOBS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartOBS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(84)))));
            this.btnStartOBS.BorderRadius = 15;
            this.btnStartOBS.FlatAppearance.BorderSize = 0;
            this.btnStartOBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartOBS.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartOBS.ForeColor = System.Drawing.Color.LightGray;
            this.btnStartOBS.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnStartOBS.IconColor = System.Drawing.Color.White;
            this.btnStartOBS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStartOBS.IconSize = 35;
            this.btnStartOBS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartOBS.Location = new System.Drawing.Point(2, 51);
            this.btnStartOBS.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartOBS.Name = "btnStartOBS";
            this.btnStartOBS.Size = new System.Drawing.Size(261, 44);
            this.btnStartOBS.TabIndex = 3;
            this.btnStartOBS.Text = "Start Default OBS version";
            this.btnStartOBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartOBS.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStartOBS.UseVisualStyleBackColor = false;
            this.btnStartOBS.Click += new System.EventHandler(this.btnStartOBS_Click);
            // 
            // btnMapDrive
            // 
            this.btnMapDrive.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMapDrive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(84)))));
            this.btnMapDrive.BorderRadius = 15;
            this.btnMapDrive.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnMapDrive.FlatAppearance.BorderSize = 0;
            this.btnMapDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapDrive.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnMapDrive.ForeColor = System.Drawing.Color.LightGray;
            this.btnMapDrive.IconChar = FontAwesome.Sharp.IconChar.HardDrive;
            this.btnMapDrive.IconColor = System.Drawing.Color.White;
            this.btnMapDrive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMapDrive.IconSize = 35;
            this.btnMapDrive.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMapDrive.Location = new System.Drawing.Point(2, 2);
            this.btnMapDrive.Margin = new System.Windows.Forms.Padding(2);
            this.btnMapDrive.Name = "btnMapDrive";
            this.btnMapDrive.Size = new System.Drawing.Size(261, 44);
            this.btnMapDrive.TabIndex = 2;
            this.btnMapDrive.Text = "Map Default Drive";
            this.btnMapDrive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMapDrive.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMapDrive.UseVisualStyleBackColor = false;
            this.btnMapDrive.Click += new System.EventHandler(this.btnMapDrive_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.Controls.Add(this.gitHubLink);
            this.pnlBottom.Controls.Add(this.lblAppHint);
            this.pnlBottom.Location = new System.Drawing.Point(15, 466);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(888, 68);
            this.pnlBottom.TabIndex = 7;
            // 
            // gitHubLink
            // 
            this.gitHubLink.AutoSize = true;
            this.gitHubLink.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gitHubLink.Font = new System.Drawing.Font("Roboto", 10F);
            this.gitHubLink.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.gitHubLink.LinkColor = System.Drawing.Color.LightGray;
            this.gitHubLink.Location = new System.Drawing.Point(0, 48);
            this.gitHubLink.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.gitHubLink.Name = "gitHubLink";
            this.gitHubLink.Size = new System.Drawing.Size(409, 20);
            this.gitHubLink.TabIndex = 1;
            this.gitHubLink.TabStop = true;
            this.gitHubLink.Text = "https://github.com/tryallthethings/flexstudio-for-obs";
            this.gitHubLink.VisitedLinkColor = System.Drawing.Color.LightGray;
            this.gitHubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitHubLink_LinkClicked);
            // 
            // lblAppHint
            // 
            this.lblAppHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppHint.Font = new System.Drawing.Font("Roboto", 10F);
            this.lblAppHint.ForeColor = System.Drawing.Color.LightGray;
            this.lblAppHint.Location = new System.Drawing.Point(0, 0);
            this.lblAppHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppHint.Name = "lblAppHint";
            this.lblAppHint.Size = new System.Drawing.Size(888, 69);
            this.lblAppHint.TabIndex = 0;
            this.lblAppHint.Text = "If have feature suggestions, found bugs or want to help translate the project, pl" +
    "ease visit the GitHub page.";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(918, 549);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDashboard";
            this.Text = "FormDashboard";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedIconButton btnMapDrive;
        private RoundedIconButton btnStartOBS;
        private System.Windows.Forms.Label lblDefaultDriveDashboard;
        private System.Windows.Forms.Label lblDefaultOBS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblAppHint;
        private System.Windows.Forms.LinkLabel gitHubLink;
    }
}