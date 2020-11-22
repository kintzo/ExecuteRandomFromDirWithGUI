using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Net.Http.Headers;
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
                    //Console.Clear();
                    //Console.WriteLine();
                    //Console.ReadLine();
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
                    {
                        //List<string> exeList = File.ReadAllLines("output.txt").ToList();

                        //exeList.AddRange(exefiles);
                        //File.WriteAllLines("output.txt", exeList);
                        //listBox1.DataSource = exeList;

                        executableFiles.AddRange(exefiles.Select(x => new ExecutableFile(x)).ToList());

                        saveList();
                    }
                    else
                    {
                        //File.WriteAllLines("output.txt", exefiles);
                        //listBox1.DataSource = exefiles;

                        executableFiles = exefiles.Select(x => new ExecutableFile(x)).ToList();
                        saveList();
                    }

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
                catch { } // Don't know what the problem is, don't care...
            }

            var blacklist = File.Exists("BlackList.txt") ? File.ReadAllLines("BlackList.txt").ToList() : new List<string>();
            allFiles = allFiles.Where((x) =>
            {
                for (int i = 0; i < blacklist.Count; i++)
                {
                    if (x.ToUpper().Contains(blacklist[i].ToUpper())) return false;
                }
                return true;
            }).ToList();

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
            //if (File.Exists("output.txt"))
            if (executableFiles.Count > 0)
            {
                var tmpList = executableFiles.Where(x => !x.hasRun).ToList();

                //var exeList = File.ReadAllLines("output.txt").ToList();
                int index = new Random().Next(tmpList.Count);

                setCurrentFile(tmpList[index]);
                //manageExe(exeList, index);
            }
            else
            {
                //Console.Clear();
                //Console.WriteLine("File list not found");
                //Console.ReadLine();
                MessageBox.Show("File list not found");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*if (File.Exists("output.txt"))
            {
                List<string> exeList = File.ReadAllLines("output.txt").ToList();
                listBox1.DataSource = exeList;
            }*/
            readList();           
        }

        private void saveList() 
        {
            string output = "output.xml";
/*
            XmlSerializer serialiser = new XmlSerializer(typeof(List<ExecutableFile>));
            TextWriter FileStream = new StreamWriter(output);
            serialiser.Serialize(FileStream, executableFiles);
            FileStream.Close();*/

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
            listBox1.DataSource = executableFiles;
        }

        private void readList() {
            string output = "output.xml";

            if (!File.Exists(output)) return;

            /*XmlSerializer serialiser = new XmlSerializer(typeof(ExecutableFile));
            List<ExecutableFile> myList = (List<ExecutableFile>)serialiser.Deserialize(new StreamReader(output));
            executableFiles = myList;*/

            XDocument doc = XDocument.Load(output);

            executableFiles = doc.Elements("ExecutableFiles").Elements("ExecutableFile")
                .Select(x => 
                {
                    return new ExecutableFile
                    {
                        hasRun = x.Element("hasRun").Value == "true",
                        fullPath = x.Element("fullPath").Value,
                        path = x.Element("path").Value,
                        theFile = x.Element("theFile").Value
                    };
                }).ToList();
            listBox1.DataSource = executableFiles;
        }

        private void setCurrentFile(ExecutableFile item)
        {
            selectedLabel.Text = item == null ? "" : item.ToString();

            button5.Enabled = item == null ? false : true;
            button6.Enabled = item == null ? false : true;

            executableFileCursor = item;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (executableFileCursor == null) return;

            try
            {
                //StartProcess();
                executableFileCursor.Execute();

                var idx = executableFiles.IndexOf(executableFileCursor);
                executableFiles[idx].hasRun = true;

                saveList();
            }
            catch (Exception ex)
            {
                var b = MessageBox.Show(ex.Message + " Delete?", "Run application", MessageBoxButtons.YesNo);

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

            executableFiles = executableFiles.Where(x => x.GetFullPath() != item.GetFullPath()).ToList();
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
            var BlackList = new List<string>();
            if (File.Exists("BlackList.txt")) BlackList = File.ReadAllLines("BlackList.txt").ToList();

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
                MessageBox.Show("invalid word");
                return;
            }

            if (BlackList.IndexOf(input) > -1)
            {
                MessageBox.Show($"\"{input}\" already exists in blacklist");
            }
            else
            {
                BlackList.Add(input);
                //var exeFiles = File.ReadAllLines("output.txt").ToList();

                executableFiles = executableFiles.Where((x) =>
                {
                    for (int i = 0; i < BlackList.Count; i++)
                    {
                        if (x.GetFullPath().ToUpper().Contains(BlackList[i].ToUpper())) return false;
                    }
                    return true;
                }).ToList();
                saveList();
                //File.WriteAllLines("BlackList.txt", BlackList);
                //File.WriteAllLines("output.txt", exeFiles);
                //listBox1.DataSource = exeFiles;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nigga = new About();
            nigga.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}