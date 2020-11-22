using ExecuteRandomFromDirWithGUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace ExecuteRandomFromDirWithGUI
{
    [XmlRoot(ElementName = "ExecutableFile")]
    [Serializable()]
    public class ExecutableFile
    {
        [XmlAttribute(DataType = "string", AttributeName = "path")]
        public string path { get; set; }
        [XmlAttribute(DataType = "string", AttributeName = "theFile")]
        public string theFile { get; set; }
        [XmlAttribute(DataType = "string", AttributeName = "fullPath")]
        public string fullPath { get; set; }
        [XmlAttribute(DataType = "bool", AttributeName = "hasRun")]
        public bool hasRun { get; set; }

        public ExecutableFile() { }
        public ExecutableFile(string FullPath) {
            path = Path.GetFullPath(FullPath);
            theFile = Path.GetFileName(FullPath);
            fullPath = FullPath;
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
            return theFile;
        }

        public string GetFullPath() 
        {
            return fullPath;
        }
    }
}