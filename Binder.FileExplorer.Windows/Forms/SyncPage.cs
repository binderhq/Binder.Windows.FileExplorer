using Binder.Windows.FileExplorer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binder.Windows.FileExplorer
{
	public partial class SyncPage : Form
	{
		private string currentLocalDir;
		private string currentBinderDir;

		public SyncPage()
		{
			InitializeComponent();
		}

		private void SyncPage_Load(object sender, EventArgs e)
		{
			currentBinderDir = "/";
			var currentDirectory = Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			this.Close();
			SitePage sp = new SitePage();
			sp.Show();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			DialogResult folderToOpen = openFolder.ShowDialog();
			if(folderToOpen == System.Windows.Forms.DialogResult.OK)
			{
				Cursor.Current = Cursors.WaitCursor;
				currentLocalDir = openFolder.SelectedPath;
				directoryBox.Text = currentLocalDir;
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				if (directoryBox.Text.Length > 3)
					button1.Enabled = true;
				Cursor.Current = Cursors.Default;
			}
		}

		private void downloadMenu_Click(object sender, EventArgs e)
		{
			string pathToDownload = this.binderList.FocusedItem.Name;
			string fileToDownload = this.binderList.FocusedItem.Text;

			saveFile.FileName = fileToDownload;
			DialogResult downloadTo = saveFile.ShowDialog();

			if(downloadTo == System.Windows.Forms.DialogResult.OK)
			{
				if (this.binderList.FocusedItem.ImageIndex != 0)
					Session.GetFile(Session.currentSelectedSite, pathToDownload, fileToDownload.TrimEnd('/'), saveFile.FileName, this.progressBar1, this.miniLog);
				else
					Session.GetZipFile(pathToDownload, saveFile.FileName, this.progressBar1, this.miniLog);
			}
		}

		private void directoryBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				Cursor.Current = Cursors.WaitCursor;
				currentLocalDir = directoryBox.Text;
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				if(directoryBox.Text.Length > 3)
					button1.Enabled = true;
				Cursor.Current = Cursors.Default;
			}
		}

		private void localList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if(localList.FocusedItem.ImageIndex == 0)
			{
				currentLocalDir = currentLocalDir.TrimEnd('\\') + "\\" + localList.FocusedItem.Text.ToString() + "\\";
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				directoryBox.Text = currentLocalDir;
				if (directoryBox.Text.Length > 3)
					button1.Enabled = true;
			}
			else
			{
				Process.Start(currentLocalDir.TrimEnd('\\') + "\\" + localList.FocusedItem.Text.ToString());
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int index = currentLocalDir.TrimEnd('\\').LastIndexOf("\\");
			currentLocalDir = currentLocalDir.Substring(0, index) + "\\";
			if(currentLocalDir.Length == 3)
				button1.Enabled = false;
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			directoryBox.Text = currentLocalDir;
		}

		private void binderList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			binderList.FocusedItem = (ListViewItem) e.Item;
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void localList_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void localList_DragDrop(object sender, DragEventArgs e)
		{
			string pathToDownload = this.binderList.FocusedItem.Name;
			string fileToDownload = this.binderList.FocusedItem.Text;

			Session.GetFile(Session.currentSelectedSite, pathToDownload, fileToDownload.TrimEnd('/'), this.directoryBox.Text + "\\" + fileToDownload.TrimEnd('/'), this.progressBar1, this.miniLog);

			Cursor.Current = Cursors.WaitCursor;
			System.Threading.Thread.Sleep(500);
			currentLocalDir = directoryBox.Text;
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			Cursor.Current = Cursors.Default;
		}

		private void binderList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (binderList.FocusedItem.ImageIndex == 0)
			{
				if(Equals(currentBinderDir, "/"))
					button2.Enabled = true;
				currentBinderDir = currentBinderDir.TrimEnd('/') + "/" + binderList.FocusedItem.Text;
				var currentDirectory = Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
				Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int index = currentBinderDir.LastIndexOf("/");
			currentBinderDir = currentBinderDir.Substring(0, index);
			if(Equals(currentBinderDir, ""))
			{
				currentBinderDir = "/";
				button2.Enabled = false;
			}
			var currentDirectory = Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
		}
	}
}
