using System;
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
