using System;
using System.Diagnostics;
using System.IO;

namespace Fluks
{
    public class Apply
    {
        public void ApplyTweak(string file, string prop, string args)
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var batFilePath = Path.Combine(currentDirectory, file);
            var p = new Process(); // Start any tweak
            p.StartInfo.UseShellExecute = true; // Dont use CMD
            p.StartInfo.FileName = "cmd.exe"; // File whatever you want
            p.StartInfo.WorkingDirectory = batFilePath;
            p.StartInfo.Arguments = "/k " + prop + args + " && exit"; // File whatever you want
            //p.StartInfo.CreateNoWindow = false; // Dont use CMD
            p.StartInfo.Verb = "runas";
            p.Start();
        }
    }
}