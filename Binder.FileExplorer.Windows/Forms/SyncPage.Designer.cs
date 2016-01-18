namespace Binder.Windows.FileExplorer
{
	partial class SyncPage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncPage));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.localList = new System.Windows.Forms.ListView();
			this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.binderList = new System.Windows.Forms.ListView();
			this.name1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.type1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.size1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lastModified1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button2 = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.browseButton = new System.Windows.Forms.Button();
			this.directoryBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.downloadMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFile = new System.Windows.Forms.SaveFileDialog();
			this.miniLog = new System.Windows.Forms.TextBox();
			this.openFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.contextMenu.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.localList, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.binderList, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.button2, 0, 0);
			this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 488);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// localList
			// 
			this.localList.AllowDrop = true;
			this.localList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.type,
            this.size,
            this.lastModified});
			this.localList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.localList.Location = new System.Drawing.Point(495, 38);
			this.localList.Name = "localList";
			this.localList.Size = new System.Drawing.Size(481, 442);
			this.localList.SmallImageList = this.imageList1;
			this.localList.TabIndex = 1;
			this.localList.UseCompatibleStateImageBehavior = false;
			this.localList.View = System.Windows.Forms.View.Details;
			this.localList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.localList_ItemDrag);
			this.localList.DragDrop += new System.Windows.Forms.DragEventHandler(this.localList_DragDrop);
			this.localList.DragEnter += new System.Windows.Forms.DragEventHandler(this.localList_DragEnter);
			this.localList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.localList_MouseDoubleClick);
			// 
			// name
			// 
			this.name.Text = "Name";
			this.name.Width = 238;
			// 
			// type
			// 
			this.type.Text = "Type";
			// 
			// size
			// 
			this.size.Text = "Size";
			// 
			// lastModified
			// 
			this.lastModified.Text = "Last Modified";
			this.lastModified.Width = 83;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "folder.png");
			this.imageList1.Images.SetKeyName(1, "pTEy9.png");
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(921, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(55, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "Up";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// binderList
			// 
			this.binderList.AllowDrop = true;
			this.binderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name1,
            this.type1,
            this.size1,
            this.lastModified1});
			this.binderList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.binderList.ForeColor = System.Drawing.SystemColors.WindowText;
			this.binderList.Location = new System.Drawing.Point(8, 38);
			this.binderList.Name = "binderList";
			this.binderList.Size = new System.Drawing.Size(481, 442);
			this.binderList.SmallImageList = this.imageList1;
			this.binderList.TabIndex = 3;
			this.binderList.UseCompatibleStateImageBehavior = false;
			this.binderList.View = System.Windows.Forms.View.Details;
			this.binderList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.binderList_ItemDrag);
			this.binderList.DragDrop += new System.Windows.Forms.DragEventHandler(this.binderList_DragDrop);
			this.binderList.DragEnter += new System.Windows.Forms.DragEventHandler(this.binderList_DragEnter);
			this.binderList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.binderList_MouseDoubleClick);
			// 
			// name1
			// 
			this.name1.Text = "Name";
			this.name1.Width = 222;
			// 
			// type1
			// 
			this.type1.Text = "Type";
			// 
			// size1
			// 
			this.size1.Text = "Size";
			// 
			// lastModified1
			// 
			this.lastModified1.Text = "Last Modified";
			this.lastModified1.Width = 81;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(8, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(55, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = "Up";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.progressBar1.Location = new System.Drawing.Point(102, 521);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(387, 23);
			this.progressBar1.TabIndex = 5;
			// 
			// browseButton
			// 
			this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.browseButton.Location = new System.Drawing.Point(852, 549);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(120, 23);
			this.browseButton.TabIndex = 6;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// directoryBox
			// 
			this.directoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.directoryBox.Location = new System.Drawing.Point(569, 551);
			this.directoryBox.Name = "directoryBox";
			this.directoryBox.Size = new System.Drawing.Size(277, 20);
			this.directoryBox.TabIndex = 7;
			this.directoryBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.directoryBox_KeyPress);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(515, 554);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Location";
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadMenu,
            this.deleteToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(129, 48);
			// 
			// downloadMenu
			// 
			this.downloadMenu.Name = "downloadMenu";
			this.downloadMenu.Size = new System.Drawing.Size(128, 22);
			this.downloadMenu.Text = "Download";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// saveFile
			// 
			this.saveFile.FileName = "test.file";
			this.saveFile.Filter = "All files|*.*";
			// 
			// miniLog
			// 
			this.miniLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.miniLog.Location = new System.Drawing.Point(12, 551);
			this.miniLog.Name = "miniLog";
			this.miniLog.ReadOnly = true;
			this.miniLog.Size = new System.Drawing.Size(477, 20);
			this.miniLog.TabIndex = 9;
			this.miniLog.Text = "Ready.";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Location = new System.Drawing.Point(12, 521);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(84, 23);
			this.button3.TabIndex = 10;
			this.button3.Text = "Select site";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(852, 520);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 23);
			this.button4.TabIndex = 11;
			this.button4.Text = "Refresh directories";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(984, 24);
			this.menuStrip1.TabIndex = 12;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSiteToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// selectSiteToolStripMenuItem
			// 
			this.selectSiteToolStripMenuItem.Name = "selectSiteToolStripMenuItem";
			this.selectSiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.selectSiteToolStripMenuItem.Text = "Select site";
			this.selectSiteToolStripMenuItem.Click += new System.EventHandler(this.selectSiteToolStripMenuItem_Click);
			// 
			// signOutToolStripMenuItem
			// 
			this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
			this.signOutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.signOutToolStripMenuItem.Text = "Sign out";
			this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// SyncPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 584);
			this.ControlBox = false;
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.miniLog);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.directoryBox);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(1000, 600);
			this.Name = "SyncPage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "File Synchronisation";
			this.Load += new System.EventHandler(this.SyncPage_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.contextMenu.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.TextBox directoryBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem downloadMenu;
		private System.Windows.Forms.SaveFileDialog saveFile;
		private System.Windows.Forms.TextBox miniLog;
		private System.Windows.Forms.FolderBrowserDialog openFolder;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ListView localList;
		private System.Windows.Forms.ColumnHeader name;
		private System.Windows.Forms.ColumnHeader type;
		private System.Windows.Forms.ColumnHeader lastModified;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ColumnHeader size;
		private System.Windows.Forms.ListView binderList;
		private System.Windows.Forms.ColumnHeader name1;
		private System.Windows.Forms.ColumnHeader type1;
		private System.Windows.Forms.ColumnHeader size1;
		private System.Windows.Forms.ColumnHeader lastModified1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectSiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

	}
}