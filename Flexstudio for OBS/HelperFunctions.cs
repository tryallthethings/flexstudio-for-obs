using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    }
    public class driveMapResponse
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public bool success { get; set; }
    }
}
