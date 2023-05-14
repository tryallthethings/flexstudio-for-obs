
namespace Flexstudio_for_OBS
{
    partial class DownloadObsVersionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadObsVersionForm));
            this.btnDownloadSelected = new RoundedIconButton();
            this.versionHint = new System.Windows.Forms.Label();
            this.cmbVersions = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar = new TextProgressBar();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDownloadSelected
            // 
            this.btnDownloadSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(84)))));
            this.btnDownloadSelected.BorderRadius = 15;
            this.btnDownloadSelected.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDownloadSelected.FlatAppearance.BorderSize = 0;
            this.btnDownloadSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadSelected.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnDownloadSelected.ForeColor = System.Drawing.Color.LightGray;
            this.btnDownloadSelected.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDownloadSelected.IconColor = System.Drawing.Color.Black;
            this.btnDownloadSelected.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDownloadSelected.Location = new System.Drawing.Point(501, 0);
            this.btnDownloadSelected.Margin = new System.Windows.Forms.Padding(2, 2, 16, 2);
            this.btnDownloadSelected.Name = "btnDownloadSelected";
            this.btnDownloadSelected.Size = new System.Drawing.Size(306, 29);
            this.btnDownloadSelected.TabIndex = 2;
            this.btnDownloadSelected.Text = "Download selected version";
            this.btnDownloadSelected.UseVisualStyleBackColor = false;
            this.btnDownloadSelected.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // versionHint
            // 
            this.versionHint.AutoSize = true;
            this.versionHint.Font = new System.Drawing.Font("Roboto", 10F);
            this.versionHint.ForeColor = System.Drawing.Color.LightGray;
            this.versionHint.Location = new System.Drawing.Point(355, 10);
            this.versionHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.versionHint.Name = "versionHint";
            this.versionHint.Size = new System.Drawing.Size(385, 17);
            this.versionHint.TabIndex = 8;
            this.versionHint.Text = "Only OBS releases with a .ZIP file attached will be shown here";
            // 
            // cmbVersions
            // 
            this.cmbVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVersions.FormattingEnabled = true;
            this.cmbVersions.Location = new System.Drawing.Point(8, 8);
            this.cmbVersions.Margin = new System.Windows.Forms.Padding(2);
            this.cmbVersions.Name = "cmbVersions";
            this.cmbVersions.Size = new System.Drawing.Size(335, 21);
            this.cmbVersions.TabIndex = 0;
            this.cmbVersions.SelectedIndexChanged += new System.EventHandler(this.cmbVersions_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDownloadSelected);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 440);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 16, 5);
            this.panel1.Size = new System.Drawing.Size(823, 34);
            this.panel1.TabIndex = 10;
            // 
            // progressBar
            // 
            this.progressBar.CustomText = null;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressBar.FillColor = System.Drawing.Color.RoyalBlue;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(497, 29);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(10, 31);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser.MinimumSize = new System.Drawing.Size(16, 16);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(804, 403);
            this.webBrowser.TabIndex = 11;
            // 
            // DownloadObsVersionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(823, 474);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.versionHint);
            this.Controls.Add(this.cmbVersions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DownloadObsVersionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flexstudio for OBS - Download an OBS version";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadObsVersionForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RoundedIconButton btnDownloadSelected;
        private TextProgressBar progressBar;
        private System.Windows.Forms.Label versionHint;
        private System.Windows.Forms.ComboBox cmbVersions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}