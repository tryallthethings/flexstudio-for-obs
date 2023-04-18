using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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

    }
    public class driveMapResponse
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public bool success { get; set; }
    }
}
