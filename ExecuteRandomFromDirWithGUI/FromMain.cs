using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ExecuteRandomFromDirWithGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private List<ExecutableFile> executableFiles = new List<ExecutableFile>();
        private ExecutableFile executableFileCursor;

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (executableFiles.Count > 0)
            {
                int index = new Random().Next(executableFiles.Count);
                setCurrentFile(executableFiles[index]);
            }
            else
            {
                MessageBox.Show("File list not found");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.ForeColor = System.Drawing.Color.White;
            readList();
        }

        private void saveList()
        {
            string output = "output.xml";

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
            doc.Save(output);
            listBox1.DataSource = new List<ExecutableFile>();
            listBox1.DataSource = executableFiles;
            listCountLabel.Text = executableFiles.Count.ToString();
        }

        private void readList()
        {
            string output = "output.xml";

            if (!File.Exists(output)) return;

            XDocument doc = XDocument.Load(output);

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
            listBox1.DataSource = executableFiles;
            listCountLabel.Text = executableFiles.Count.ToString();
        }

        private void setCurrentFile(ExecutableFile item)
        {
            selectedLabel.Text = item == null ? "" : item.fullPath;

            button5.Enabled = item == null ? false : true;
            button6.Enabled = item == null ? false : true;

            executableFileCursor = item;

            if (item == null) listBox1.ClearSelected();
            else listBox1.SelectedIndex = executableFiles.IndexOf(executableFileCursor);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (executableFileCursor == null) return;

            try
            {
                executableFileCursor.Execute();

                var idx = executableFiles.IndexOf(executableFileCursor);
                executableFiles[idx].hasRun = true;

                saveList();
            }
            catch (Exception ex)
            {
                var b = MessageBox.Show(ex.Message + System.Environment.NewLine + $"Delete path \"{executableFileCursor.fullPath}\"?", "Run application", MessageBoxButtons.YesNo);

                if (b == DialogResult.Yes)
                {
                    DeleteExeFromList();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var b = MessageBox.Show($"Remove Path: \"{executableFileCursor.fullPath}\" ?", $"Delete {executableFileCursor.theFile}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (b == DialogResult.Yes) DeleteExeFromList();
        }

        void DeleteExeFromList()
        {
            var item = executableFileCursor;

            setCurrentFile(null);

            executableFiles = executableFiles.Where(x => x.fullPath != item.fullPath).ToList();
            saveList();
        }

        private void addToBlacklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var blackListForm = new FormBlackList();
            if (blackListForm.ShowDialog(this) == DialogResult.OK)
            {
                filterByBlackList();
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

            saveList();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nigga = new About();
            nigga.Show();
        }

        private void button1_Click(object sender, EventArgs e)
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
                var lbIndex = listBox1.Items.IndexOf(tmpList[tmpIndex]);

                setCurrentFile((ExecutableFile)listBox1.Items[lbIndex]);
            }
            else
            {
                MessageBox.Show("File list not found");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var item = executableFiles[listBox1.SelectedIndex];
                setCurrentFile(item);
            }
            catch { }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var foldersListForm = new FormFolders();
            foldersListForm.Show();
        }

        private async void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var b = MessageBox.Show(
                "Do you want to renew the files list? " + Environment.NewLine + Environment.NewLine + "Warning: This action will clear the existing list and replace it with a new one!",
                "Renew List", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (b == DialogResult.No) return;

            var foldersList = File.Exists("folders.txt") ? File.ReadAllLines("folders.txt").ToList() : new List<string>();

            executableFiles = new List<ExecutableFile>();

            progressBar1.Visible = true;
            foreach (var folder in foldersList)
            {
                ProgressStatusLabel.Text = $"Scanning \"{folder}\"";
                var progress = new Progress<int>(value =>
                {
                    progressBar1.Value = value;
                });

                var exefiles = await Task.Run(() => GetAllSafeFiles(folder, progress, "*.exe"));
                executableFiles.AddRange(exefiles.Select(x => new ExecutableFile(x, folder)).ToList());
            }
            progressBar1.Visible = false;
            ProgressStatusLabel.Text = "";

            saveList();
        }

        private async void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var foldersList = File.Exists("folders.txt") ? File.ReadAllLines("folders.txt").ToList() : new List<string>();

            progressBar1.Visible = true;
            foreach (var folder in foldersList)
            {
                if (executableFiles.Where(x => x.selectedFolder == folder).ToList().Count > 0) continue;

                ProgressStatusLabel.Text = $"Scanning \"{folder}\"";
                var progress = new Progress<int>(value =>
                {
                    progressBar1.Value = value;
                });

                var exefiles = await Task.Run(() => GetAllSafeFiles(folder, progress, "*.exe"));

                executableFiles.AddRange(exefiles.Select(x => new ExecutableFile(x, folder)).ToList());
            }
            progressBar1.Visible = false;
            ProgressStatusLabel.Text = "";

            saveList();
        }
    }
}