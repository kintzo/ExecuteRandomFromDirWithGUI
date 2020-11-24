using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExecuteRandomFromDirWithGUI
{
    public partial class FormBlackList : Form
    {
        public FormBlackList()
        {
            InitializeComponent();
        }

        List<string> BlackList = new List<string>();

        private void button1_Click(object sender, EventArgs e)
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

                listBox1.DataSource = new List<string>();
                listBox1.DataSource = BlackList;
                File.WriteAllLines("BlackList.txt", BlackList);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BlackList = BlackList.Where(x => x != listBox1.SelectedItem.ToString()).ToList();
            listBox1.DataSource = BlackList;
            File.WriteAllLines("BlackList.txt", BlackList);
        }

        private void FormBlackList_Load(object sender, EventArgs e)
        {
            if (File.Exists("BlackList.txt"))
            {
                BlackList = File.ReadAllLines("BlackList.txt").ToList();
                listBox1.DataSource = BlackList;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
