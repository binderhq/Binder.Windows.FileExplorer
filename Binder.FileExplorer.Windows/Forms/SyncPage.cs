﻿using Binder.Windows.FileExplorer.Forms;
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

		private async void SyncPage_Load(object sender, EventArgs e)
		{
			currentBinderDir = "/";
			currentLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			directoryBox.Text = currentLocalDir;
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

		private void directoryBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				Cursor.Current = Cursors.WaitCursor;
				currentLocalDir = directoryBox.Text;
				if(!currentLocalDir.EndsWith("\\"))
				{
					currentLocalDir = currentLocalDir + "\\";
					directoryBox.Text = currentLocalDir;
				}
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
			if(binderList.SelectedItems.Count <= 1)
				binderList.FocusedItem = (ListViewItem) e.Item;
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void localList_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private async void localList_DragDrop(object sender, DragEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			List<string> selectedFolders = new List<string>();
			List<string> selectedFiles = new List<string>();
			foreach(ListViewItem item in binderList.SelectedItems)
			{
				if(item.ImageIndex == 0)
					selectedFolders.Add(item.Name);
				else
					selectedFiles.Add(item.Name);
			}

			Task t = Session.DownloadDirectory(currentLocalDir.TrimEnd('\\'), selectedFolders, selectedFiles, progressBar1, miniLog);
			await t;

			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			miniLog.Text = "Ready.";
			progressBar1.Value = 0;
			Cursor.Current = Cursors.Default;
			
		}

		private async void binderList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (binderList.FocusedItem.ImageIndex == 0)
			{
				if(Equals(currentBinderDir, "/"))
					button2.Enabled = true;
				currentBinderDir = currentBinderDir.TrimEnd('/') + "/" + binderList.FocusedItem.Text;
				var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
				Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			}
			Cursor.Current = Cursors.Default;
		}

		private async void button2_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			int index = currentBinderDir.LastIndexOf("/");
			currentBinderDir = currentBinderDir.Substring(0, index);
			if(Equals(currentBinderDir, ""))
			{
				currentBinderDir = "/";
				button2.Enabled = false;
			}
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			button2.Enabled = true;
		}

		private void localList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			localList.FocusedItem = (ListViewItem)e.Item;
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void UpdateProgressTextFromExternalThread(int completed, int total)
		{
			this.progressBar1.Invoke(new Action(() =>
			{
				this.progressBar1.Maximum = total;
				this.progressBar1.Value = completed;
			}));
		}
		private void binderList_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private async void binderList_DragDrop(object sender, DragEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			List<string> selectedItems = new List<string>();
			foreach (ListViewItem item in localList.SelectedItems)
				selectedItems.Add(item.Name);
			Task t = Session.UploadDirectory(currentBinderDir,selectedItems,progressBar1,miniLog);
			await t;
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			miniLog.Text = "Ready.";
			progressBar1.Value = 0;
			Cursor.Current = Cursors.Default;
		
		}

		private void button3_Click(object sender, EventArgs e)
		{
			SitePage sp = new SitePage();
			sp.Show();
			this.Close();
		}

		private async void button4_Click(object sender, EventArgs e)
		{
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
		}

		private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Session.CloseSession();
			this.Close();
			LoginPage lp = new LoginPage();
			lp.Show();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Session.CloseSession();
			Application.Exit();
		}

		private void selectSiteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SitePage sp = new SitePage();
			sp.Show();
			this.Close();
		}
	}
}
