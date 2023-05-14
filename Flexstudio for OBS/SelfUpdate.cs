using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flexstudio_for_OBS
{
    class SelfUpdate
    {
        public static async Task<bool> CheckForUpdatesAndDownloadAsync()
        {
            string currentExePath = Assembly.GetExecutingAssembly().Location;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string currentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            string tempFileName = null;

            var dt = DateTime.Now;

            string date = sett.ing["lastUpdateCheck"];

            if (!bool.Parse(sett.ing["checkUpdatesDaily"]))
                return false;

            if (sett.ing["lastUpdateCheck"] == dt.ToString("yyyy-MM-dd")) 
                return false;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    string apiUrl = "https://api.github.com/repos/tryallthethings/flexstudio-for-obs/releases";
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Flexstudio for OBS");
                    string jsonResponse = await httpClient.GetStringAsync(apiUrl);
                    JArray releases = JArray.Parse(jsonResponse);
                    if (releases == null)
                    {
                        sett.ing["lastUpdateCheck"] = dt.ToString("yyyy-MM-dd");
                        return false; // No releases found
                    }

                    JObject latestRelease = releases.OrderByDescending(r => r["created_at"].ToString()).FirstOrDefault() as JObject;
                    if (latestRelease == null || !latestRelease.ContainsKey("tag_name") || string.IsNullOrEmpty(latestRelease["tag_name"].ToString()) || latestRelease["tag_name"].ToString() == currentVersion)
                    {
                        sett.ing["lastUpdateCheck"] = dt.ToString("yyyy-MM-dd");
                        return false; // No updates available
                    }

                    JArray assets = latestRelease["assets"] as JArray;
                    if (assets == null)
                    {
                        sett.ing["lastUpdateCheck"] = dt.ToString("yyyy-MM-dd");
                        return false; // No assets found
                    }

                    JObject exeAsset = null;
                    foreach (var asset in assets)
                    {
                        if (asset["name"].ToString().EndsWith(".exe"))
                        {
                            exeAsset = asset as JObject;
                            break;
                        }
                    }

                    if (exeAsset == null || !exeAsset.ContainsKey("browser_download_url") || string.IsNullOrEmpty(exeAsset["browser_download_url"].ToString()))
                    {
                        sett.ing["lastUpdateCheck"] = dt.ToString("yyyy-MM-dd");
                        return false; // No .exe file found in the release
                    }

                    DialogResult result = MessageBox.Show("A new version is available. Do you want to update?", "New version available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        sett.ing["lastUpdateCheck"] = dt.ToString("yyyy-MM-dd");
                        return false; // User decided not to update
                    }

                    tempFileName = Path.GetTempFileName();
                    using (var request = new HttpRequestMessage(HttpMethod.Get, exeAsset["browser_download_url"].ToString()))
                    {
                        using (Stream contentStream = await (await httpClient.SendAsync(request)).Content.ReadAsStreamAsync(),
                            stream = new FileStream(tempFileName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                        {
                            await contentStream.CopyToAsync(stream);
                        }
                    }
                    sett.ing["lastUpdateCheck"] = dt.ToString("yyyy-MM-dd");
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("There was a problem checking for updates. Please check your internet connection and try again.", "Update check failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            string updaterExePath = Path.Combine(Path.GetTempPath(), "Flexstudio_for_OBS_Updater.exe");
            using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Flexstudio_for_OBS.Updater.exe"))
            {
                using (var fileStream = new FileStream(updaterExePath, FileMode.Create))
                {
                    resourceStream.CopyTo(fileStream);
                }
            }

            ProcessStartInfo startInfo = new ProcessStartInfo(updaterExePath, $"\"{currentExePath}\" \"{tempFileName}\" {Process.GetCurrentProcess().Id}")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(startInfo);
            Environment.Exit(0);

            return true;
        }
    }
}
