﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExecuteRandomFromDirWithGUI
{
    public partial class TextInputForm : Form
    {
        public TextInputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TextInputForm_Load(object sender, EventArgs e)
        {

        }
    }
}
