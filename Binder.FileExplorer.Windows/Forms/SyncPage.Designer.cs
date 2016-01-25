using System.Threading.Tasks;
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
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.newFolder = new System.Windows.Forms.Button();
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
			this.button4 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSiteInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelTransfer = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
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
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 467);
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
			this.localList.Size = new System.Drawing.Size(481, 421);
			this.localList.SmallImageList = this.imageList1;
			this.localList.TabIndex = 4;
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
			this.button1.Location = new System.Drawing.Point(921, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(55, 24);
			this.button1.TabIndex = 3;
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
			this.binderList.Size = new System.Drawing.Size(481, 421);
			this.binderList.SmallImageList = this.imageList1;
			this.binderList.TabIndex = 2;
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
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
			this.tableLayoutPanel2.Controls.Add(this.button2, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.newFolder, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(487, 30);
			this.tableLayoutPanel2.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(3, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(55, 24);
			this.button2.TabIndex = 0;
			this.button2.Text = "Up";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(393, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 22);
			this.label1.TabIndex = 6;
			this.label1.Text = "Read only";
			this.label1.Visible = false;
			// 
			// newFolder
			// 
			this.newFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.newFolder.Location = new System.Drawing.Point(64, 3);
			this.newFolder.Name = "newFolder";
			this.newFolder.Size = new System.Drawing.Size(75, 24);
			this.newFolder.TabIndex = 1;
			this.newFolder.Text = "New Folder";
			this.newFolder.UseVisualStyleBackColor = true;
			this.newFolder.Click += new System.EventHandler(this.newFolder_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.progressBar1.Location = new System.Drawing.Point(12, 500);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(399, 23);
			this.progressBar1.TabIndex = 5;
			// 
			// browseButton
			// 
			this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.browseButton.Location = new System.Drawing.Point(852, 528);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(120, 23);
			this.browseButton.TabIndex = 8;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// directoryBox
			// 
			this.directoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.directoryBox.Location = new System.Drawing.Point(569, 530);
			this.directoryBox.Name = "directoryBox";
			this.directoryBox.Size = new System.Drawing.Size(277, 20);
			this.directoryBox.TabIndex = 6;
			this.directoryBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.directoryBox_KeyPress);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(515, 533);
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
			this.miniLog.Location = new System.Drawing.Point(12, 530);
			this.miniLog.Name = "miniLog";
			this.miniLog.ReadOnly = true;
			this.miniLog.Size = new System.Drawing.Size(477, 20);
			this.miniLog.TabIndex = 5;
			this.miniLog.Text = "Ready.";
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(852, 499);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 23);
			this.button4.TabIndex = 7;
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
            this.openSiteInBrowserToolStripMenuItem,
            this.selectSiteToolStripMenuItem,
            this.signOutToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.ShortcutKeyDisplayString = "F";
			this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openSiteInBrowserToolStripMenuItem
			// 
			this.openSiteInBrowserToolStripMenuItem.Name = "openSiteInBrowserToolStripMenuItem";
			this.openSiteInBrowserToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.openSiteInBrowserToolStripMenuItem.Text = "Open site in browser";
			this.openSiteInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openSiteInBrowserToolStripMenuItem_Click);
			// 
			// selectSiteToolStripMenuItem
			// 
			this.selectSiteToolStripMenuItem.Name = "selectSiteToolStripMenuItem";
			this.selectSiteToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.selectSiteToolStripMenuItem.Text = "Select site";
			this.selectSiteToolStripMenuItem.Click += new System.EventHandler(this.selectSiteToolStripMenuItem_Click);
			// 
			// signOutToolStripMenuItem
			// 
			this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
			this.signOutToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.signOutToolStripMenuItem.Text = "Sign out";
			this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// cancelTransfer
			// 
			this.cancelTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cancelTransfer.Location = new System.Drawing.Point(417, 499);
			this.cancelTransfer.Name = "cancelTransfer";
			this.cancelTransfer.Size = new System.Drawing.Size(75, 23);
			this.cancelTransfer.TabIndex = 13;
			this.cancelTransfer.Text = "Cancel";
			this.cancelTransfer.UseVisualStyleBackColor = true;
			this.cancelTransfer.Click += new System.EventHandler(this.cancelTransfer_Click);
			// 
			// SyncPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 584);
			this.Controls.Add(this.cancelTransfer);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.miniLog);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.directoryBox);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(1000, 600);
			this.Name = "SyncPage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "File Management";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SyncPage_FormClosing);
			this.Load += new System.EventHandler(this.SyncPage_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
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
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectSiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button newFolder;
		private System.Windows.Forms.Button cancelTransfer;
		private System.Windows.Forms.ToolStripMenuItem openSiteInBrowserToolStripMenuItem;

	}
}