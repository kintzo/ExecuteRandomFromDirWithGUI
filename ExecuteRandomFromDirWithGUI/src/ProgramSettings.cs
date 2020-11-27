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
        public bool SelectedRootVisible { get; set; }
        public bool HasRunVisible { get; set; }
        public bool RunAfterSelect { get; set; }

        public void Save() 
        {
            var parser = new FileIniDataParser();
            IniData data = new IniData();

            data["DATA"]["CurrentXMLFile"] = CurrentXMLFile;
            data["DATA"]["SelectedRootVisible"] = SelectedRootVisible.ToString();
            data["DATA"]["HasRunVisible"] = HasRunVisible.ToString();
            data["DATA"]["RunAfterSelect"] = RunAfterSelect.ToString();
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
                Settings.SelectedRootVisible = data["DATA"]["SelectedRootVisible"] != null ? bool.Parse(data["DATA"]["SelectedRootVisible"]) : false;
                Settings.HasRunVisible = data["DATA"]["HasRunVisible"] != null ? bool.Parse(data["DATA"]["HasRunVisible"]) : false;
                Settings.RunAfterSelect = data["DATA"]["RunAfterSelect"] != null ? bool.Parse(data["DATA"]["RunAfterSelect"]) : false;

                return Settings;
            }
            else
            {
                var Settings = new ProgramSettings();
                Settings.SelectedRootVisible = false;
                Settings.Save();
                return Settings;
            } 
        }
    }
}
