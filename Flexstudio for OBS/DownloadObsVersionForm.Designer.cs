
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
            this.btnDownloadSelected = new System.Windows.Forms.Button();
            this.versionHint = new System.Windows.Forms.Label();
            this.cmbVersions = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.progressBar = new TextProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDownloadSelected
            // 
            this.btnDownloadSelected.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDownloadSelected.FlatAppearance.BorderSize = 0;
            this.btnDownloadSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadSelected.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnDownloadSelected.ForeColor = System.Drawing.Color.LightGray;
            this.btnDownloadSelected.Location = new System.Drawing.Point(758, 0);
            this.btnDownloadSelected.Margin = new System.Windows.Forms.Padding(2, 2, 20, 2);
            this.btnDownloadSelected.Name = "btnDownloadSelected";
            this.btnDownloadSelected.Size = new System.Drawing.Size(251, 42);
            this.btnDownloadSelected.TabIndex = 2;
            this.btnDownloadSelected.Text = "Download selected version";
            this.btnDownloadSelected.UseVisualStyleBackColor = true;
            this.btnDownloadSelected.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // versionHint
            // 
            this.versionHint.AutoSize = true;
            this.versionHint.Font = new System.Drawing.Font("Roboto", 10F);
            this.versionHint.ForeColor = System.Drawing.Color.LightGray;
            this.versionHint.Location = new System.Drawing.Point(444, 12);
            this.versionHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.versionHint.Name = "versionHint";
            this.versionHint.Size = new System.Drawing.Size(470, 20);
            this.versionHint.TabIndex = 8;
            this.versionHint.Text = "Only OBS releases with a .ZIP file attached will be shown here";
            // 
            // cmbVersions
            // 
            this.cmbVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVersions.FormattingEnabled = true;
            this.cmbVersions.Location = new System.Drawing.Point(10, 10);
            this.cmbVersions.Margin = new System.Windows.Forms.Padding(2);
            this.cmbVersions.Name = "cmbVersions";
            this.cmbVersions.Size = new System.Drawing.Size(418, 24);
            this.cmbVersions.TabIndex = 0;
            this.cmbVersions.SelectedIndexChanged += new System.EventHandler(this.cmbVersions_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDownloadSelected);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 550);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.panel1.Size = new System.Drawing.Size(1029, 42);
            this.panel1.TabIndex = 10;
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(12, 39);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1005, 504);
            this.webBrowser.TabIndex = 11;
            // 
            // progressBar
            // 
            this.progressBar.CustomText = null;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressBar.FillColor = System.Drawing.Color.RoyalBlue;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(774, 42);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // DownloadObsVersionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1029, 592);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.versionHint);
            this.Controls.Add(this.cmbVersions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DownloadObsVersionForm";
            this.Text = "Flexstudio for OBS - Download an OBS version";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDownloadSelected;
        private TextProgressBar progressBar;
        private System.Windows.Forms.Label versionHint;
        private System.Windows.Forms.ComboBox cmbVersions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}