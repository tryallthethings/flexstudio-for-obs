
namespace Flexstudio_for_OBS
{
    partial class FormOBSversions
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
            this.components = new System.ComponentModel.Container();
            this.gridOBSversions = new System.Windows.Forms.DataGridView();
            this.contextGridOBSversions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.refreshBtn = new FontAwesome.Sharp.IconButton();
            this.addNewOBSbtn = new FontAwesome.Sharp.IconButton();
            this.runningImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Default = new System.Windows.Forms.DataGridViewImageColumn();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSversion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartOBS = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridOBSversions)).BeginInit();
            this.contextGridOBSversions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridOBSversions
            // 
            this.gridOBSversions.AllowUserToAddRows = false;
            this.gridOBSversions.AllowUserToDeleteRows = false;
            this.gridOBSversions.AllowUserToResizeColumns = false;
            this.gridOBSversions.AllowUserToResizeRows = false;
            this.gridOBSversions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOBSversions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridOBSversions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.gridOBSversions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridOBSversions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOBSversions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.runningImage,
            this.Default,
            this.Folder,
            this.OBSversion,
            this.StartOBS});
            this.gridOBSversions.ContextMenuStrip = this.contextGridOBSversions;
            this.gridOBSversions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridOBSversions.Location = new System.Drawing.Point(0, 0);
            this.gridOBSversions.Margin = new System.Windows.Forms.Padding(2);
            this.gridOBSversions.Name = "gridOBSversions";
            this.gridOBSversions.ReadOnly = true;
            this.gridOBSversions.RowHeadersVisible = false;
            this.gridOBSversions.RowHeadersWidth = 62;
            this.gridOBSversions.RowTemplate.Height = 28;
            this.gridOBSversions.Size = new System.Drawing.Size(580, 400);
            this.gridOBSversions.TabIndex = 0;
            this.gridOBSversions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOBSversions_CellContentClick);
            this.gridOBSversions.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridOBSversions_CellMouseDown);
            // 
            // contextGridOBSversions
            // 
            this.contextGridOBSversions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextGridOBSversions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.setAsDefaultToolStripMenuItem});
            this.contextGridOBSversions.Name = "contextGridOBSversions";
            this.contextGridOBSversions.Size = new System.Drawing.Size(171, 100);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // setAsDefaultToolStripMenuItem
            // 
            this.setAsDefaultToolStripMenuItem.Name = "setAsDefaultToolStripMenuItem";
            this.setAsDefaultToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.setAsDefaultToolStripMenuItem.Text = "Set as Default";
            this.setAsDefaultToolStripMenuItem.Click += new System.EventHandler(this.setAsDefaultToolStripMenuItem_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.refreshBtn);
            this.pnlButtons.Controls.Add(this.addNewOBSbtn);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 406);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(580, 52);
            this.pnlButtons.TabIndex = 6;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.AutoSize = true;
            this.refreshBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refreshBtn.FlatAppearance.BorderSize = 0;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Font = new System.Drawing.Font("Roboto", 10F);
            this.refreshBtn.ForeColor = System.Drawing.Color.LightGray;
            this.refreshBtn.IconChar = FontAwesome.Sharp.IconChar.Rotate;
            this.refreshBtn.IconColor = System.Drawing.Color.White;
            this.refreshBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.refreshBtn.IconSize = 35;
            this.refreshBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshBtn.Location = new System.Drawing.Point(237, 10);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(112, 41);
            this.refreshBtn.TabIndex = 6;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // addNewOBSbtn
            // 
            this.addNewOBSbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewOBSbtn.AutoSize = true;
            this.addNewOBSbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addNewOBSbtn.FlatAppearance.BorderSize = 0;
            this.addNewOBSbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewOBSbtn.Font = new System.Drawing.Font("Roboto", 10F);
            this.addNewOBSbtn.ForeColor = System.Drawing.Color.LightGray;
            this.addNewOBSbtn.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.addNewOBSbtn.IconColor = System.Drawing.Color.White;
            this.addNewOBSbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.addNewOBSbtn.IconSize = 35;
            this.addNewOBSbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addNewOBSbtn.Location = new System.Drawing.Point(364, 10);
            this.addNewOBSbtn.Margin = new System.Windows.Forms.Padding(2);
            this.addNewOBSbtn.Name = "addNewOBSbtn";
            this.addNewOBSbtn.Size = new System.Drawing.Size(216, 41);
            this.addNewOBSbtn.TabIndex = 5;
            this.addNewOBSbtn.Text = "Add new OBS version";
            this.addNewOBSbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewOBSbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.addNewOBSbtn.UseVisualStyleBackColor = true;
            this.addNewOBSbtn.Click += new System.EventHandler(this.addNewOBSbtn_Click);
            // 
            // runningImage
            // 
            this.runningImage.FillWeight = 20F;
            this.runningImage.HeaderText = "";
            this.runningImage.MinimumWidth = 8;
            this.runningImage.Name = "runningImage";
            this.runningImage.ReadOnly = true;
            // 
            // Default
            // 
            this.Default.FillWeight = 30F;
            this.Default.HeaderText = "Default";
            this.Default.MinimumWidth = 8;
            this.Default.Name = "Default";
            this.Default.ReadOnly = true;
            this.Default.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Folder
            // 
            this.Folder.FillWeight = 122.5465F;
            this.Folder.HeaderText = "Folder";
            this.Folder.MinimumWidth = 8;
            this.Folder.Name = "Folder";
            this.Folder.ReadOnly = true;
            // 
            // OBSversion
            // 
            this.OBSversion.FillWeight = 122.5465F;
            this.OBSversion.HeaderText = "OBS version";
            this.OBSversion.MinimumWidth = 8;
            this.OBSversion.Name = "OBSversion";
            this.OBSversion.ReadOnly = true;
            // 
            // StartOBS
            // 
            this.StartOBS.FillWeight = 60F;
            this.StartOBS.HeaderText = "";
            this.StartOBS.MinimumWidth = 8;
            this.StartOBS.Name = "StartOBS";
            this.StartOBS.ReadOnly = true;
            // 
            // FormOBSversions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(580, 458);
            this.Controls.Add(this.gridOBSversions);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormOBSversions";
            this.Text = "FormOBSversions";
            ((System.ComponentModel.ISupportInitialize)(this.gridOBSversions)).EndInit();
            this.contextGridOBSversions.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridOBSversions;
        private System.Windows.Forms.ContextMenuStrip contextGridOBSversions;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsDefaultToolStripMenuItem;
        private System.Windows.Forms.Panel pnlButtons;
        private FontAwesome.Sharp.IconButton refreshBtn;
        private FontAwesome.Sharp.IconButton addNewOBSbtn;
        private System.Windows.Forms.DataGridViewImageColumn runningImage;
        private System.Windows.Forms.DataGridViewImageColumn Default;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSversion;
        private System.Windows.Forms.DataGridViewButtonColumn StartOBS;
    }
}