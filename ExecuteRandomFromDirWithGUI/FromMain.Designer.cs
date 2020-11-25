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
            this.dataList = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.BlacklistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smth_new = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listCountLabel = new System.Windows.Forms.Label();
            this.Separator = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(438, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Select Random";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.onRandom_Click);
            // 
            // dataList
            // 
            this.dataList.AutoGenerateColumns = false;
            this.dataList.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.dataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2});
            this.dataList.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataList.DataSource = null;
            this.dataList.ForeColor = System.Drawing.Color.White;
            this.dataList.FullRowSelect = true;
            this.dataList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.dataList.HideSelection = false;
            this.dataList.Location = new System.Drawing.Point(11, 22);
            this.dataList.Name = "dataList";
            this.dataList.ShowGroups = false;
            this.dataList.Size = new System.Drawing.Size(421, 290);
            this.dataList.TabIndex = 4;
            this.dataList.UseCellFormatEvents = true;
            this.dataList.UseCompatibleStateImageBehavior = false;
            this.dataList.View = System.Windows.Forms.View.Details;
            this.dataList.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.olv1_FormatCell);
            this.dataList.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olv1_FormatRow);
            this.dataList.SelectionChanged += new System.EventHandler(this.onListSelection_Changed);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "theFile";
            this.olvColumn1.MaximumWidth = 380;
            this.olvColumn1.MinimumWidth = 380;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.Width = 380;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "hasRun";
            this.olvColumn2.MaximumWidth = 20;
            this.olvColumn2.MinimumWidth = 20;
            this.olvColumn2.Text = "";
            this.olvColumn2.ToolTipText = "Has Run";
            this.olvColumn2.Width = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(11, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected Executable:";
            // 
            // selectedLabel
            // 
            this.selectedLabel.BackColor = System.Drawing.Color.Transparent;
            this.selectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.selectedLabel.ForeColor = System.Drawing.Color.White;
            this.selectedLabel.Location = new System.Drawing.Point(15, 339);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(513, 42);
            this.selectedLabel.TabIndex = 6;
            this.selectedLabel.Text = "---";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(438, 114);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Run Selected";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.onRunSelected_Click);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(438, 288);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Delete Selected";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.onDeleteSelected_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(535, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.listToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.listToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foldersToolStripMenuItem,
            this.BlacklistToolStripMenuItem,
            this.toolStripSeparator1,
            this.newListToolStripMenuItem,
            this.toolStripSeparator2});
            this.listToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.listToolStripMenuItem.Text = "List";
            // 
            // foldersToolStripMenuItem
            // 
            this.foldersToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.foldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.renewToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.foldersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.foldersToolStripMenuItem.Name = "foldersToolStripMenuItem";
            this.foldersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.foldersToolStripMenuItem.Tag = "MTBI";
            this.foldersToolStripMenuItem.Text = "Folders";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.editToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit Folders";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.onOpenFolders_Click);
            // 
            // renewToolStripMenuItem
            // 
            this.renewToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.renewToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.renewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.renewToolStripMenuItem.Name = "renewToolStripMenuItem";
            this.renewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renewToolStripMenuItem.Text = "Renew";
            this.renewToolStripMenuItem.Click += new System.EventHandler(this.onRenewList_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.updateToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.updateToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.onUpdateList_Click);
            // 
            // BlacklistToolStripMenuItem
            // 
            this.BlacklistToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.BlacklistToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BlacklistToolStripMenuItem.Name = "BlacklistToolStripMenuItem";
            this.BlacklistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BlacklistToolStripMenuItem.Tag = "MTBI";
            this.BlacklistToolStripMenuItem.Text = "Blacklist";
            this.BlacklistToolStripMenuItem.Click += new System.EventHandler(this.onOpenBlackList_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            this.toolStripSeparator1.Tag = "MTBI";
            // 
            // newListToolStripMenuItem
            // 
            this.newListToolStripMenuItem.Name = "newListToolStripMenuItem";
            this.newListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newListToolStripMenuItem.Tag = "MTBI";
            this.newListToolStripMenuItem.Text = "new List";
            this.newListToolStripMenuItem.Click += new System.EventHandler(this.onNewFileList_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.aboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.onAbout_Click);
            // 
            // smth_new
            // 
            this.smth_new.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.smth_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.smth_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.smth_new.Cursor = System.Windows.Forms.Cursors.Default;
            this.smth_new.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.smth_new.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.smth_new.ForeColor = System.Drawing.Color.Black;
            this.smth_new.Location = new System.Drawing.Point(438, 176);
            this.smth_new.Name = "smth_new";
            this.smth_new.Size = new System.Drawing.Size(92, 53);
            this.smth_new.TabIndex = 10;
            this.smth_new.Text = "SELECT SOMETHING NEW";
            this.smth_new.UseVisualStyleBackColor = false;
            this.smth_new.Click += new System.EventHandler(this.onNewRandom_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(438, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 33);
            this.label2.TabIndex = 11;
            this.label2.Text = "List Items Count:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listCountLabel
            // 
            this.listCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.listCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCountLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listCountLabel.Location = new System.Drawing.Point(438, 55);
            this.listCountLabel.Name = "listCountLabel";
            this.listCountLabel.Size = new System.Drawing.Size(92, 28);
            this.listCountLabel.TabIndex = 12;
            this.listCountLabel.Text = "0";
            this.listCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Separator
            // 
            this.Separator.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Separator.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Separator.Location = new System.Drawing.Point(11, 319);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(519, 2);
            this.Separator.TabIndex = 13;
            this.Separator.Text = "label3";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 378);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(535, 20);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Visible = false;
            // 
            // ProgressStatusLabel
            // 
            this.ProgressStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProgressStatusLabel.ForeColor = System.Drawing.Color.White;
            this.ProgressStatusLabel.Location = new System.Drawing.Point(15, 358);
            this.ProgressStatusLabel.Name = "ProgressStatusLabel";
            this.ProgressStatusLabel.Size = new System.Drawing.Size(513, 23);
            this.ProgressStatusLabel.TabIndex = 16;
            this.ProgressStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgressStatusLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(535, 382);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ProgressStatusLabel);
            this.Controls.Add(this.Separator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.smth_new);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listCountLabel);
            this.Controls.Add(this.selectedLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Execute Random From Directory";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private BrightIdeasSoftware.DataListView dataList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label selectedLabel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlacklistToolStripMenuItem;
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
        private System.Windows.Forms.Label ProgressStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem newListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
    }
}

