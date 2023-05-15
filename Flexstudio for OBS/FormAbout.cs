using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    public partial class FormAbout : Form, IMainFormDependent
    {
        public string menuTitle = trans.Me("About");
        private Dictionary<Control, EventHandler> _subscribedControls = new Dictionary<Control, EventHandler>();
        public FormMain MainFormReference { get; set; }

        public FormAbout()
        {
            InitializeComponent();
            // Clear placeholders
            pnlLibrariesUsed.Controls.Clear();
            pnlLibrariesUsed.RowStyles.Clear();
            pnlLibrariesUsed.RowCount = 0;

            List<Licenses> licenses = new List<Licenses>()
            {
                new Licenses
                {
                    ProjectName = "FontAwesome.Sharp",
                    ProjectURL = "https://github.com/awesome-inc/FontAwesome.Sharp",
                    LicenseFile = Properties.Resources.license_apache2_0
                },
                new Licenses
                {
                    ProjectName = "Fody",
                    ProjectURL = "https://github.com/Fody/Fody",
                    LicenseFile = Properties.Resources.license_fody
                },
                new Licenses
                {
                    ProjectName = "Costura.Fody",
                    ProjectURL = "https://github.com/Fody/Costura",
                    LicenseFile = Properties.Resources.license_costura_fody
                },
                new Licenses
                {
                    ProjectName = "MarkDig",
                    ProjectURL = "https://github.com/xoofx/markdig",
                    LicenseFile = Properties.Resources.license_markdig
                },
                new Licenses
                {
                    ProjectName = "Newtonsoft.JSON",
                    ProjectURL = "https://github.com/JamesNK/Newtonsoft.Json",
                    LicenseFile = Properties.Resources.license_newtonsoft_json
                },
                new Licenses
                {
                    ProjectName = "SharpZipLib",
                    ProjectURL = "https://github.com/icsharpcode/SharpZipLib",
                    LicenseFile = Properties.Resources.license_sharplibzip
                },
                new Licenses
                {
                    ProjectName = "Microsoft .NET runtime",
                    ProjectURL = "https://github.com/dotnet/runtime",
                    LicenseFile = Properties.Resources.license_dotnetcore
                },
                new Licenses
                {
                    ProjectName = "Flagpedia.net flag images",
                    ProjectURL = "https://flagpedia.net/about",
                },
                new Licenses
                {
                    ProjectName = "Google Font Roboto",
                    ProjectURL = "https://fonts.google.com/specimen/Roboto/about",
                    LicenseFile = Properties.Resources.license_google_fonts_roboto
                },

            };

            var fontColor = Color.LightGray;
            var backColor = Color.FromArgb(41, 41, 84);
            var font = new Font("Roboto", 10);
            int licenseRowIndex = 0;

            foreach (var lic in licenses)
            {
                if (lic.LicenseFile != null)
                {
                    RoundedIconButton licenseButton = new RoundedIconButton();
                    licenseButton.Anchor = AnchorStyles.None;
                    licenseButton.Dock = DockStyle.Fill;
                    licenseButton.Text = trans.Me("License");
                    licenseButton.FlatStyle = FlatStyle.Flat;
                    licenseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    licenseButton.ForeColor = fontColor;
                    licenseButton.BackColor = backColor;
                    licenseButton.FlatStyle = FlatStyle.Flat;
                    licenseButton.FlatAppearance.BorderSize = 0;
                    licenseButton.Tag = lic;
                    Console.WriteLine(licenseButton.Height);
                    // Add a Click event handler that opens a FormLicense with the license text
                    licenseButton.Click += (s, e) =>
                    {
                        var button = (RoundedIconButton)s;
                        var info = (Licenses)button.Tag;
                        FormShowLicense formLicense = new FormShowLicense(info.LicenseFile, info.ProjectName);
                        formLicense.ShowDialog();
                    };
                    pnlLibrariesUsed.Controls.Add(licenseButton, 0, licenseRowIndex);
                }

                Label licenseLabel = new Label();
                licenseLabel.Text = lic.ProjectName;
                licenseLabel.Anchor = AnchorStyles.None;    
                licenseLabel.Dock = DockStyle.Fill;
                licenseLabel.TextAlign = ContentAlignment.MiddleLeft;
                licenseLabel.Font = font;
                licenseLabel.ForeColor = fontColor;
                pnlLibrariesUsed.Controls.Add(licenseLabel, 1, licenseRowIndex);

                LinkLabel licenseLinkLabel = new LinkLabel();
                licenseLinkLabel.Text = lic.ProjectURL;
                licenseLinkLabel.Anchor = AnchorStyles.None;
                licenseLinkLabel.Dock = DockStyle.Fill;
                licenseLinkLabel.TextAlign = ContentAlignment.MiddleLeft;
                licenseLinkLabel.Font = font;
                licenseLinkLabel.ForeColor = fontColor;
                licenseLinkLabel.LinkColor = fontColor;

                // Add a link to the LinkLabel.
                licenseLinkLabel.Links.Add(0, licenseLinkLabel.Text.Length, licenseLinkLabel.Text);

                // Handle the LinkClicked event.
                licenseLinkLabel.LinkClicked += (sender, e) =>
                {
                    // Open the URL in the default browser.
                    System.Diagnostics.Process.Start(e.Link.LinkData as string);
                };
                pnlLibrariesUsed.Controls.Add(licenseLinkLabel, 2, licenseRowIndex);

                licenseRowIndex++;
            }

            pnlTranslators.Controls.Clear();
            pnlTranslators.RowStyles.Clear();
            pnlTranslators.RowCount = 0;
            List<Translators> translators = new List<Translators>()
            {
                new Translators
                {
                    Name = "TryAllTheThings",
                    ProfileLink = "https://github.com/tryallthethings"
                },
            };

            int translaterRowIndex = 0;
            foreach (var translator in translators)
            {
                PictureBox language = new PictureBox();
                language.Image = Properties.Resources.country_de;
                language.Anchor = AnchorStyles.None;
                language.Dock = DockStyle.None;
                language.SizeMode = PictureBoxSizeMode.AutoSize;
                pnlTranslators.Controls.Add(language, 0, translaterRowIndex);

                Label translatorName = new Label();
                translatorName.Text = translator.Name;
                //translatorName.Anchor = AnchorStyles.None;
                translatorName.Dock = DockStyle.Fill;
                translatorName.TextAlign = ContentAlignment.MiddleLeft;
                translatorName.Font = font;
                translatorName.ForeColor = fontColor;
                pnlTranslators.Controls.Add(translatorName, 1, translaterRowIndex);

                LinkLabel translatorProfileLink = new LinkLabel();
                translatorProfileLink.Text = translator.ProfileLink;
                translatorProfileLink.Anchor = AnchorStyles.None;
                translatorProfileLink.Dock = DockStyle.Fill;
                translatorProfileLink.TextAlign = ContentAlignment.MiddleLeft;
                translatorProfileLink.Font = font;
                translatorProfileLink.ForeColor = fontColor;
                translatorProfileLink.LinkColor = fontColor;

                // Add a link to the LinkLabel.
                translatorProfileLink.Links.Add(0, translatorProfileLink.Text.Length, translatorProfileLink.Text);

                // Handle the LinkClicked event.
                translatorProfileLink.LinkClicked += (sender, e) =>
                {
                    // Open the URL in the default browser.
                    System.Diagnostics.Process.Start(e.Link.LinkData as string);
                };
                pnlTranslators.Controls.Add(translatorProfileLink, 2, translaterRowIndex);

                translaterRowIndex++;
            }
            trans.UpdateAllControlTexts(this.Controls);
        }
    }

    public class Licenses
    {
        public string ProjectName { get; set; }
        public string ProjectURL { get; set; }
        public string LicenseFile { get; set; }
    }

    public class Translators
    { 
        public string Name { get; set;} 
        public string ProfileLink { get; set; }
    }
}
