using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Flexstudio_for_OBS.Logging;

namespace Flexstudio_for_OBS
{
    class OBSUpdates
    {
        private static HttpClient httpClient;
        private static bool isDebug = false;

        public static async Task<List<ReleaseInfo>> FetchLastReleasesAsync(int count)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Flexstudio for OBS");

            if (sett.ing.HasKeyWithValue("githubAccessToken"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"token {sett.ing["githubAccessToken"]}");
            } 
            else
            {
                bool rateLimitValid = await CheckRateLimitAsync();

                if (!rateLimitValid)
                {
                    // Show an error message to the user
                    UsrMsg.Show("githubApiLimitReached", MessageType.Error);
                    return new List<ReleaseInfo>();
                }
            }

            var url = $"https://api.github.com/repos/obsproject/obs-studio/releases";
            List<dynamic> releases;

            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                releases = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);
            }
            catch (Exception ex)
            {
                // Handle the case where there's no connection or the connection is interrupted
                Log.Error(ex, "Error retrieving OBS releases in FetchLastReleasesAsync");
                return new List<ReleaseInfo>();
            }

            var result = new List<ReleaseInfo>();
            int i = 0;
            while (result.Count < count && i < releases.Count)
            {
                bool isBeta = releases[i].prerelease != null && (bool)releases[i].prerelease ? true : false;
                var downloadLinks = new Dictionary<string, string>();

                foreach (var asset in releases[i].assets)
                {
                    string fileName = (string)asset.name;
                    if (IsValidFileName(fileName))
                    {
                        downloadLinks.Add(fileName, (string)asset.browser_download_url);
                    }
                }

                if (downloadLinks.Count > 0)
                {
                    result.Add(new ReleaseInfo
                    {
                        Name = releases[i].name,
                        BranchTag = releases[i].tag_name,
                        ReleasePageUrl = releases[i].html_url,
                        DownloadLinks = downloadLinks,
                        isBeta = isBeta,
                        ReleaseNotes = releases[i].body
                    });
                }

                i++;
            }
            return result;
        }

        private static bool IsValidFileName(string fileName)
        {
            string pattern = @"^OBS-Studio-\d+\.\d+(\.\d+)?(-(beta|rc)\d+)?-Full-x64\.zip$";
            return Regex.IsMatch(fileName, pattern, RegexOptions.IgnoreCase);
        }

        public static async Task<bool> CheckRateLimitAsync()
        {
            try
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Flexstudio for OBS");
                var url = "https://api.github.com/rate_limit";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                dynamic rateLimit = JsonConvert.DeserializeObject(jsonString);

                int remaining = rateLimit.resources.core.remaining;

                if (remaining < 1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception here, for example, log the error or show a message to the user
                Log.Error(ex, "An error occurred while checking the GitHub API rate limit.");
                return false;
            }
        }
    }

    public class ReleaseInfo
    {
        public string Name { get; set; }
        public string BranchTag { get; set; }
        public string ReleasePageUrl { get; set; }
        public bool isBeta { get; set; }
        public Dictionary<string, string> DownloadLinks { get; set; }
        public string ReleaseNotes { get; set; }

        public string DisplayName
        {
            get
            {
                return isBeta ? $"{Name} (Beta)" : Name;
            }
        }
    }
}
