using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
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

        void createList(Boolean add)
        {
            var foldersList = File.Exists("folders.txt") ? File.ReadAllLines("folders.txt").ToList() : new List<string>();

            using (FolderBrowserDialog mainFolder = new FolderBrowserDialog())
            {
                DialogResult result = mainFolder.ShowDialog();

                if (add && foldersList.IndexOf(mainFolder.SelectedPath) > -1)
                {
                    MessageBox.Show($"path \"{mainFolder.SelectedPath}\" already exists");
                    return;
                }

                if (result == DialogResult.OK)
                {
                    if (add)
                    {
                        foldersList.Add(mainFolder.SelectedPath);
                        File.WriteAllLines("folders.txt", foldersList);
                    }
                    else File.WriteAllText("folders.txt", mainFolder.SelectedPath);

                    string[] exefiles = GetAllSafeFiles(mainFolder.SelectedPath, "*.exe");

                    if (add)
                        foreach (var exeFile in exefiles) 
                        {
                            executableFiles.Add(new ExecutableFile(exeFile));
                        }
                    else
                        executableFiles = exefiles.Select(x => new ExecutableFile(x)).ToList();

                    filterByBlackList();
                    saveList();
                }
            }
        }
        public static string[] GetAllSafeFiles(string path, string searchPattern = "*.*")
        {
            List<string> allFiles = new List<string>();
            string[] root = Directory.GetFiles(path, searchPattern);
            allFiles.AddRange(root);

            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                try
                {
                    if (!IsIgnorable(folder))
                    {
                        allFiles.AddRange(Directory.GetFiles(folder, searchPattern, SearchOption.AllDirectories));
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
                doc.Element("ExecutableFiles").Add(itemElement);
            });         
            doc.Save(output);
            listBox1.DataSource = new List<ExecutableFile>();
            listBox1.DataSource = executableFiles;
            listCountLabel.Text = executableFiles.Count.ToString();
        }

        private void readList() {
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
                        theFile = x.Element("theFile").Value
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
            DeleteExeFromList();
        }

        void DeleteExeFromList()
        {
            //var item = selectedLabel.Text;
            var item = executableFileCursor;
            
            setCurrentFile(null);

            executableFiles = executableFiles.Where(x => x.fullPath != item.fullPath).ToList();
            saveList();
            //var exeList = File.ReadAllLines("output.txt").ToList();
            //var list = exeList.Where(x => x != item).ToList();
            //listBox1.DataSource = list;

            //File.WriteAllLines("output.txt", list);
        }

        private void newListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createList(false);
        }

        private void addToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createList(true);
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
                int index = new Random().Next(tmpList.Count);
                setCurrentFile(tmpList[index]);
            }
            else
            {
                MessageBox.Show("File list not found");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;

            var item = executableFiles[listBox1.SelectedIndex];
            setCurrentFile(item);
        }
    }
}