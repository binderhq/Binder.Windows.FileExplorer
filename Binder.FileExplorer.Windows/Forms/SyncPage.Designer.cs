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
			this.binderList = new System.Windows.Forms.ListView();
			this.name1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.type1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.size1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lastModified1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.directoryBox = new System.Windows.Forms.TextBox();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
			this.binderBox = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.downloadMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFile = new System.Windows.Forms.SaveFileDialog();
			this.miniLog = new System.Windows.Forms.TextBox();
			this.openFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSiteInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelTransfer = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
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
			this.tableLayoutPanel1.Controls.Add(this.localList, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.binderList, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.binderBox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.toolStrip2, 1, 1);
			this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
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
			this.localList.Location = new System.Drawing.Point(495, 68);
			this.localList.Name = "localList";
			this.localList.Size = new System.Drawing.Size(481, 412);
			this.localList.SmallImageList = this.imageList1;
			this.localList.TabIndex = 4;
			this.localList.UseCompatibleStateImageBehavior = false;
			this.localList.View = System.Windows.Forms.View.Details;
			this.localList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.localList_ColumnClick);
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
			this.binderList.Location = new System.Drawing.Point(8, 68);
			this.binderList.Name = "binderList";
			this.binderList.Size = new System.Drawing.Size(481, 412);
			this.binderList.SmallImageList = this.imageList1;
			this.binderList.TabIndex = 2;
			this.binderList.UseCompatibleStateImageBehavior = false;
			this.binderList.View = System.Windows.Forms.View.Details;
			this.binderList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.binderList_ColumnClick);
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
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel4.Controls.Add(this.directoryBox, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.toolStrip3, 1, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(492, 5);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(487, 30);
			this.tableLayoutPanel4.TabIndex = 9;
			// 
			// directoryBox
			// 
			this.directoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.directoryBox.Location = new System.Drawing.Point(3, 3);
			this.directoryBox.Name = "directoryBox";
			this.directoryBox.Size = new System.Drawing.Size(456, 20);
			this.directoryBox.TabIndex = 6;
			this.directoryBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.directoryBox_KeyPress);
			// 
			// toolStrip3
			// 
			this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton11});
			this.toolStrip3.Location = new System.Drawing.Point(462, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip3.Size = new System.Drawing.Size(25, 25);
			this.toolStrip3.TabIndex = 7;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// toolStripButton11
			// 
			this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton11.Image = global::Binder.Windows.FileExplorer.Properties.Resources.folder_Open_32xLG;
			this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton11.Name = "toolStripButton11";
			this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton11.Text = "Browse";
			this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton11_Click);
			// 
			// binderBox
			// 
			this.binderBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.binderBox.Location = new System.Drawing.Point(8, 8);
			this.binderBox.Name = "binderBox";
			this.binderBox.Size = new System.Drawing.Size(481, 20);
			this.binderBox.TabIndex = 7;
			this.binderBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.binderBox_KeyPress);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton8,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator1,
            this.toolStripLabel1});
			this.toolStrip1.Location = new System.Drawing.Point(5, 35);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(487, 30);
			this.toolStrip1.TabIndex = 10;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = global::Binder.Windows.FileExplorer.Properties.Resources.refresh_16xLG;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton2.Text = "Refresh";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = global::Binder.Windows.FileExplorer.Properties.Resources.OneLevelUp_5834;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton3.Text = "Up one level";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton8
			// 
			this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton8.Image = global::Binder.Windows.FileExplorer.Properties.Resources.Rename;
			this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton8.Text = "Rename";
			this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = global::Binder.Windows.FileExplorer.Properties.Resources.Folder_special__5843_16x;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton5.Text = "New Folder";
			this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton6.Image = global::Binder.Windows.FileExplorer.Properties.Resources.delete;
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton6.Text = "Delete";
			this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(61, 27);
			this.toolStripLabel1.Text = "Read Only";
			this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStrip2
			// 
			this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripButton7,
            this.toolStripSeparator2});
			this.toolStrip2.Location = new System.Drawing.Point(492, 35);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip2.Size = new System.Drawing.Size(487, 30);
			this.toolStrip2.TabIndex = 11;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::Binder.Windows.FileExplorer.Properties.Resources.refresh_16xLG;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton1.Text = "Refresh";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = global::Binder.Windows.FileExplorer.Properties.Resources.OneLevelUp_5834;
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton4.Text = "Up one level";
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// toolStripButton9
			// 
			this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton9.Image = global::Binder.Windows.FileExplorer.Properties.Resources.Rename;
			this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton9.Name = "toolStripButton9";
			this.toolStripButton9.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton9.Text = "Rename";
			this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
			// 
			// toolStripButton10
			// 
			this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton10.Image = global::Binder.Windows.FileExplorer.Properties.Resources.Folder_special__5843_16x;
			this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton10.Name = "toolStripButton10";
			this.toolStripButton10.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton10.Text = "New Folder";
			this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton7.Image = global::Binder.Windows.FileExplorer.Properties.Resources.delete;
			this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.Size = new System.Drawing.Size(23, 27);
			this.toolStripButton7.Text = "Delete";
			this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(12, 524);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(834, 20);
			this.progressBar1.TabIndex = 5;
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
			this.miniLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.miniLog.Location = new System.Drawing.Point(12, 550);
			this.miniLog.Name = "miniLog";
			this.miniLog.ReadOnly = true;
			this.miniLog.Size = new System.Drawing.Size(960, 20);
			this.miniLog.TabIndex = 5;
			this.miniLog.Text = "Ready.";
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
			this.cancelTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelTransfer.Enabled = false;
			this.cancelTransfer.Location = new System.Drawing.Point(852, 521);
			this.cancelTransfer.Name = "cancelTransfer";
			this.cancelTransfer.Size = new System.Drawing.Size(120, 23);
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
			this.Controls.Add(this.miniLog);
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
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TextBox directoryBox;
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
		private System.Windows.Forms.ColumnHeader size;
		private System.Windows.Forms.ListView binderList;
		private System.Windows.Forms.ColumnHeader name1;
		private System.Windows.Forms.ColumnHeader type1;
		private System.Windows.Forms.ColumnHeader size1;
		private System.Windows.Forms.ColumnHeader lastModified1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectSiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Button cancelTransfer;
		private System.Windows.Forms.ToolStripMenuItem openSiteInBrowserToolStripMenuItem;
		private System.Windows.Forms.TextBox binderBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripButton toolStripButton8;
		private System.Windows.Forms.ToolStripButton toolStripButton9;
		private System.Windows.Forms.ToolStripButton toolStripButton10;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripButton toolStripButton11;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

	}
}