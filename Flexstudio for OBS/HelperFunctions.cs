using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;


namespace Flexstudio_for_OBS
{
    class HelperFunctions
    {
        public static driveMapResponse CreateSubstDrive(char driveLetter, string targetDirectory)
        {
            string command = $"/c subst {driveLetter}: \"{targetDirectory}\"";
            var processStartInfo = new ProcessStartInfo("cmd.exe", command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Environment.SystemDirectory
            };

            var process = Process.Start(processStartInfo);
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            string errorOutput = process.StandardError.ReadToEnd();

            if (process.ExitCode != 0)
            {
                return new driveMapResponse() { Message = "virtualDriveCreationError", Error = errorOutput, success = false };
            }
            else
            {
                return new driveMapResponse() { Message = "virtualDriveCreationSuccess", Error = output, success = true };
            }
        }

        public static driveMapResponse RemoveSubstDrive(char driveLetter)
        {
            string command = $"/c subst {driveLetter}: /D";
            var processStartInfo = new ProcessStartInfo("cmd.exe", command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Environment.SystemDirectory
            };

            var process = Process.Start(processStartInfo);
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            string errorOutput = process.StandardError.ReadToEnd();

            if (process.ExitCode != 0)
            {
                return new driveMapResponse() { Message = "virtualDriveRemoveError", Error = errorOutput, success = false};
            }
            else
            {
                return new driveMapResponse() { Message = "virtualDriveRemoveSuccess", Error = output, success = true};
            }
        }

