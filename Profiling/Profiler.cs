using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Profiling
{
    public class Profiler
    {
            public const string ProfilerGuid = "107F578A-E019-4BAF-86A1-7128A749DB05";
            public const string Version = "0.11";
            public EventHandler completed;
            public bool Start(string strPath,string strArguments)
            {
                process = new Process();
                process.StartInfo = new ProcessStartInfo(strPath, strArguments);
                process.StartInfo.EnvironmentVariables["COR_ENABLE_PROFILING"] = "0x1";
                process.StartInfo.EnvironmentVariables["COR_PROFILER"] = "{" + ProfilerGuid + "}";
                if (Environment.Version.Major >= 4)
                {
                    process.StartInfo.EnvironmentVariables["COR_PROFILER_PATH"] = "" + ProfilerGuid + "";
                }
                
                process.StartInfo.UseShellExecute = false;
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(OnProcessExited);

                string directory;
                directory = Path.GetDirectoryName(strPath);

                Directory.SetCurrentDirectory(directory);
                return process.Start();
            }

            private void OnProcessExited(object oSender, EventArgs ea)
            {
                completed(null, null);
            }
            private Process process;
        }
}
