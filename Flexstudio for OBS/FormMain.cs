using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Globalization;
using System.Resources;
using System.Threading;
using static Flexstudio_for_OBS.Logging;
using System.Drawing.Text;

namespace Flexstudio_for_OBS
{
    public partial class FormMain : Form
    {
        // Define default value for bordersize
        private int borderSize = 2;

        // Set mainform instance for user message functions
        public static FormMain MainFormInstance { get; private set; }

        // Timer for user messages
        private System.Windows.Forms.Timer _messageTimeoutTimer;
        // Set default message timeout time (10s)
        private Int32 _messageTimeout = 10000;

        public static PrivateFontCollection pfc;

        public FormMain()
        {
            InitializeComponent();
            InitializeFontCollection();
            // Set main form instance for user message panel
            MainFormInstance = this;

            // Define autoscale dimensions for dpi resolution stuff
            AutoScaleDimensions = new SizeF(96F, 96F);

            // Subscribe to FormClosing so we can properly handle things when the user closes the app
            FormClosing += MainForm_FormClosing;

            // Get and set application name 
            lblAppname.Text = SetNameAndVersion();
            this.Text = SetNameAndVersion();

            //CheckUpdatesButton_Click(null, null);
            uint maxPathLength = GetMaxPathLength();
            if (AppDomain.CurrentDomain.BaseDirectory.Length + 50 > maxPathLength)
            {
                MessageBox.Show("The current path length is already quite long. Consider shorten it as your filesystem only allows paths of up to " + maxPathLength + " characters. This application is started from a path with " + AppDomain.CurrentDomain.BaseDirectory.Length + "characters.");
                Console.WriteLine($"Maximum supported file/path length: {maxPathLength}");
            }
            
            // Create default folders required
            CreateAndCheckFolders(new List<string>() { "temp", "backups", "media", "logs" });

            // Clean up anything from the temp folder
            HelperFunctions.CleanTempFolder();

            // Load all available translations
            LoadLanguages();

            // Check if the user's system language is supported
            CultureInfo userCulture = new CultureInfo(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            CultureInfo defaultCulture = new CultureInfo("en");
            Console.WriteLine("current language" + Thread.CurrentThread.CurrentUICulture);

            if (!IsLanguageSupported(userCulture) && !sett.ing.HasKeyWithValue("language"))
            {
                userCulture = defaultCulture; // Set to English if not supported
                if (!sett.ing.HasKeyWithValue("language"))
                {
                    sett.ing["language"] = userCulture.ToString();
                }
            }
            else
            {
                // Load user selected language from settings
                userCulture = new CultureInfo(sett.ing["language"]);
            }

            // Translate GUI
            trans.UpdateAllControlTexts(Controls);

            // Load Dashboard as startup Form
            LoadForm<FormDashboard>(btnDashboard);

            // Adjust application form border
            Padding = new Padding(borderSize);
            //BackColor = Color.FromArgb(98, 102, 244);

            if (sett.ing.HasKeyWithValue("themeAccentColor")) {
                //ChangePanelBackgroundColors(this, ColorTranslator.FromHtml(sett.ing["themeAccentColor"]));
            }

            trans.LanguageChanged += OnLanguageChanged;

        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            trans.UpdateAllControlTexts(this.Controls);
        }

        // Implement dragging form and default behaviour (snapping to desktop corners, shaking, etc.)
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void LoadForm<T>(Button button) where T : Form, new()
        {
            T newForm = new T
            {
                // set DPI scale whatevers
                AutoScaleDimensions = new SizeF(96F, 96F)
            };

            if (sett.ing.HasKeyWithValue("themeBackgroundColor"))
            {
                // newForm.BackColor = ColorTranslator.FromHtml(sett.ing["themeBackgroundColor"]);
            }

            if (sett.ing.HasKeyWithValue("themeFontColor"))
            {
                //newForm.ForeColor = ColorTranslator.FromHtml(sett.ing["themeFontColor"]);
                // this affects the font color within datagridview as well, therefor disabling it for the time being
            }

            pnlContent.Controls.Clear();
            adjustIndicator(button);
            newForm.Dock = DockStyle.Fill;
            newForm.TopLevel = false;
            newForm.TopMost = true;
            if (newForm is IMainFormDependent mainFormDependent)
            {
                mainFormDependent.MainFormReference = this;
            }

            try
            {
                lblTabTitle.Text = (newForm as dynamic).menuTitle;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                lblTabTitle.Text = newForm.Text; // Use the form name as a fallback
            }

            pnlContent.Controls.Add(newForm);
            newForm.Show();
        }


        private async void MainForm_Load(object sender, EventArgs e)
        {
            await SelfUpdate.CheckForUpdatesAndDownloadAsync();
        }

        public async void CheckUpdatesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var releases = await OBSUpdates.FetchLastReleasesAsync(20);

                // Display the fetched release information
                foreach (var release in releases)
                {
                    Console.WriteLine($"Name: {release.Name}\nBranch Tag: {release.BranchTag}\nIs Beta: {release.isBeta}\nRelease Page URL: {release.ReleasePageUrl}");
                    foreach (var link in release.DownloadLinks)
                    {
                        Console.WriteLine($"{link.Key}: {link.Value}");
                    }
                    Console.WriteLine();
                }

                // Show the release notes in a built-in browser or a popup window
                // You can use the ReleasePageUrl property to navigate to the release page on GitHub
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Set and reset button colors for buttons in menu panel
        private void ButtonColorReset(Button button)
        {
            Color activeColor = Color.FromArgb(57, 50, 89);
            Color btnColor = Color.FromArgb(33, 29, 51);

            foreach (Control control in pnlMenu.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = btnColor;
                }
            }

            button.BackColor = activeColor;
        }

