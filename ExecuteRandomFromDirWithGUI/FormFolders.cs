using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WK.Libraries.BetterFolderBrowserNS;

namespace ExecuteRandomFromDirWithGUI
{
    public partial class FormFolders : Form
    {
        public FormFolders()
        {
            InitializeComponent();
        }

        List<string> FolderList = new List<string>();

        private void FormFolders_Load(object sender, EventArgs e)
        {
            if (File.Exists("folders.txt"))
            {
                FolderList = File.ReadAllLines("folders.txt").ToList();
                listBox1.DataSource = FolderList;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BetterFolderBrowser betterFolderBrowser = new BetterFolderBrowser())
            {
                betterFolderBrowser.Multiselect = true;
                betterFolderBrowser.Title = "Select Folders";
                betterFolderBrowser.RootFolder = @"C:\";

                if (betterFolderBrowser.ShowDialog(this) == DialogResult.OK)
                {
                    var selected_folders = betterFolderBrowser.SelectedFolders;
                    FolderList.AddRange(selected_folders);

                    listBox1.DataSource = new List<string>();
                    listBox1.DataSource = FolderList;
                    File.WriteAllLines("folders.txt", FolderList);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderList = FolderList.Where(x => x != listBox1.SelectedItem.ToString()).ToList();
            File.WriteAllLines("folders.txt", FolderList);

            listBox1.DataSource = new List<string>();
            listBox1.DataSource = FolderList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
