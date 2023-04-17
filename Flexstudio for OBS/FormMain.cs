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

namespace Flexstudio_for_OBS
{
    public partial class FormMain : Form
    {
        // Define default value for bordersize
        private int borderSize = 2;

        // Set mainform instance for user message functions
        public static FormMain MainFormInstance { get; private set; }

        // Timer for user messages
        private Timer _messageTimeoutTimer;
        // Set default message timeout time (10s)
        private Int32 _messageTimeout = 10000;

        // keep track if the drive is mapped
        public static bool isMapped = false;

        public FormMain()
        {
            InitializeComponent();

            // Set main form instance for user message panel
            MainFormInstance = this;

            // Subscribe to FormClosing so we can properly handle things when the user closes the app
            FormClosing += MainForm_FormClosing;

            // Get and set application name 
            lblAppname.Text = SetNameAndVersion();

            //CheckUpdatesButton_Click(null, null);
            uint maxPathLength = GetMaxPathLength();
            if (AppDomain.CurrentDomain.BaseDirectory.Length + 50 > maxPathLength)
            {
                MessageBox.Show("The current path length is already quite long. Consider shorten it as your filesystem only allows paths of up to " + maxPathLength + " characters. This application is started from a path with " + AppDomain.CurrentDomain.BaseDirectory.Length + "characters.");
                Console.WriteLine($"Maximum supported file/path length: {maxPathLength}");
            }
            
            // Create default folders required
            CreateAndCheckFolders(new List<string>() { "temp", "backups", "media" });

            // Load Dashboard as startup Form
            LoadForm<FormDashboard>(btnDashboard);

            // Adjust application form border
            Padding = new Padding(borderSize);
            BackColor = Color.FromArgb(98, 102, 244);
        }

        // Implement dragging form and default behaviour (snapping to desktop corners, shaking, etc.)
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Function to load new Form and make adjustments to GUI
        private void LoadForm<T>(Button button) where T : Form, new()
        {
            T newForm = new T();
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

        public async void CheckUpdatesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var releases = await Updates.FetchLastReleasesAsync(20);

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
            Color activeColor = Color.FromArgb(31, 27, 48);
            Color btnColor = Color.FromArgb(26, 23, 40);

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

        // Move visual indicator to button position
        private void adjustIndicator (Button btn)
        {
            pnlNavIndicator.Height = btn.Height;
            pnlNavIndicator.Top = btn.Top;
            pnlNavIndicator.Left = btn.Left;
            ButtonColorReset(btn);
        }

        // Set the process status icon in FormOBSversions Datagridview
        public void SetProcessStatusIcon(DataGridView dataGridView, int rowIndex, bool isRunning)
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
        }

        // Handles when a OBS version is closed
        public void Process_Exited(object sender, DataGridView dataGridView)
        {
            var process = (Process)sender;
            int rowIndex = GlobalState.ObsProcesses.FirstOrDefault(x => x.Value == process).Key;
            GlobalState.ObsProcesses.Remove(rowIndex);

            // Invoke the SetProcessStatusIcon method on the UI thread
            dataGridView.Invoke(new Action(() => SetProcessStatusIcon(dataGridView, rowIndex, false)));

            // Delete the PID file when the process exits
            var obsVersion = (ObsVersionInfo)dataGridView.Rows[rowIndex].Tag;
            var pidFilePath = Path.Combine(Path.GetDirectoryName(obsVersion.ObsExePath), "obs_pid.txt");
            if (File.Exists(pidFilePath))
            {
                File.Delete(pidFilePath);
            }
        }

        // Find out the maximum path length a given path / drive supports
        private uint GetMaxPathLength()
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

            throw new Win32Exception(Marshal.GetLastWin32Error());
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
            if (sett.ing.HasKeyWithValue("autoRemoveDefaultDrive") && sett.ing.HasKeyWithValue("defaultDrive") && isMapped)
            {
                try
                {
                    if (bool.Parse(sett.ing["autoRemoveDefaultDrive"]))
                    {
                        HelperFunctions.RemoveSubstDrive(char.Parse(sett.ing["defaultDrive"]));
                    }
                }
                catch
                {
                    MessageBox.Show("Could not remove the virtual drive. Either the settings value is wrong or there was an issue using subst.", "Error removing virtual drive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        // Display user messages in a dedicated panel / buttontext
        public void UserMessage(string messageText, MessageType messageType)
        {
            // Initialize the timer if it's not already created
            if (_messageTimeoutTimer == null)
            {
                _messageTimeoutTimer = new Timer();
                _messageTimeoutTimer.Tick += (s, e) =>
                {
                    UsrMsg.Reset();
                    _messageTimeoutTimer.Stop();
                };
            }
            
            Color panelBackColor;
            Color labelTextColor;

            switch (messageType)
            {
                case MessageType.Error:
                    panelBackColor = Color.FromArgb(255, 192, 192);
                    labelTextColor = Color.FromArgb(192, 0, 0);
                    break;
                case MessageType.Warning:
                    panelBackColor = Color.FromArgb(255, 255, 192);
                    labelTextColor = Color.FromArgb(192, 192, 0);
                    break;
                case MessageType.Info:
                    panelBackColor = Color.FromArgb(192, 255, 255);
                    labelTextColor = Color.FromArgb(0, 192, 192);
                    _messageTimeoutTimer.Interval = _messageTimeout;
                    _messageTimeoutTimer.Start();
                    break;
                case MessageType.Default:
                    panelBackColor = Color.FromArgb(26, 23, 40);
                    labelTextColor = Color.FromArgb(0, 192, 192);
                    break;
                default:
                    panelBackColor = Color.White;
                    labelTextColor = Color.Black;
                    break;
            }

            btnMsg.BackColor = panelBackColor;
            btnMsg.ForeColor = labelTextColor;
            btnMsg.Text = messageText;
        }

        public static string SetNameAndVersion()
        {
            string applicationName = Assembly.GetExecutingAssembly().GetName().Name;
            Version applicationVersion = Assembly.GetExecutingAssembly().GetName().Version;

            string appNameVersion = applicationName + " v" + applicationVersion.Major + "." + applicationVersion.Minor + "." + applicationVersion.Build;
            return appNameVersion;
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            Process.Start("http://github.com/tryallthethings/flexstudio-for-obs");
        }
    }

    public interface IMainFormDependent
    {
        FormMain MainFormReference { get; set; }
    }

    // This class tracks the state of OBS process
    public static class GlobalState
    {
        public static Dictionary<int, Process> ObsProcesses { get; } = new Dictionary<int, Process>();
    }

    public static class UsrMsg
    {
        public static void Show(string messageText, MessageType messageType)
        {
            FormMain.MainFormInstance.UserMessage(messageText, messageType);
        }

        public static void Reset()
        {
            FormMain.MainFormInstance.UserMessage("", MessageType.Default);
        }
    }

    public enum MessageType
    {
        Error,
        Warning,
        Info,
        Default
    }

}
