using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;

namespace ExecuteRandomFromDirWithGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private List<ExecutableFile> executableFiles = new List<ExecutableFile>();
        //private ExecutableFile executableFileCursor;
        private ProgramSettings programSettings;

        private ExecutableFile getCurrentObject() 
        {
            return (ExecutableFile)dataList.SelectedObject;
        }

        private void setCurrentObject(ExecutableFile item) 
        {
            dataList.SelectedObject = item;

            dataList.LowLevelScroll(0, dataList.Items.Count * -17);
            dataList.LowLevelScroll(0, dataList.IndexOf(dataList.SelectedObject) * 17);

            setCurrentFile(item);
        }

        public static string[] GetAllSafeFiles(string path, IProgress<int> progress, string searchPattern = "*.*")
        {
            List<string> allFiles = new List<string>();
            string[] root = Directory.GetFiles(path, searchPattern);
            allFiles.AddRange(root);

            string[] folders = Directory.GetDirectories(path);
            for (var i = 0; i < folders.Length; i++)
            {
                var perComplete = (i * 100) / folders.Length;
                progress.Report(perComplete);

                try
                {
                    if (!IsIgnorable(folders[i]))
                    {
                        allFiles.AddRange(Directory.GetFiles(folders[i], searchPattern, SearchOption.AllDirectories));
                    }
                }
                catch { }
            }

            return allFiles.ToArray();
        }

        private static bool IsIgnorable(string dir)
        {
            if (dir.EndsWith("System Volume Information")) return true;
            if (dir.Contains("$RECYCLE.BIN")) return true;
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Renderer = new CustomToolStripRenderer();
            menuStrip1.ForeColor = System.Drawing.Color.White;

            readSettings();
            readList();
            readOutputFiles();
        }

        private void onRandom_Click(object sender, EventArgs e)
        {
            if (executableFiles.Count > 0)
            {
                int index = new Random().Next(executableFiles.Count);
                setCurrentObject(executableFiles[index]);
            }
            else
            {
                MessageBox.Show("File list not found");
            }
        }

        private void onNewRandom_Click(object sender, EventArgs e)
        {
            if (executableFiles.Count > 0)
            {
                var tmpList = executableFiles.Where(x => !x.hasRun).ToList();

                if (tmpList.Count == 0)
                {
                    MessageBox.Show("No file was found that hasn't been executed.", "Select Something New", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int tmpIndex = new Random().Next(tmpList.Count);
                var lbIndex = executableFiles.IndexOf(tmpList[tmpIndex]);

                setCurrentObject(executableFiles[lbIndex]);
            }
            else
            {
                MessageBox.Show("File list not found");
            }
        }

        private void onRunSelected_Click(object sender, EventArgs e)
        {
            if (getCurrentObject() == null) return;

            var item = getCurrentObject();
            try
            {
                item.Execute();

                var idx = executableFiles.IndexOf(item);
                executableFiles[idx].hasRun = true;

                saveList();
            }
            catch (Exception ex)
            {
                var b = MessageBox.Show(ex.Message + System.Environment.NewLine + $"Delete path \"{item.fullPath}\"?", "Run application", MessageBoxButtons.YesNo);

                if (b == DialogResult.Yes)
                {
                    DeleteExeFromList();
                }
            }
        }

        private void onDeleteSelected_Click(object sender, EventArgs e)
        {
            var item = getCurrentObject();

            var b = MessageBox.Show($"Remove Path: \"{item.fullPath}\" ?", $"Delete {item.theFile}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (b == DialogResult.Yes) DeleteExeFromList();
        }

        private void onOpenBlackList_Click(object sender, EventArgs e)
        {
            var blackListForm = new FormBlackList();
            if (blackListForm.ShowDialog(this) == DialogResult.OK)
            {
                saveList();
            }
        }

        private void onAbout_Click(object sender, EventArgs e)
        {
            var nigga = new About();
            nigga.Show();
        }
        
        private void onOpenFolders_Click(object sender, EventArgs e)
        {
            var foldersListForm = new FormFolders();
            foldersListForm.Show();
        }

        private void onRenewList_Click(object sender, EventArgs e)
        {
            ScanFolders(false);
        }

        private void onUpdateList_Click(object sender, EventArgs e)
        {
            ScanFolders(true);
        }
        
        private void onNewFileList_Click(object sender, EventArgs e)
        {
            var input = "";
            TextInputForm textDialog = new TextInputForm();
            textDialog.label1.Text = "Enter blacklist word";
            if (textDialog.ShowDialog(this) == DialogResult.OK)
            {
                input = textDialog.textBox1.Text;
            }
            textDialog.Dispose();

            if (input == "")
            {
                return;
            }

            if (File.Exists(@"output\" + input + ".xml"))
            {
                MessageBox.Show($"File \"{input}.xml\" already exists", "New List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                programSettings.CurrentXMLFile = input;
                programSettings.Save();
                readList();
                saveList();
                readOutputFiles();
            }
        }

        //grid events
        private void onListSelection_Changed(object sender, EventArgs e)
        {
            try
            {
                var item = (ExecutableFile)((BrightIdeasSoftware.DataListView)sender).SelectedObject;

                setCurrentFile(item);
            }
            catch
            {
                setCurrentFile(null);
            }
        }

        private void olv1_FormatRow(Object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            e.ListView.RowHeight = 10;
        }
        
        private void olv1_FormatCell(Object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            ExecutableFile item = (ExecutableFile)e.Model;

            if (e.ColumnIndex == 0)
            {
                e.SubItem.Text = $"[{item.selectedFolder}]::{item.theFile}";
            }
            else if (e.ColumnIndex == 1)
            {
                e.SubItem.BackColor = item.hasRun ? Color.LightGreen : Color.LightPink;
                e.SubItem.Text = "";
            }
        }

        //functions
        private async void ScanFolders(bool update)
        {
            if (executableFiles.Count > 0 && !update)
            {
                var b = MessageBox.Show(
                    "Do you want to renew the files list? " + Environment.NewLine + Environment.NewLine + "Warning: This action will clear the existing list and replace it with a new one!",
                    "Renew List", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (b == DialogResult.No) return;
            }

            var foldersList = File.Exists("folders.txt") ? File.ReadAllLines("folders.txt").ToList() : new List<string>();

            if (!update)
                executableFiles = new List<ExecutableFile>();

            EnableControls(false);
            progressBar1.Visible = true;
            ProgressStatusLabel.Visible = true;

            foreach (var folder in foldersList)
            {
                if (update && executableFiles.Where(x => x.selectedFolder == folder).ToList().Count > 0)
                    continue;

                ProgressStatusLabel.Text = $"Scanning \"{folder}\"";
                var progress = new Progress<int>(value =>
                {
                    progressBar1.Value = value;
                });

                var exefiles = await Task.Run(() => GetAllSafeFiles(folder, progress, "*.exe"));
                executableFiles.AddRange(exefiles.Select(x => new ExecutableFile(x, folder)).ToList());
            }

            EnableControls(true);
            progressBar1.Visible = false;
            ProgressStatusLabel.Visible = false;

            saveList();
        }

        private void EnableControls(bool enabled)
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = enabled;
            }
        }

        private void filterByBlackList()
        {
            var blacklist = File.Exists("BlackList.txt") ? File.ReadAllLines("BlackList.txt").ToList() : new List<string>();
            executableFiles = executableFiles.Where((x) =>
            {
                for (int i = 0; i < blacklist.Count; i++)
                {
                    if (x.fullPath.ToUpper().Contains(blacklist[i].ToUpper()))
                        return false;
                }
                return true;
            }).ToList();
        }

        private void DeleteExeFromList()
        {
            var item = getCurrentObject();

            setCurrentFile(null);

            executableFiles = executableFiles.Where(x => x.fullPath != item.fullPath).ToList();
            saveList();
        }

        private void setCurrentFile(ExecutableFile item)
        {
            selectedLabel.Text = item == null ? "" : item.fullPath;

            button5.Enabled = item == null ? false : true;
            button6.Enabled = item == null ? false : true;

            //if (item == null) listBox1.SelectedIndex = 0;
            //else listBox1.SelectedIndex = executableFiles.IndexOf(executableFileCursor);
        }

        private void saveList()
        {
            var current = getCurrentObject();

            filterByBlackList();

            XDocument doc = new XDocument();
            doc.Add(new XElement("ExecutableFiles"));

            executableFiles.ForEach(x =>
            {
                XElement itemElement = new XElement("ExecutableFile");
                itemElement.Add(new XElement("hasRun", x.hasRun.ToString()));
                itemElement.Add(new XElement("fullPath", x.fullPath));
                itemElement.Add(new XElement("path", x.path));
                itemElement.Add(new XElement("theFile", x.theFile));
                itemElement.Add(new XElement("selectedFolder", x.selectedFolder));
                doc.Element("ExecutableFiles").Add(itemElement);
            });
            if (!Directory.Exists(@"output")) Directory.CreateDirectory(@"output\");

            doc.Save(@"output\" + programSettings.CurrentXMLFile + ".xml");
            dataList.DataSource = new List<ExecutableFile>();
            dataList.DataSource = executableFiles;
            listCountLabel.Text = executableFiles.Count.ToString();

            try
            {
                setCurrentObject(current);
            }
            catch { }
        }

        private void readList()
        {
            setCurrentFile(null);

            if (programSettings.CurrentXMLFile == null) return;

            XDocument doc = new XDocument();
            if (File.Exists(@"output\" + programSettings.CurrentXMLFile + ".xml"))
                doc = XDocument.Load(@"output\" + programSettings.CurrentXMLFile + ".xml");

            executableFiles = doc.Elements("ExecutableFiles").Elements("ExecutableFile")
                .Select(x =>
                {
                    return new ExecutableFile
                    {
                        hasRun = x.Element("hasRun").Value == true.ToString(),
                        fullPath = x.Element("fullPath").Value,
                        path = x.Element("path").Value,
                        theFile = x.Element("theFile").Value,
                        selectedFolder = x.Element("selectedFolder").Value
                    };
                }).ToList();
            dataList.DataSource = executableFiles;
            listCountLabel.Text = executableFiles.Count.ToString();

            Text = $"Execute Random From Directory [{programSettings.CurrentXMLFile + ".xml"}]";
        }

        private void readSettings()
        {
            programSettings = ProgramSettings.Read();
        }

        private void readOutputFiles()
        {
            try
            {
                var XmlFiles = Directory.GetFiles(@"output\", "*.xml");

                foreach (var file in XmlFiles)
                {
                    if (listToolStripMenuItem.DropDownItems.IndexOf(listToolStripMenuItem.DropDownItems[Path.GetFileName(file)]) > -1)
                        listToolStripMenuItem.DropDownItems.Remove(listToolStripMenuItem.DropDownItems[Path.GetFileName(file)]);

                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = Path.GetFileName(file);
                    item.Name = Path.GetFileName(file);
                    item.Tag = "XML_FILE";
                    item.Checked = programSettings.CurrentXMLFile == Path.GetFileName(file).Replace(".xml", "");
                    item.Click += new EventHandler(xmlItemChangedHandler);

                    this.listToolStripMenuItem.DropDownItems.Add(item);
                }

            }
            catch { }
        }

        private void xmlItemChangedHandler(object sender, EventArgs e)
        {
            for (var i = 0; i < listToolStripMenuItem.DropDownItems.Count; i++)
            {
                try
                {
                    ((ToolStripMenuItem)listToolStripMenuItem.DropDownItems[i]).Checked = false;
                }
                catch { }
            }

            var item = (ToolStripMenuItem)sender;
            item.Checked = true;

            programSettings.CurrentXMLFile = item.Text.Replace(".xml", "");
            programSettings.Save();
            readList();
        }
    }
}