using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System.Linq;
using System.Drawing;
using System.Diagnostics;

namespace Flexstudio_for_OBS
{
    public partial class DownloadObsVersionForm : Form
    {
        private List<ReleaseInfo> _releases;
        private CancellationTokenSource cancellationTokenSource;
        private bool clicked = false;

        public DownloadObsVersionForm(List<ReleaseInfo> releases)
        {
            InitializeComponent();
            _releases = releases;

            cmbVersions.DisplayMember = "DisplayName";
            cmbVersions.DataSource = _releases;
            cmbVersions.SelectedIndex = -1;
            webBrowserReleaseNotes.NavigationCompleted += WebBrowserReleaseNotes_NavigationCompleted;

        }

        private void cmbVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = cmbVersions.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var releaseInfo = _releases[selectedIndex];
                webBrowserReleaseNotes.Source = new Uri(releaseInfo.ReleasePageUrl);
            }
            else
            {
                webBrowserReleaseNotes.Source = new Uri("about:blank");
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
                resetProgressBar();
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
                    resetProgressBar();
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Download and extraction cancelled.");
                    resetProgressBar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    resetProgressBar();
                }
                clicked = false;
                btnDownloadSelected.Text = "Download selected version";
                resetProgressBar();
            }
        }

        private void resetProgressBar()
        {
            progressBar.Hide();
            progressBar.Value = 0;
            progressBar.CustomText = "";
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

        private async void WebBrowserReleaseNotes_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                await ScrollToElementWithClass(webBrowserReleaseNotes, "Box-body");
            }
        }

        private async Task ScrollToElementWithClass(WebView2 webView, string className)
        {
            string script = $@"
        (function() {{
            var element = document.getElementsByClassName('{className}')[0];
            if (element) {{
                element.scrollIntoView({{ behavior: 'smooth', block: 'start', inline: 'nearest' }});
            }}
        }})();
    ";

            await webView.ExecuteScriptAsync(script);
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