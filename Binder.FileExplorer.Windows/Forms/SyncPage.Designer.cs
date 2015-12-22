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
			this.lastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.syncButton = new System.Windows.Forms.Button();
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
			this.button1 = new System.Windows.Forms.Button();
			this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.binderTree = new System.Windows.Forms.TreeView();
			this.tableLayoutPanel1.SuspendLayout();
			this.contextMenu.SuspendLayout();
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
			this.tableLayoutPanel1.Controls.Add(this.binderTree, 0, 1);
			this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 20);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(999, 501);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// localList
			// 
			this.localList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.type,
            this.size,
            this.lastModified});
			this.localList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.localList.Location = new System.Drawing.Point(502, 38);
			this.localList.Name = "localList";
			this.localList.Size = new System.Drawing.Size(489, 455);
			this.localList.SmallImageList = this.imageList1;
			this.localList.TabIndex = 1;
			this.localList.UseCompatibleStateImageBehavior = false;
			this.localList.View = System.Windows.Forms.View.Details;
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Binder files";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(933, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Local files";
			// 
			// syncButton
			// 
			this.syncButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.syncButton.Location = new System.Drawing.Point(12, 527);
			this.syncButton.Name = "syncButton";
			this.syncButton.Size = new System.Drawing.Size(120, 23);
			this.syncButton.TabIndex = 4;
			this.syncButton.Text = "Sync Files to Binder";
			this.syncButton.UseVisualStyleBackColor = true;
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.progressBar1.Location = new System.Drawing.Point(138, 527);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(225, 23);
			this.progressBar1.TabIndex = 5;
			// 
			// browseButton
			// 
			this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.browseButton.Location = new System.Drawing.Point(867, 526);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(120, 23);
			this.browseButton.TabIndex = 6;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// directoryBox
			// 
			this.directoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.directoryBox.Location = new System.Drawing.Point(584, 528);
			this.directoryBox.Name = "directoryBox";
			this.directoryBox.Size = new System.Drawing.Size(277, 20);
			this.directoryBox.TabIndex = 7;
			this.directoryBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.directoryBox_KeyPress);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(530, 531);
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
			this.downloadMenu.Click += new System.EventHandler(this.downloadMenu_Click);
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
			this.miniLog.Location = new System.Drawing.Point(369, 528);
			this.miniLog.Name = "miniLog";
			this.miniLog.ReadOnly = true;
			this.miniLog.Size = new System.Drawing.Size(120, 20);
			this.miniLog.TabIndex = 9;
			this.miniLog.Text = "Ready.";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(936, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(55, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "Up";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// size
			// 
			this.size.Text = "Size";
			// 
			// binderTree
			// 
			this.binderTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.binderTree.Location = new System.Drawing.Point(8, 38);
			this.binderTree.Name = "binderTree";
			this.binderTree.Size = new System.Drawing.Size(488, 455);
			this.binderTree.TabIndex = 3;
			// 
			// SyncPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(999, 561);
			this.Controls.Add(this.miniLog);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.directoryBox);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.syncButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(1000, 600);
			this.Name = "SyncPage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "File Synchronisation";
			this.Load += new System.EventHandler(this.SyncPage_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button syncButton;
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
		private System.Windows.Forms.TreeView binderTree;

	}
}