        // Exit Application
        private void closeApplicationBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadForm<FormDashboard>((Button)sender);
        }

        private void btnOBSversions_Click(object sender, EventArgs e)
        {
            LoadForm<FormOBSversions>((Button)sender);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            LoadForm<FormBackup>((Button)sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LoadForm<FormSettings>((Button)sender);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            LoadForm<FormAbout>((Button)sender);
        }

        // Move visual indicator to button position
        private void adjustIndicator (Button btn)
        {
            pnlNavIndicator.Height = btn.Height;
            pnlNavIndicator.Top = btn.Top;
            pnlNavIndicator.Left = btn.Left;
            pnlNavIndicator.BringToFront();
            ButtonColorReset(btn);
        }

        // Set the process status icon in FormOBSversions Datagridview
        public void SetProcessStatusIcon(DataGridView dataGridView, int rowIndex, bool isRunning)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() => SetProcessStatusIcon(dataGridView, rowIndex, isRunning)));
            }
            else
            {
                var cell = dataGridView.Rows[rowIndex].Cells["runningImage"];
                if (isRunning)
                {
                    cell.Value = Properties.Resources.greenicon;
                }
                else
                {
                    cell.Value = Properties.Resources.redicon;
                }

                dataGridView.InvalidateCell(cell);
                dataGridView.Update();
                dataGridView.Refresh();
            }
        }


        // Handles when a OBS version is closed
        public void Process_Exited(object sender, DataGridView dataGridView, string folderName)
        {
            if (sett.ing.isDebug)
                Log.Debug("Process exiting for folder: " + folderName);
            string obsPath = folderName;

            lock (GlobalState.ObsProcessesLock)
            {
                if (obsPath != null)
                {
                    GlobalState.ObsProcesses.Remove(obsPath);
                }
            }

            var obsVersion = new ObsVersionInfo();

            if (dataGridView != null)
            {
                int rowID = -1;

                DataGridViewRow row = dataGridView.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["Folder"].Value.ToString().Equals(obsPath))
                    .First();

                rowID = row.Index;
                if (rowID != -1)
                {
                    // Invoke the SetProcessStatusIcon method on the UI thread
                    dataGridView.Invoke(new Action(() => SetProcessStatusIcon(dataGridView, rowID, false)));
                    obsVersion = (ObsVersionInfo)row.Tag;
                }
            }
            else
            {
                obsVersion = HelperFunctions.FindObsVersionInPath(obsPath);
            }

            var pidFilePath = Path.Combine(Path.GetDirectoryName(obsVersion.ObsExePath), "obs_pid.txt");
            if (File.Exists(pidFilePath))
            {
                File.Delete(pidFilePath);
            }
        }

        // Find out the maximum path length a given path / drive supports
        private uint GetMaxPathLength()
        {
            try
            {
                var appPath = AppDomain.CurrentDomain.BaseDirectory;
                var rootPath = Path.GetPathRoot(appPath);

                var volumeNameBuffer = new StringBuilder(261);
                var fileSystemNameBuffer = new StringBuilder(261);

                if (GetVolumeInformation(
                        rootPath,
                        volumeNameBuffer,
                        (uint)volumeNameBuffer.Capacity,
                        out uint volumeSerialNumber,
                        out uint maxComponentLength,
                        out uint fileSystemFlags,
                        fileSystemNameBuffer,
                        (uint)fileSystemNameBuffer.Capacity))
                {
                    return maxComponentLength;
                }

                // If GetVolumeInformation fails, throw an exception
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            catch (Win32Exception ex)
            {
                // Log the error message and return a default value
                Log.Error($"Error retrieving max path length: {ex.Message}");
                return 260; // Return a default value (e.g., the common maximum path length for Windows)
            }
        }

        // Function required by GetMaxPathLenght to identify max. path length
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetVolumeInformation(
            string lpRootPathName,
            StringBuilder lpVolumeNameBuffer,
            uint nVolumeNameSize,
            out uint lpVolumeSerialNumber,
            out uint lpMaximumComponentLength,
            out uint lpFileSystemFlags,
            StringBuilder lpFileSystemNameBuffer,
            uint nFileSystemNameSize);

        // Creates default folders
        private void CreateAndCheckFolders(List<string> folders)
        {
            foreach (string folder in folders)
            {
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + folder))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + folder);
                }
                try
                {
                    using (FileStream fs = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + folder, "testpermissions.txt")))
                    {
                        // The file was created successfully, so the folder has write permissions.
                        fs.Close();
                        File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + folder, "testpermissions.txt"));
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    // The folder does not have write permissions.
                    MessageBox.Show("You don't have permissions to create files in the current folder: "
                        + Path.Combine(AppDomain.CurrentDomain.BaseDirectory + folder)
                        + ". The error message was: " + ex.ToString(),
                        "Permission error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    Application.Exit();
                }
            }
        }

        // Re-implement window maximize function for our borderless GUI
        private void btnWindowMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        // Re-implement window minimize function for our borderless GUI
        private void btnWindowMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Allow Moving and resizing of main form
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Remove default header and border
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;
            if(m.Msg==WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        }

        // Call adjustform if Main Form is resized
        private void FormMain_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        // Adjust form to accout for missing default borders
        private void AdjustForm()
        {
            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (Padding.Top != borderSize) 
                        Padding = new Padding(borderSize);
                    break;
            }
        }

        // Handle stuff once the app is closed
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Remove subst drive if enabled
            if (sett.ing.HasKeyWithValue("autoRemoveDefaultDrive") && sett.ing.HasKeyWithValue("defaultDrive") && sett.ing.DriveIsMapped)
            {
                try
                {
                    if (bool.Parse(sett.ing["autoRemoveDefaultDrive"]))
                    {
                        if (GlobalState.ObsProcesses.Count == 0) {
                            HelperFunctions.RemoveSubstDrive(char.Parse(sett.ing["defaultDrive"]));
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Could not remove the virtual drive. Either the settings value is wrong or there was an issue using subst.", "Error removing virtual drive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            sett.ing.isFirstStart = true;
        }

        // Display user messages in a dedicated panel / buttontext
        public void UserMessage(string messageText, MessageType messageType, string errormessage, params object[] args)
        {
            string text;
            // Initialize the timer if it's not already created
            if (_messageTimeoutTimer == null)
            {
                _messageTimeoutTimer = new System.Windows.Forms.Timer();
                _messageTimeoutTimer.Tick += (s, e) =>
                {
                    UsrMsg.Reset();
                    _messageTimeoutTimer.Stop();
                };
            }
            
            Color panelBackColor;
            Color labelTextColor;


            text = trans.Me(messageText, args);

            if (!string.IsNullOrEmpty(errormessage))
            {
                text += " " + trans.Me("Error") + ": " + errormessage;
            }

            switch (messageType)
            {
                case MessageType.Error:
                    panelBackColor = Color.FromArgb(255, 192, 192);
                    labelTextColor = Color.FromArgb(192, 0, 0);
                    if (!string.IsNullOrEmpty(text))
                        Log.Error(text);
                    break;
                case MessageType.Warning:
                    panelBackColor = Color.FromArgb(255, 255, 192);
                    labelTextColor = Color.FromArgb(64, 64, 64);
                    if (!string.IsNullOrEmpty(text))
                        Log.Warn(text);
                    break;
                case MessageType.Info:
                    panelBackColor = Color.FromArgb(192, 255, 255);
                    labelTextColor = Color.FromArgb(0, 192, 192);
                    _messageTimeoutTimer.Interval = _messageTimeout;
                    _messageTimeoutTimer.Start();
                    if (!string.IsNullOrEmpty(text))
                        Log.Debug(text);
                    break;
                case MessageType.Default:
                    panelBackColor = Color.FromArgb(33, 29, 51);
                    labelTextColor = Color.LightGray;
                    _messageTimeoutTimer.Interval = _messageTimeout;
                    _messageTimeoutTimer.Start();
                    if (!string.IsNullOrEmpty(text))
                        Log.Debug(text);
                    break;
                default:
                    panelBackColor = Color.White;
                    labelTextColor = Color.Black;
                    break;
            }

            btnMsg.BackColor = panelBackColor;
            btnMsg.ForeColor = labelTextColor;
            btnMsg.Text = text;
        }

        public static string SetNameAndVersion()
        {
            string applicationName = "Flexstudio for OBS";
            Version applicationVersion = Assembly.GetExecutingAssembly().GetName().Version;

            string appNameVersion = applicationName + " v" + applicationVersion.Major + "." + applicationVersion.Minor + "." + applicationVersion.Build;
            return appNameVersion;
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/tryallthethings/flexstudio-for-obs");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://tryallthethings.github.io/flexstudio-for-obs/");
        }

        public void ChangePanelBackgroundColors(Control parentControl, Color themeColor)
        {
            foreach (Control control in parentControl.Controls)
            {
                if ((control is Panel || control is FontAwesome.Sharp.IconButton) && control.Name != "pnlNavIndicator")
                {
                    control.BackColor = themeColor;
                }
                ChangePanelBackgroundColors(control, themeColor);
            }
        }

        private void LoadLanguages()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Get all embedded resource names in the current assembly
            string[] resourceNames = assembly.GetManifestResourceNames();

            foreach (string resourceName in resourceNames)
            {
                // Check if the resource name follows the format "Flexstudio_for_OBS.Languages.Lang_xx.resources"
                if (resourceName.StartsWith("Flexstudio_for_OBS.Languages.Lang_") && resourceName.EndsWith(".resources"))
                {
                    // Extract the culture info from the resource name
                    string cultureName = resourceName.Substring("Flexstudio_for_OBS.Languages.Lang_".Length);
                    cultureName = cultureName.Substring(0, cultureName.Length - ".resources".Length);
                    CultureInfo culture;

                    try
                    {
                        culture = new CultureInfo(cultureName);
                    }
                    catch (CultureNotFoundException)
                    {
                        Console.WriteLine($"Invalid culture name: {cultureName}");
                        continue;
                    }

                    cbLangSelect.Items.Add(new LanguageItem(culture.NativeName, culture));
                }
            }

            CultureInfo cult;

            if (sett.ing.HasKeyWithValue("language"))
            {
                cult = new CultureInfo(sett.ing["language"]);
            }
            else
            {
                cult = new CultureInfo(Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
            }

            // Set the selected index based on the current language
            for (int i = 0; i < cbLangSelect.Items.Count; i++)
            {
                if (((LanguageItem)cbLangSelect.Items[i]).Culture.TwoLetterISOLanguageName == cult.ToString())
                {
                    cbLangSelect.SelectedIndex = i;
                    break;
                }
            }

            cbLangSelect.SelectedIndexChanged += cbLangSelect_SelectedIndexChanged;

            // Invalidate the ComboBox to force a redraw of the selected item
            cbLangSelect.Invalidate();
        }

        private void cbLangSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected language item
            var item = (LanguageItem)cbLangSelect.SelectedItem;

            // Set the CurrentUICulture of the current thread
            Thread.CurrentThread.CurrentUICulture = item.Culture;

            // Set the ResourceManager in the trans class based on the selected language
            trans.late = new ResourceManager($"Flexstudio_for_OBS.Languages.Lang_{item.Culture.TwoLetterISOLanguageName}", typeof(trans).Assembly);
            
            trans.OnLanguageChanged();
            UpdateApplicationCulture();

            // Save selected language to settings
            sett.ing["language"] = item.Culture.ToString();

        }

        private bool IsLanguageSupported(CultureInfo userCulture)
        {
            foreach (LanguageItem item in cbLangSelect.Items)
            {
                if (item.Culture.TwoLetterISOLanguageName == userCulture.TwoLetterISOLanguageName)
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateApplicationCulture()
        {
            CultureInfo selectedCulture = ((LanguageItem)cbLangSelect.SelectedItem).Culture;
            Program.SetApplicationCulture(selectedCulture);
            sett.ing["language"] = selectedCulture.ToString();
        }

        private void InitializeFontCollection()
        {
            // Initialize the font collection
            pfc = new PrivateFontCollection();

            List<string> customFonts = new List<string>
            {
                "Flexstudio_for_OBS.fonts.Roboto-Regular.ttf",
                "Flexstudio_for_OBS.fonts.Roboto-Bold.ttf",
            };

            foreach (string font in customFonts)
            {
                // Get the font from the resources
                var fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(font);

                // Check if the stream is null
                if (fontStream != null)
                {
                    // Create a byte array to hold the font data
                    byte[] fontData = new byte[fontStream.Length];

                    // Read the font data from the resource
                    fontStream.Read(fontData, 0, (int)fontStream.Length);

                    // Allocate memory for the font data
                    IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);

                    // Copy the font data to the allocated memory
                    Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                    // Add the font to the font collection
                    pfc.AddMemoryFont(fontPtr, fontData.Length);

                    // Free the memory that was allocated for the font
                    Marshal.FreeCoTaskMem(fontPtr);
                }
            }
        }
    }

    public interface IMainFormDependent
    {
        FormMain MainFormReference { get; set; }
    }

    // This class tracks the state of OBS process
    public static class GlobalState
    {
        public static Dictionary<string, Process> ObsProcesses { get; } = new Dictionary<string, Process>();
        public static object ObsProcessesLock = new object();
    }

    public static class UsrMsg
    {
        public static void Show(string messageText, MessageType messageType, string errordetail = null, params object[] args)
        {
            FormMain.MainFormInstance.UserMessage(messageText, messageType, errordetail, args);
        }

        public static void Reset()
        {
            FormMain.MainFormInstance.UserMessage("", MessageType.Default, null);
        }
    }

    public enum MessageType
    {
        Error,
        Warning,
        Info,
        Default
    }

    public class LanguageItem
    {
        public string LanguageName { get; set; }
        public CultureInfo Culture { get; set; }

        public LanguageItem(string languageName, CultureInfo culture)
        {
            LanguageName = languageName;
            Culture = culture;
        }

        public override string ToString()
        {
            return LanguageName;
        }
    }

    public static class FontHelper
    {
        public static Font GetCustomFont(float size, FontStyle style)
        {
            try
            {
                return new Font(FormMain.pfc.Families[0], size, style, GraphicsUnit.Point, ((byte)(0)));
            }
            catch
            {
                Log.Error("Could not load font");
                return new Font("Arial", size, style, GraphicsUnit.Point, ((byte)(0)));
            }
        }
    }
}
