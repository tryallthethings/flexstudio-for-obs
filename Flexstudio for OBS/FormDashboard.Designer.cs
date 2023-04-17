
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
            this.btnStartOBS = new FontAwesome.Sharp.IconButton();
            this.btnMapDrive = new FontAwesome.Sharp.IconButton();
            this.LbldefaultDrive = new System.Windows.Forms.Label();
            this.lblDefaultOBS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartOBS
            // 
            this.btnStartOBS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartOBS.FlatAppearance.BorderSize = 0;
            this.btnStartOBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartOBS.ForeColor = System.Drawing.Color.LightGray;
            this.btnStartOBS.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnStartOBS.IconColor = System.Drawing.Color.White;
            this.btnStartOBS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStartOBS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartOBS.Location = new System.Drawing.Point(70, 389);
            this.btnStartOBS.Name = "btnStartOBS";
            this.btnStartOBS.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStartOBS.Size = new System.Drawing.Size(314, 54);
            this.btnStartOBS.TabIndex = 3;
            this.btnStartOBS.Text = "Start Default OBS version";
            this.btnStartOBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartOBS.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStartOBS.UseVisualStyleBackColor = true;
            this.btnStartOBS.Click += new System.EventHandler(this.btnStartOBS_Click);
            // 
            // btnMapDrive
            // 
            this.btnMapDrive.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMapDrive.FlatAppearance.BorderSize = 0;
            this.btnMapDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapDrive.ForeColor = System.Drawing.Color.LightGray;
            this.btnMapDrive.IconChar = FontAwesome.Sharp.IconChar.HardDrive;
            this.btnMapDrive.IconColor = System.Drawing.Color.White;
            this.btnMapDrive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMapDrive.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMapDrive.Location = new System.Drawing.Point(70, 329);
            this.btnMapDrive.Name = "btnMapDrive";
            this.btnMapDrive.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMapDrive.Size = new System.Drawing.Size(314, 54);
            this.btnMapDrive.TabIndex = 2;
            this.btnMapDrive.Text = "Map Default Drive";
            this.btnMapDrive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMapDrive.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMapDrive.UseVisualStyleBackColor = true;
            this.btnMapDrive.Click += new System.EventHandler(this.btnMapDrive_Click);
            // 
            // LbldefaultDrive
            // 
            this.LbldefaultDrive.AutoSize = true;
            this.LbldefaultDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbldefaultDrive.ForeColor = System.Drawing.Color.LightGray;
            this.LbldefaultDrive.Location = new System.Drawing.Point(417, 333);
            this.LbldefaultDrive.Name = "LbldefaultDrive";
            this.LbldefaultDrive.Size = new System.Drawing.Size(80, 37);
            this.LbldefaultDrive.TabIndex = 4;
            this.LbldefaultDrive.Text = "XXX";
            // 
            // lblDefaultOBS
            // 
            this.lblDefaultOBS.AutoSize = true;
            this.lblDefaultOBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultOBS.ForeColor = System.Drawing.Color.LightGray;
            this.lblDefaultOBS.Location = new System.Drawing.Point(417, 393);
            this.lblDefaultOBS.Name = "lblDefaultOBS";
            this.lblDefaultOBS.Size = new System.Drawing.Size(80, 37);
            this.lblDefaultOBS.TabIndex = 5;
            this.lblDefaultOBS.Text = "XXX";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(740, 675);
            this.Controls.Add(this.lblDefaultOBS);
            this.Controls.Add(this.LbldefaultDrive);
            this.Controls.Add(this.btnStartOBS);
            this.Controls.Add(this.btnMapDrive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashboard";
            this.Text = "FormDashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnMapDrive;
        private FontAwesome.Sharp.IconButton btnStartOBS;
        private System.Windows.Forms.Label LbldefaultDrive;
        private System.Windows.Forms.Label lblDefaultOBS;
    }
}