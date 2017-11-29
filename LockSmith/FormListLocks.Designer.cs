namespace LockSmith
{
    partial class FormListLocks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListLocks));
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuStripForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderOpenMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderNumberOfLocks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListView1 = new System.Windows.Forms.ListView();
            this.ColumnHeaderUNC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStripListView.SuspendLayout();
            this.ContextMenuStripForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.AboutToolStripMenuItem.Text = "&About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ClearResultsToolStripMenuItem
            // 
            this.ClearResultsToolStripMenuItem.Name = "ClearResultsToolStripMenuItem";
            this.ClearResultsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.ClearResultsToolStripMenuItem.Text = "Clear &Results";
            this.ClearResultsToolStripMenuItem.Click += new System.EventHandler(this.ClearResultsToolStripMenuItem_Click);
            // 
            // ExportListToolStripMenuItem
            // 
            this.ExportListToolStripMenuItem.Name = "ExportListToolStripMenuItem";
            this.ExportListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.ExportListToolStripMenuItem.Text = "&Export List";
            this.ExportListToolStripMenuItem.Click += new System.EventHandler(this.ExportListToolStripMenuItem_Click);
            // 
            // ShowInExplorerToolStripMenuItem
            // 
            this.ShowInExplorerToolStripMenuItem.Name = "ShowInExplorerToolStripMenuItem";
            this.ShowInExplorerToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.ShowInExplorerToolStripMenuItem.Text = "&Show in Explorer";
            this.ShowInExplorerToolStripMenuItem.Click += new System.EventHandler(this.ShowInExplorerToolStripMenuItem_Click);
            // 
            // CloseFileToolStripMenuItem
            // 
            this.CloseFileToolStripMenuItem.Name = "CloseFileToolStripMenuItem";
            this.CloseFileToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.CloseFileToolStripMenuItem.Text = "&Close Selected Files";
            this.CloseFileToolStripMenuItem.Click += new System.EventHandler(this.CloseFileToolStripMenuItem_Click);
            // 
            // ContextMenuStripListView
            // 
            this.ContextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseFileToolStripMenuItem,
            this.ShowInExplorerToolStripMenuItem,
            this.ExportListToolStripMenuItem,
            this.ClearResultsToolStripMenuItem,
            this.refreshToolStripMenuItem1});
            this.ContextMenuStripListView.Name = "ContextMenuStrip1";
            this.ContextMenuStripListView.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ContextMenuStripListView.ShowImageMargin = false;
            this.ContextMenuStripListView.Size = new System.Drawing.Size(152, 114);
            this.ContextMenuStripListView.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripListView_Opening);
            // 
            // ContextMenuStripForm
            // 
            this.ContextMenuStripForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.ContextMenuStripForm.Name = "ContextMenuStripForm";
            this.ContextMenuStripForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ContextMenuStripForm.ShowImageMargin = false;
            this.ContextMenuStripForm.Size = new System.Drawing.Size(108, 48);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // ColumnHeaderID
            // 
            this.ColumnHeaderID.Tag = "Numeric";
            this.ColumnHeaderID.Text = "ID";
            this.ColumnHeaderID.Width = 0;
            // 
            // ColumnHeaderOpenMode
            // 
            this.ColumnHeaderOpenMode.Tag = "String";
            this.ColumnHeaderOpenMode.Text = "Open Mode";
            this.ColumnHeaderOpenMode.Width = 80;
            // 
            // ColumnHeaderNumberOfLocks
            // 
            this.ColumnHeaderNumberOfLocks.Tag = "Numeric";
            this.ColumnHeaderNumberOfLocks.Text = "# Locks";
            // 
            // ColumnHeaderUsername
            // 
            this.ColumnHeaderUsername.Tag = "String";
            this.ColumnHeaderUsername.Text = "User ID";
            // 
            // ColumnHeaderPath
            // 
            this.ColumnHeaderPath.Tag = "String";
            this.ColumnHeaderPath.Text = "Path";
            this.ColumnHeaderPath.Width = 300;
            // 
            // ListView1
            // 
            this.ListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderPath,
            this.ColumnHeaderUsername,
            this.ColumnHeaderNumberOfLocks,
            this.ColumnHeaderOpenMode,
            this.ColumnHeaderUNC,
            this.ColumnHeaderID});
            this.ListView1.ContextMenuStrip = this.ContextMenuStripListView;
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            this.ListView1.Location = new System.Drawing.Point(12, 66);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(588, 309);
            this.ListView1.TabIndex = 4;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeaderUNC
            // 
            this.ColumnHeaderUNC.Tag = "String";
            this.ColumnHeaderUNC.Text = "UNC";
            this.ColumnHeaderUNC.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&File:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(424, 20);
            this.textBox1.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(442, 24);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "&Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(523, 24);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "&Search (F5)";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.refreshToolStripMenuItem1.Text = "Re&fresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // FormListLocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 387);
            this.ContextMenuStrip = this.ContextMenuStripForm;
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(628, 426);
            this.Name = "FormListLocks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormListLocks";
            this.Load += new System.EventHandler(this.FormListLocks_Load);
            this.ContextMenuStripListView.ResumeLayout(false);
            this.ContextMenuStripForm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ClearResultsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExportListToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ShowInExplorerToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem CloseFileToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStripListView;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStripForm;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderID;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderOpenMode;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderNumberOfLocks;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderUsername;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderPath;
        internal System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.ColumnHeader ColumnHeaderUNC;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
    }
}