using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Flexstudio_for_OBS
{
    class Updates
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string RepoOwner = "obsproject";
        private const string RepoName = "obs-studio";
        private const string AccessToken = "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";
        private const bool isDebug = false;

        public static async Task<List<ReleaseInfo>> FetchLastReleasesAsync(int count)
        {
            await CheckRateLimitAsync();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Flexstudio for OBS");
            if (isDebug)
                httpClient.DefaultRequestHeaders.Add("Authorization", $"token {AccessToken}");

            var url = $"https://api.github.com/repos/{RepoOwner}/{RepoName}/releases";
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var releases = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);

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
                        isBeta = isBeta
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


        public static async Task CheckRateLimitAsync()
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
                throw new InvalidOperationException("You have reached the GitHub API rate limit. Please try again later.");
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

        public string DisplayName
        {
            get
            {
                return isBeta ? $"{Name} (Beta)" : Name;
            }
        }
    }
}
