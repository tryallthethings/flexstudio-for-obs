
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
            this.cmbVersions = new System.Windows.Forms.ComboBox();
            this.btnDownloadSelected = new System.Windows.Forms.Button();
            this.webBrowserReleaseNotes = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.versionHint = new System.Windows.Forms.Label();
            this.progressBar = new TextProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.webBrowserReleaseNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVersions
            // 
            this.cmbVersions.FormattingEnabled = true;
            this.cmbVersions.Location = new System.Drawing.Point(12, 12);
            this.cmbVersions.Name = "cmbVersions";
            this.cmbVersions.Size = new System.Drawing.Size(501, 28);
            this.cmbVersions.TabIndex = 0;
            this.cmbVersions.SelectedIndexChanged += new System.EventHandler(this.cmbVersions_SelectedIndexChanged);
            // 
            // btnDownloadSelected
            // 
            this.btnDownloadSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadSelected.Location = new System.Drawing.Point(995, 587);
            this.btnDownloadSelected.Name = "btnDownloadSelected";
            this.btnDownloadSelected.Size = new System.Drawing.Size(236, 42);
            this.btnDownloadSelected.TabIndex = 2;
            this.btnDownloadSelected.Text = "Download selected version";
            this.btnDownloadSelected.UseVisualStyleBackColor = true;
            this.btnDownloadSelected.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // webBrowserReleaseNotes
            // 
            this.webBrowserReleaseNotes.AllowExternalDrop = true;
            this.webBrowserReleaseNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserReleaseNotes.CreationProperties = null;
            this.webBrowserReleaseNotes.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webBrowserReleaseNotes.Location = new System.Drawing.Point(12, 46);
            this.webBrowserReleaseNotes.Name = "webBrowserReleaseNotes";
            this.webBrowserReleaseNotes.Size = new System.Drawing.Size(1219, 535);
            this.webBrowserReleaseNotes.TabIndex = 3;
            this.webBrowserReleaseNotes.ZoomFactor = 1D;
            // 
            // versionHint
            // 
            this.versionHint.AutoSize = true;
            this.versionHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionHint.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.versionHint.Location = new System.Drawing.Point(532, 14);
            this.versionHint.Name = "versionHint";
            this.versionHint.Size = new System.Drawing.Size(615, 26);
            this.versionHint.TabIndex = 8;
            this.versionHint.Text = "Only OBS releases with a .ZIP file attached will be shown here";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.CustomText = null;
            this.progressBar.FillColor = System.Drawing.Color.RoyalBlue;
            this.progressBar.Location = new System.Drawing.Point(12, 587);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(977, 42);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // DownloadObsVersionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1243, 641);
            this.Controls.Add(this.versionHint);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.webBrowserReleaseNotes);
            this.Controls.Add(this.btnDownloadSelected);
            this.Controls.Add(this.cmbVersions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadObsVersionForm";
            this.Text = "Flexstudio for OBS - Download an OBS version";
            ((System.ComponentModel.ISupportInitialize)(this.webBrowserReleaseNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVersions;
        private System.Windows.Forms.Button btnDownloadSelected;
        private Microsoft.Web.WebView2.WinForms.WebView2 webBrowserReleaseNotes;
        private TextProgressBar progressBar;
        private System.Windows.Forms.Label versionHint;
    }
}