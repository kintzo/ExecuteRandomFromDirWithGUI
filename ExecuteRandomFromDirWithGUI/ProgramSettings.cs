using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using System.IO;

namespace ExecuteRandomFromDirWithGUI
{
    class ProgramSettings
    {
        public string CurrentXMLFile { get; set; }
        public void Save() 
        {
            var parser = new FileIniDataParser();
            IniData data = new IniData();

            data["DATA"]["CurrentXMLFile"] = CurrentXMLFile;
            parser.WriteFile("Configuration.ini", data);
        }

        public static ProgramSettings Read()
        {
            if (File.Exists("Configuration.ini"))
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("Configuration.ini");

                var Settings = new ProgramSettings();
                Settings.CurrentXMLFile = data["DATA"]["CurrentXMLFile"];

                return Settings;
            }
            else
            {
                var Settings = new ProgramSettings();
                Settings.Save();
                return Settings;
            } 
        }
    }
}
