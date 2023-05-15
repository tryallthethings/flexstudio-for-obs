using System;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    public partial class FormShowLicense : Form
    {
        public FormShowLicense(string licenseText, string licenseFor)
        {
            InitializeComponent();
            rtbShowText.Text = licenseText;
            lblLicenseFor.Text = licenseFor;
            Text = trans.Me("License information");
            trans.UpdateAllControlTexts(this.Controls);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Close();
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
