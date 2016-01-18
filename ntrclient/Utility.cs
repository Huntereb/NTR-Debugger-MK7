namespace ntrclient
{
    using System;
    using System.Diagnostics;

    internal class Utility
    {
        public static string convertByteArrayToHexString(byte[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str = str + arr[i].ToString("X2") + " ";
            }
            return str;
        }

        public static int runCommandAndGetOutput(string exeFile, string args, ref string output)
        {
            string str = null;
            Process process = new Process();
            int exitCode = -1;
            ProcessStartInfo info = new ProcessStartInfo {
                FileName = exeFile,
                Arguments = args,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true
            };
            process.StartInfo = info;
            try
            {
                process.Start();
                process.WaitForExit();
                str = process.StandardError.ReadToEnd() + process.StandardOutput.ReadToEnd();
                exitCode = process.ExitCode;
                output = str;
                process.Close();
                return exitCode;
            }
            catch (Exception exception)
            {
                output = exception.Message;
                return -1;
            }
        }
    }
}

