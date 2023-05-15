namespace Flexstudio_for_OBS
{
    partial class FormShowLicense
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
            this.rtbShowText = new System.Windows.Forms.RichTextBox();
            this.btnClose = new RoundedIconButton();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblLicenseFor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbShowText
            // 
            this.rtbShowText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbShowText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(29)))), ((int)(((byte)(51)))));
            this.rtbShowText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbShowText.Font = new System.Drawing.Font("Roboto", 12F);
            this.rtbShowText.ForeColor = System.Drawing.Color.LightGray;
            this.rtbShowText.Location = new System.Drawing.Point(12, 63);
            this.rtbShowText.Name = "rtbShowText";
            this.rtbShowText.Size = new System.Drawing.Size(631, 492);
            this.rtbShowText.TabIndex = 0;
            this.rtbShowText.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(84)))));
            this.btnClose.BorderRadius = 15;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnClose.IconColor = System.Drawing.Color.LightGray;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 35;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(556, 561);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 41);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Roboto", 14F);
            this.lblLicense.ForeColor = System.Drawing.Color.LightGray;
            this.lblLicense.Location = new System.Drawing.Point(12, 9);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(104, 23);
            this.lblLicense.TabIndex = 2;
            this.lblLicense.Text = "License for";
            // 
            // lblLicenseFor
            // 
            this.lblLicenseFor.AutoSize = true;
            this.lblLicenseFor.Font = new System.Drawing.Font("Roboto", 14F);
            this.lblLicenseFor.ForeColor = System.Drawing.Color.LightGray;
            this.lblLicenseFor.Location = new System.Drawing.Point(12, 32);
            this.lblLicenseFor.Name = "lblLicenseFor";
            this.lblLicenseFor.Size = new System.Drawing.Size(15, 23);
            this.lblLicenseFor.TabIndex = 3;
            this.lblLicenseFor.Text = "-";
            // 
            // FormShowLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(655, 614);
            this.Controls.Add(this.lblLicenseFor);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtbShowText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormShowLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "License information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbShowText;
        private RoundedIconButton btnClose;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblLicenseFor;
    }
}