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

namespace ExecuteRandomFromDirWithGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
                        List<string> exeList = File.ReadAllLines("output.txt").ToList();

                        exeList.AddRange(exefiles);
                        File.WriteAllLines("output.txt", exeList);
                        listBox1.DataSource = exeList;
                    }
                    else
                    {
                        File.WriteAllLines("output.txt", exefiles);
                        listBox1.DataSource = exefiles;
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

        private void button1_Click(object sender, EventArgs e)
        {
            createList(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            createList(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("output.txt"))
            {
                var exeList = File.ReadAllLines("output.txt").ToList();
                int index = new Random().Next(exeList.Count);

                setSelectedItem(exeList[index]);
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
            if (File.Exists("output.txt")) {
                List<string> exeList = File.ReadAllLines("output.txt").ToList();
                listBox1.DataSource = exeList;
            }        
        }

        private void setSelectedItem(string item) {
            selectedLabel.Text = item;

            button5.Enabled = item == "" ? false : true;
            button6.Enabled = item == "" ? false : true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try {
                StartProcess();
            }
            catch (Exception ex) {
                var b = MessageBox.Show("Run application", ex.Message + " Delete?", MessageBoxButtons.YesNo);

                if (b == DialogResult.Yes) {
                    DeleteExeFromList();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteExeFromList();
        }

        void StartProcess()
        {
            var item = selectedLabel.Text;

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = item;
            processInfo.WorkingDirectory = Path.GetDirectoryName(item);
            processInfo.ErrorDialog = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = false;
            processInfo.RedirectStandardError = false;
            System.Diagnostics.Process.Start(processInfo);
        }

        void DeleteExeFromList()
        {
            var item = selectedLabel.Text;
            setSelectedItem("");
            var exeList = File.ReadAllLines("output.txt").ToList();
            var list = exeList.Where(x => x != item).ToList();
            listBox1.DataSource = list;

            File.WriteAllLines("output.txt", list);
        }

        private void button4_Click(object sender, EventArgs e)
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

            if (input == "") {
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
                var exeFiles = File.ReadAllLines("output.txt").ToList();

                exeFiles = exeFiles.Where((x) =>
                {
                    for (int i = 0; i < BlackList.Count; i++)
                    {
                        if (x.ToUpper().Contains(BlackList[i].ToUpper())) return false;
                    }
                    return true;
                }).ToList();

                File.WriteAllLines("BlackList.txt", BlackList);
                File.WriteAllLines("output.txt", exeFiles);
                listBox1.DataSource = exeFiles;
            }
        }
    }
}
