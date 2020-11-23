using ExecuteRandomFromDirWithGUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace ExecuteRandomFromDirWithGUI
{
    public class ExecutableFile
    {
        public string path { get; set; }
        public string theFile { get; set; }
        public string fullPath { get; set; }
        public bool hasRun { get; set; }
        public string? selectedFolder { get; set; }

        public ExecutableFile() { }
        public ExecutableFile(string FullPath, string? theSelectedFolder) {
            path = Path.GetDirectoryName(FullPath);
            theFile = Path.GetFileName(FullPath);
            fullPath = FullPath;
            selectedFolder = theSelectedFolder;
        }

        public void Execute() {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = fullPath;
            processInfo.WorkingDirectory = Path.GetDirectoryName(fullPath);
            processInfo.ErrorDialog = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = false;
            processInfo.RedirectStandardError = false;
            System.Diagnostics.Process.Start(processInfo);
        }

        public override string ToString() 
        {
            return theFile + (hasRun ? " [Has Executed]" : "");
        }
    }
}