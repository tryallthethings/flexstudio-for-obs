using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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
                return new driveMapResponse() { Message = "Error creating virtual drive", Error = errorOutput, success = false };
            }
            else
            {
                return new driveMapResponse() { Message = "Virtual drive created successfully", Error = output, success = true };
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
                return new driveMapResponse() { Message = "Error removing virtual drive", Error = errorOutput, success = false};
            }
            else
            {
                return new driveMapResponse() { Message = "Virtual drive removed successfully", Error = output, success = true};
            }
        }

        public static void SavePidToFile(string path, string processId)
        {
            var pidFilePath = Path.Combine(Path.GetDirectoryName(path), "obs_pid.txt");

            File.WriteAllText(pidFilePath, processId);
        }

        public static string pathToDrivePath(string path)
        {
            if(sett.ing.HasKeyWithValue("defaultDrive") && FormMain.isMapped) 
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

            var obsVersions = new List<ObsVersionInfo>();
            foreach (var directory in directories)
            {
                string obsSubfolderPath = Path.Combine(directory, ObsSubfolder);
                if (Directory.Exists(obsSubfolderPath))
                {
                    string obsExeFile = Path.Combine(obsSubfolderPath + "\\" + ObsExecutable);
                    if (File.Exists(obsExeFile))
                    {
                        var versionInfo = FileVersionInfo.GetVersionInfo(obsExeFile);
                        obsVersions.Add(new ObsVersionInfo
                        {
                            RootPath = directory,
                            FolderName = Path.GetFileName(directory),
                            ObsVersion = versionInfo.ProductVersion,
                            ObsExePath = obsExeFile
                        });
                    }
                }
            }

            return obsVersions;
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
                        OperationType = "Zipping",
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
                MessageBox.Show("An error occurred while cleaning the temp folder: " + ex.Message);
            }
        }

        public static void resetProgressBar(TextProgressBar pg)
        {
            pg.Hide();
            pg.Value = 0;
            pg.CustomText = "";
        }

    }
    public class driveMapResponse
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public bool success { get; set; }
    }
}