        public static bool CheckSubstDrive(char driveLetter)
        {
            string currentExePath = Path.GetFullPath(Assembly.GetExecutingAssembly().Location);
            string command = $"/c subst";
            var processStartInfo = new ProcessStartInfo("cmd.exe", command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Environment.SystemDirectory
            };

            var process = Process.Start(processStartInfo);
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();

            if (output.Contains($"{driveLetter}:\\: =>"))
            {
                string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    if (line.StartsWith($"{driveLetter}:\\: =>", StringComparison.OrdinalIgnoreCase))
                    {
                        string mappedPath = line.Substring($"{driveLetter}:\\: =>".Length).Trim();
                        if (currentExePath.StartsWith(mappedPath, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static void SavePidToFile(string path, string processId)
        {
            var pidFilePath = Path.Combine(Path.GetDirectoryName(path), "obs_pid.txt");

            File.WriteAllText(pidFilePath, processId);
        }

        public static string pathToDrivePath(ObsVersionInfo obsVersion)
        {
            if(obsVersion.isLocal)
            {
                return obsVersion.ObsExePath;
            }

            string path = "";
            if(sett.ing.HasKeyWithValue("defaultDrive") && sett.ing.DriveIsMapped) 
            {
                path = obsVersion.ObsExePath.Substring(AppDomain.CurrentDomain.BaseDirectory.Length);
                path = sett.ing["defaultDrive"] + ":\\" + path;

                return path;
            }
            else
            {
                return obsVersion.ObsExePath;
            }
        }

        public static string pathToDrivePath(string path)
        {
            if (sett.ing.HasKeyWithValue("defaultDrive") && sett.ing.DriveIsMapped)
            {
                path = path.Substring(AppDomain.CurrentDomain.BaseDirectory.Length);
                path = sett.ing["defaultDrive"] + ":\\" + path;

                return path;
            }
            else
            {
                return path;
            }
        }

        public static bool IsSubstDrive(char driveLetter)
        {
            var processStartInfo = new ProcessStartInfo("subst")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();

                // Check if the drive letter appears in the subst command output
                string substDriveInfo = $"{driveLetter}:\\: =>";
                bool isSubstDrive = output.Contains(substDriveInfo);

                return isSubstDrive;
            }
        }

        public static string GetOBSStudioInstallationPath()
        {
            string obsStudioPath = FindOBSStudioInRegistry(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            if (obsStudioPath == null)
            {
                obsStudioPath = FindOBSStudioInRegistry(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            }
            return obsStudioPath;
        }

        private static string FindOBSStudioInRegistry(string registryKeyPath)
        {
            string obsStudioPath = null;
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKeyPath))
            {
                if (key != null)
                {
                    foreach (string subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            if (subKey != null)
                            {
                                string displayName = subKey.GetValue("DisplayName") as string;
                                string publisher = subKey.GetValue("Publisher") as string;

                                if (displayName != null && displayName.Equals("OBS Studio", StringComparison.OrdinalIgnoreCase) &&
                                    publisher != null && publisher.Equals("OBS Project", StringComparison.OrdinalIgnoreCase))
                                {
                                    obsStudioPath = subKey.GetValue("DisplayIcon") as string;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return obsStudioPath;
        }

        public static List<ObsVersionInfo> FindObsVersions()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var directories = Directory.GetDirectories(currentDirectory);

            string ObsExecutable = "obs64.exe";
            string ObsSubfolder = "bin\\64bit";
            ObsVersionInfo localObs = new ObsVersionInfo();

            // Add installed OBS version to list
            string LocalOBSExeFile = HelperFunctions.GetOBSStudioInstallationPath();
            if (LocalOBSExeFile != null)
            {
                string localOBSpath = Directory.GetParent(Directory.GetParent(Directory.GetParent(LocalOBSExeFile).ToString()).ToString()).ToString();

                if (Directory.Exists(localOBSpath))
                {
                    // OBS folder exists in the location found in the Registry

                    if (File.Exists(LocalOBSExeFile))
                    {
                        var localOBSversionInfo = FileVersionInfo.GetVersionInfo(LocalOBSExeFile);
                        // OBS executable found
                        string localOBSconfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "obs-studio");
                        if (File.Exists(Path.Combine(localOBSconfigPath, "global.ini")))
                        {
                            // OBS config file found in %APPDATA%
                            localObs = new ObsVersionInfo
                            {
                                RootPath = localOBSpath,
                                FolderName = trans.Me("localOBSinstall"),
                                ObsVersion = localOBSversionInfo.ProductVersion,
                                ObsConfigPath = localOBSconfigPath,
                                ObsExePath = LocalOBSExeFile,
                                isDefault = sett.ing["DefaultOBSpath"] == LocalOBSExeFile ? true : false,
                                isLocal = true
                            };
                        }
                    }
                }
            }

            var obsVersions = new List<ObsVersionInfo>();
            if (!localObs.IsEmpty())
            {
                obsVersions.Add(localObs);
            }
            
            foreach (var directory in directories)
            {
                string obsSubfolderPath = Path.Combine(directory, ObsSubfolder);
                if (Directory.Exists(obsSubfolderPath))
                {
                    string obsExeFile = Path.Combine(obsSubfolderPath, ObsExecutable);
                    if (File.Exists(obsExeFile))
                    {
                        var versionInfo = FileVersionInfo.GetVersionInfo(obsExeFile);
                        obsVersions.Add(new ObsVersionInfo
                        {
                            RootPath = directory,
                            FolderName = Path.GetFileName(directory),
                            ObsVersion = versionInfo.ProductVersion,
                            ObsConfigPath = Path.Combine(directory, "config", "obs-studio"),
                            ObsExePath = obsExeFile,
                            isDefault = sett.ing["DefaultOBSpath"] == obsExeFile ? true : false
                        });
                    }
                }
            }
            return obsVersions;
        }

        public static ObsVersionInfo FindObsVersionInPath(string path)
        {
            string ObsExecutable = "obs64.exe";
            string ObsSubfolder = "bin\\64bit";
            ObsVersionInfo obsVersion = null;
            var LocalOBSExeFile = HelperFunctions.GetOBSStudioInstallationPath();
            string localOBSpath;
            if (LocalOBSExeFile != null)
                localOBSpath = Directory.GetParent(Directory.GetParent(Directory.GetParent(LocalOBSExeFile).ToString()).ToString()).ToString();
            bool isLocal = false;
            if (path == "obs-studio")
            {
                path = LocalOBSExeFile;
            }

            if (LocalOBSExeFile == path)
            {
                isLocal = true;
            }

            if (path.EndsWith(ObsExecutable))
            {
                path = Directory.GetParent(Directory.GetParent(Directory.GetParent(path).ToString()).ToString()).ToString();
            }
            string obsSubfolderPath = Path.Combine(path, ObsSubfolder);
            if (Directory.Exists(obsSubfolderPath))
            {
                string obsExeFile = Path.Combine(obsSubfolderPath, ObsExecutable);
                if (File.Exists(obsExeFile))
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(obsExeFile);
                    obsVersion = new ObsVersionInfo
                    {
                        RootPath = path,
                        FolderName = Path.GetFileName(path),
                        ObsVersion = versionInfo.ProductVersion,
                        ObsConfigPath = Path.Combine(path, "config", "obs-studio"),
                        ObsExePath = obsExeFile,
                        isDefault = sett.ing["DefaultOBSpath"] == obsExeFile ? true : false,
                        isLocal = isLocal
                    };
                }
            }
            return obsVersion;
        }

        public static bool IsProcessRunning(int processId)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                return process.ProcessName.ToLower().Contains("obs") && !process.HasExited;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public static async Task<Tuple<bool, string>> CreateZipWithMultipleFoldersAsync(Dictionary<string, string> folderPathsWithRoots, string outputZipPath, CancellationToken cancellationToken = default, IProgress<DownloadProgressInfo> progress = null)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            return await Task.Run(() =>
            {
                try
                {
                    int processedEntries = 0;
                    int totalEntries = folderPathsWithRoots.Sum(folderPathWithRoot => Directory.GetFiles(folderPathWithRoot.Key, "*.*", SearchOption.AllDirectories).Length);

                    using (var zipOutputStream = new ZipOutputStream(File.Create(outputZipPath)))
                    {
                        foreach (KeyValuePair<string, string> folderPathWithRoot in folderPathsWithRoots)
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            string folderPath = folderPathWithRoot.Key;
                            string folderRoot = folderPathWithRoot.Value;

                            var result = AddFolderToZip(zipOutputStream, folderPath, folderRoot, cancellationToken, ref processedEntries, totalEntries, progress, sw);
                            if (!result.Item1)
                            {
                                return result;
                            }
                        }

                        zipOutputStream.Finish();
                        zipOutputStream.Close();
                    }
                    return Tuple.Create(true, "");
                }
                catch (OperationCanceledException)
                {
                    return Tuple.Create(false, "Operation canceled by user.");
                }
                catch (Exception ex)
                {
                    return Tuple.Create(false, ex.Message);
                }
            });
        }

        private static Tuple<bool, string> AddFolderToZip(ZipOutputStream zipStream, string folderPath, string entryPath, CancellationToken cancellationToken, ref int processedEntries, int totalEntries, IProgress<DownloadProgressInfo> progress, Stopwatch sw)
        {
            try
            {
                string[] files = Directory.GetFiles(folderPath);
                string[] folders = Directory.GetDirectories(folderPath);

                foreach (string file in files)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string entryName = entryPath != "" ? Path.Combine(entryPath, file.Substring(folderPath.Length + 1)) : file.Substring(folderPath.Length + 1);
                    ZipEntry entry = new ZipEntry(entryName);
                    zipStream.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(file))
                    {
                        byte[] buffer = new byte[4096];
                        int sourceBytes;

                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            zipStream.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }

                    zipStream.CloseEntry();

                    processedEntries++;
                    double progressPercentage = (double)processedEntries / totalEntries * 100;
                    double elapsedTime = sw.Elapsed.TotalSeconds;
                    double remainingTime = elapsedTime * (totalEntries - processedEntries) / processedEntries;

                    progress?.Report(new DownloadProgressInfo
                    {
                        OperationType = trans.Me("Backing up"),
                        ProgressPercentage = progressPercentage,
                        ProcessedEntries = processedEntries,
                        TotalEntries = totalEntries,
                        TimeRemaining = TimeSpan.FromSeconds(Math.Round(remainingTime))
                    });
                }

                foreach (string folder in folders)
                {
                    string entryName = entryPath != "" ? Path.Combine(entryPath, folder.Substring(folderPath.Length + 1)) : folder.Substring(folderPath.Length + 1);
                    AddFolderToZip(zipStream, folder, entryName, cancellationToken, ref processedEntries, totalEntries, progress, sw);
                }
                return Tuple.Create(true, "");
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, ex.Message);
            }
        }

        public static void CleanTempFolder()
        {
            try
            {
                string tempFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");

                if (Directory.Exists(tempFolderPath))
                {
                    DirectoryInfo di = new DirectoryInfo(tempFolderPath);

                    // Delete all files in the temp folder
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }

                    // Delete all subdirectories in the temp folder
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur while cleaning up the temp folder
                System.Windows.MessageBox.Show("An error occurred while cleaning the temp folder: " + ex.Message);
            }
        }

        public static void resetProgressBar(TextProgressBar pg)
        {
            pg.Hide();
            pg.Value = 0;
            pg.CustomText = "";
        }

        public static void Button_TextChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                using (Graphics g = btn.CreateGraphics())
                {
                    // Measure the size of the text
                    SizeF textSize = g.MeasureString(btn.Text, btn.Font);

                    // Add padding for better appearance
                    int padding = 10;

                    // Set the new width based on the measured text size and padding
                    btn.Width = (int)textSize.Width + padding;
                }
            }
        }

        public static Process OBSrunningForFolder(ObsVersionInfo obsVersion)
        {
            var pidFilePath = Path.GetDirectoryName(obsVersion.ObsExePath) + "\\obs_pid.txt";

            if (File.Exists(pidFilePath))
            {
                var pidText = File.ReadAllText(pidFilePath);
                if (int.TryParse(pidText, out int processId))
                {
                    if (IsProcessRunning(processId))
                    {
                        try
                        {
                            var process = Process.GetProcessById(processId);
                            process.EnableRaisingEvents = true;
                            return process;
                        }
                        catch (ArgumentException)
                        {
                            // Process not found, ignore and continue
                        }
                    }
                    else
                    {
                        // If the process is not running, remove the obs_pid.txt file
                        File.Delete(pidFilePath);
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }

    public class driveMapResponse
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public bool success { get; set; }
    }
}
