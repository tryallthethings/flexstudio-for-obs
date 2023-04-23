using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.Http;
using Markdig;

namespace Flexstudio_for_OBS
{
    public partial class DownloadObsVersionForm : Form
    {
        private List<ReleaseInfo> _releases;
        private CancellationTokenSource cancellationTokenSource;
        private bool clicked = false;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);

        // Add a new field to keep track of the first execution
        private bool isFirstExecution = true;

        public DownloadObsVersionForm(List<ReleaseInfo> releases)
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during form initialization: " + ex.Message);
            }
            _releases = releases;

            cmbVersions.DisplayMember = "DisplayName";
            cmbVersions.DataSource = _releases;
            cmbVersions.SelectedIndex = -1;

            // Send all hyperlink clicks to the default browser
            webBrowser.Navigating += WebBrowser_Navigating;

            trans.LanguageChanged += OnLanguageChanged;

        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            trans.UpdateAllControlTexts(this.Controls);
        }

        private void cmbVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFirstExecution)
            {
                // Ignore the first execution and set the flag to false
                isFirstExecution = false;
                return;
            }

            string css = "";

            // Add CSS styles to change background and text color
            if (sett.ing.HasKeyWithValue("themeBackgroundColor") && sett.ing.HasKeyWithValue("themeFontColor"))
            {
                css = @"
                    <style>
                        body {
                            background-color: " + sett.ing["themeBackgroundColor"] + ";" +
                        "color: " + sett.ing["themeFontColor"] + ";" +
                    "}" +
                "</style>";
            }

            var selectedIndex = cmbVersions.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var releaseInfo = _releases[selectedIndex];

                // Prepare the markdown content with the release name and release notes

                string githubLink = "[View release notes on GitHub](" + releaseInfo.ReleasePageUrl + ")";
                string markdownContent = "# Release notes for " + releaseInfo.Name + "\n" + githubLink + "\n\n" + releaseInfo.ReleaseNotes;

                // Configure the Markdig pipeline with your preferred options
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

                // Convert markdown to HTML
                string html = Markdown.ToHtml(markdownContent, pipeline);




                // Insert the CSS styles into the HTML head
                html = "<!DOCTYPE html><html><head>" + css + "</head><body>" + html + "</body></html>";

                // Display the HTML content in a WebBrowser control or any other control that can render HTML
                webBrowser.DocumentText = html;
                //webBrowserReleaseNotes.Source = new Uri(releaseInfo.ReleasePageUrl);
            }
            else
            {
                //webBrowserReleaseNotes.Source = new Uri("about:blank");
                // Set browser to blank page
                webBrowser.DocumentText = "<!DOCTYPE html><html><head>" + css + "</head><body></body></html>";
            }
        }

        private async Task DownloadAndExtractRelease(ReleaseInfo releaseInfo, IProgress<DownloadProgressInfo> downloadProgress, CancellationToken cancellationToken)
        {
            // Find the zip file link
            var zipLink = releaseInfo.DownloadLinks.FirstOrDefault();
            if (zipLink.Key == null || zipLink.Value == null)
            {
                MessageBox.Show("Zip file not found for this release.");
                return;
            }

            // Set up download path and extraction path
            string tempFolderPath = Path.Combine(Application.StartupPath, "temp");
            string downloadFilePath = Path.Combine(tempFolderPath, zipLink.Key);
            string extractionFolderPath = Path.Combine(Application.StartupPath, releaseInfo.BranchTag);

            // Check if the extraction folder already exists
            if (Directory.Exists(extractionFolderPath))
            {
                // Prompt the user for the desired action
                DialogResult result = MessageBox.Show("The target folder already exists. Do you want to overwrite, rename the folder or cancel the operation?\n\nYes - Overwrite\nNo - Rename\nCancel - Cancel operation", "Folder exists", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        // Overwrite: Delete the existing folder
                        break;
                    case DialogResult.No:
                        // Rename: Prompt the user for the new folder name
                        extractionFolderPath = Path.Combine(Application.StartupPath, extractionFolderPath + "_copy");
                        break;
                    case DialogResult.Cancel:
                        // Cancel: Return from the method
                        return;
                }
            }

            // Ensure temp folder exists
            Directory.CreateDirectory(tempFolderPath);

            using (var client = new HttpClient())
            {
                // Set the color for downloading
                progressBar.FillColor = Color.Green;

                // Add this line to support HttpClient timeout
                client.Timeout = Timeout.InfiniteTimeSpan;

                using (var response = await client.GetAsync(zipLink.Value, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    response.EnsureSuccessStatusCode();

                    var totalBytes = response.Content.Headers.ContentLength.GetValueOrDefault(0);
                    var receivedBytes = 0L;
                    var stopwatch = new Stopwatch();

                    using (var fileStream = new FileStream(downloadFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            var buffer = new byte[8192 * 2];
                            int bytesRead;

                            stopwatch.Start();
                            DateTime lastProgressUpdateTime = DateTime.UtcNow;
                            long accumulatedBytesRead = 0;

                            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) != 0)
                            {
                                cancellationToken.ThrowIfCancellationRequested();
                                receivedBytes += bytesRead;
                                accumulatedBytesRead += bytesRead;
                                await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);

                                if ((DateTime.UtcNow - lastProgressUpdateTime).TotalMilliseconds >= 100)
                                {
                                    var progressPercentage = (double)receivedBytes / totalBytes * 100;
                                    var bytesPerSecond = accumulatedBytesRead / stopwatch.Elapsed.TotalSeconds;
                                    var timeRemaining = TimeSpan.FromSeconds((totalBytes - receivedBytes) / bytesPerSecond);

                                    if (double.IsNaN(bytesPerSecond))
                                    {
                                        bytesPerSecond = 0;
                                    }

                                    if (double.IsInfinity(timeRemaining.TotalSeconds) || double.IsNaN(timeRemaining.TotalSeconds) || timeRemaining.TotalSeconds < 0)
                                    {
                                        timeRemaining = TimeSpan.Zero;
                                    }

                                    downloadProgress.Report(new DownloadProgressInfo
                                    {
                                        OperationType = "Downloading",
                                        ProgressPercentage = progressPercentage,
                                        DownloadedSizeMB = receivedBytes / (1024.0 * 1024.0),
                                        TotalSizeMB = totalBytes / (1024.0 * 1024.0),
                                        TimeRemaining = timeRemaining
                                    });

                                    stopwatch.Restart();
                                    accumulatedBytesRead = 0;
                                    lastProgressUpdateTime = DateTime.UtcNow;
                                }
                            }

                        }
                    }
                }
            }

            // Extract the zip file with cancellation support
            // Set the color for extraction
            progressBar.FillColor = Color.Blue;

            // For extraction progress
            var extractionProgress = new Progress<DownloadProgressInfo>(progressInfo =>
            {

                progressBar.Value = (int)progressInfo.ProgressPercentage;
                progressBar.CustomText = $"{progressInfo.OperationType} {progressInfo.ProgressPercentage:0.00}% | Remaining: {progressInfo.TimeRemaining.TotalSeconds}s";
            });

            await ExtractZip(downloadFilePath, extractionFolderPath, extractionProgress, cancellationTokenSource.Token);

            // Cleanup: Delete the downloaded zip file
            File.Delete(downloadFilePath);
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (clicked)
            {
                // Create a CancellationTokenSource instance as a class-level variable
                cancellationTokenSource.Cancel();
                clicked = false;
                btnDownloadSelected.Text = "Download selected version";
                HelperFunctions.resetProgressBar(progressBar);
            }
            else
            {
                var selectedRelease = (ReleaseInfo)cmbVersions.SelectedItem;
                if (selectedRelease == null)
                {
                    MessageBox.Show("Please select a release to download.");
                    return;
                }

                clicked = true;
                btnDownloadSelected.Text = "Cancel";
                progressBar.Show();

                // For download progress
                var downloadProgress = new Progress<DownloadProgressInfo>(progressInfo =>
                {

                    progressBar.Value = (int)progressInfo.ProgressPercentage;
                    progressBar.CustomText = $"{progressInfo.OperationType}: {progressInfo.DownloadedSizeMB:0.00} MB of {progressInfo.TotalSizeMB:0.00} MB - {progressInfo.TimeRemaining.ToString("hh':'mm':'ss")}";
                });

                cancellationTokenSource = new CancellationTokenSource();
                try
                {
                    await DownloadAndExtractRelease(selectedRelease, downloadProgress, cancellationTokenSource.Token);
                    MessageBox.Show("Download and extraction completed successfully.");
                    HelperFunctions.resetProgressBar(progressBar);
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Download and extraction cancelled.");
                    HelperFunctions.resetProgressBar(progressBar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    HelperFunctions.resetProgressBar(progressBar);
                }
                clicked = false;
                btnDownloadSelected.Text = "Download selected version";
                HelperFunctions.resetProgressBar(progressBar);
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Create a CancellationTokenSource instance as a class-level variable
            cancellationTokenSource.Cancel();
        }

        private async Task ExtractZip(string zipFilePath, string targetFolder, IProgress<DownloadProgressInfo> extractionProgress, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                using (var zipFileStream = new FileStream(zipFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (var zipFile = new ZipFile(zipFileStream))
                    {
                        long totalEntries = zipFile.Count;
                        int processedEntries = 0;

                        foreach (ZipEntry entry in zipFile)
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            string destinationPath = Path.Combine(targetFolder, entry.Name);
                            if (entry.IsDirectory)
                            {
                                Directory.CreateDirectory(destinationPath);
                            }
                            else
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                                using (var entryStream = zipFile.GetInputStream(entry))
                                {
                                    using (var outputStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                                    {
                                        entryStream.CopyTo(outputStream);
                                    }
                                }
                            }

                            processedEntries++;
                            extractionProgress.Report(new DownloadProgressInfo
                            {
                                OperationType = "Extracting",
                                ProgressPercentage = (double)processedEntries / totalEntries * 100,
                                ProcessedEntries = processedEntries,
                                TotalEntries = (int)totalEntries
                            });

                        }
                    }
                }
            });
        }

        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            var url = e.Url.ToString();
            if (url != "about:blank")
            {
                // Cancel the navigation in the WebBrowser control
                e.Cancel = true;

                // Open the link in the default browser
                System.Diagnostics.Process.Start(url);
            }
        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }

    public class DownloadProgressInfo
    {
        public string OperationType { get; set; }
        public double ProgressPercentage { get; set; }
        public double DownloadedSizeMB { get; set; }
        public double TotalSizeMB { get; set; }
        public TimeSpan TimeRemaining { get; set; }
        public int ProcessedEntries { get; set; }
        public int TotalEntries { get; set; }
    }

}