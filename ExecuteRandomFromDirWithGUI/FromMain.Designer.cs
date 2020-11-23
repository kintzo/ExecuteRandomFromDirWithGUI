namespace ExecuteRandomFromDirWithGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToBlacklistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smth_new = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listCountLabel = new System.Windows.Forms.Label();
            this.Separator = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(511, 107);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 27);
            this.button3.TabIndex = 2;
            this.button3.Text = "Select Random";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(13, 40);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(490, 319);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(13, 375);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected Executable:";
            // 
            // selectedLabel
            // 
            this.selectedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.selectedLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedLabel.ForeColor = System.Drawing.Color.White;
            this.selectedLabel.Location = new System.Drawing.Point(14, 392);
            this.selectedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(598, 17);
            this.selectedLabel.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(511, 140);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 27);
            this.button5.TabIndex = 7;
            this.button5.Text = "Run Selected";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(511, 332);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 27);
            this.button6.TabIndex = 8;
            this.button6.Text = "Delete Selected";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.listToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.listToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foldersToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToBlacklistToolStripMenuItem});
            this.listToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.listToolStripMenuItem.Text = "List";
            // 
            // foldersToolStripMenuItem
            // 
            this.foldersToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.foldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.renewToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.foldersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.foldersToolStripMenuItem.Name = "foldersToolStripMenuItem";
            this.foldersToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.foldersToolStripMenuItem.Text = "Folders";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.editToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.editToolStripMenuItem.Text = "Edit Folders";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // renewToolStripMenuItem
            // 
            this.renewToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.renewToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.renewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.renewToolStripMenuItem.Name = "renewToolStripMenuItem";
            this.renewToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.renewToolStripMenuItem.Text = "Renew";
            this.renewToolStripMenuItem.Click += new System.EventHandler(this.renewToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.updateToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.updateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // addToBlacklistToolStripMenuItem
            // 
            this.addToBlacklistToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.addToBlacklistToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addToBlacklistToolStripMenuItem.Name = "addToBlacklistToolStripMenuItem";
            this.addToBlacklistToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToBlacklistToolStripMenuItem.Text = "Blacklist";
            this.addToBlacklistToolStripMenuItem.Click += new System.EventHandler(this.addToBlacklistToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.aboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // smth_new
            // 
            this.smth_new.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.smth_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.smth_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.smth_new.Cursor = System.Windows.Forms.Cursors.Default;
            this.smth_new.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.smth_new.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.smth_new.ForeColor = System.Drawing.Color.Black;
            this.smth_new.Location = new System.Drawing.Point(511, 211);
            this.smth_new.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.smth_new.Name = "smth_new";
            this.smth_new.Size = new System.Drawing.Size(107, 54);
            this.smth_new.TabIndex = 10;
            this.smth_new.Text = "SELECT SOMETHING NEW";
            this.smth_new.UseVisualStyleBackColor = false;
            this.smth_new.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(505, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "List Items Count:";
            // 
            // listCountLabel
            // 
            this.listCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listCountLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listCountLabel.Location = new System.Drawing.Point(511, 56);
            this.listCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.listCountLabel.Name = "listCountLabel";
            this.listCountLabel.Size = new System.Drawing.Size(107, 48);
            this.listCountLabel.TabIndex = 12;
            this.listCountLabel.Text = "0";
            this.listCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Separator
            // 
            this.Separator.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Separator.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Separator.Location = new System.Drawing.Point(13, 368);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(605, 2);
            this.Separator.TabIndex = 13;
            this.Separator.Text = "label3";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 436);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(624, 23);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Visible = false;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.ForeColor = System.Drawing.Color.White;
            this.ProgressLabel.Location = new System.Drawing.Point(14, 414);
            this.ProgressLabel.MaximumSize = new System.Drawing.Size(640, 0);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(598, 27);
            this.ProgressLabel.TabIndex = 15;
            this.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Separator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.smth_new);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.selectedLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listCountLabel);
            this.Controls.Add(this.ProgressLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Execute Random From Directory";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label selectedLabel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToBlacklistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button smth_new;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label listCountLabel;
        private System.Windows.Forms.ToolStripMenuItem foldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label Separator;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ProgressLabel;
    }
}

