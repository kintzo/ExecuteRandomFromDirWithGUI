using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            using (FolderBrowserDialog mainFolder = new FolderBrowserDialog())
            {
                DialogResult result = mainFolder.ShowDialog();

                if (FolderList.IndexOf(mainFolder.SelectedPath) > -1)
                {
                    MessageBox.Show($"path \"{mainFolder.SelectedPath}\" already exists");
                    return;
                }

                if (result == DialogResult.OK)
                {
                    FolderList.Add(mainFolder.SelectedPath);
                    File.WriteAllLines("folders.txt", FolderList);

                    listBox1.DataSource = new List<string>();
                    listBox1.DataSource = FolderList;
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
