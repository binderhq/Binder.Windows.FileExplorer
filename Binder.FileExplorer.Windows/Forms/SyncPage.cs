﻿using Binder.Windows.FileExplorer.Forms;
using Microsoft.VisualBasic;
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
using System.Threading;

namespace Binder.Windows.FileExplorer
{
	public partial class SyncPage : Form
	{
		private string currentLocalDir;
		private string currentBinderDir;
		private static bool isTransferRunning = false;
		private static bool isChangingForms = false;

		public SyncPage()
		{
			InitializeComponent();
		}

		private async void SyncPage_Load(object sender, EventArgs e)
		{
			isChangingForms = false;
			binderList.AllowDrop = true;
			localList.AllowDrop = true;
			currentBinderDir = "/";
			currentLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			directoryBox.Text = currentLocalDir;
			Session.IsReadOnly(label1, currentBinderDir);

			ToolTip toolTip1 = new ToolTip();
			toolTip1.SetToolTip(label1, "The folder you are currently viewing has been set to \"Read only\". If you require write access to this folder, please contact the site's administrator.");
			toolTip1.SetToolTip(newFolder, "Creates a new folder in the current directory. If you are browsing the root \"/\" directory, this will create a new box instead");
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
			if(!Session.isTransferRunning)
			{
				Cursor.Current = Cursors.WaitCursor;
				isTransferRunning = true;
				Session.cts = new CancellationTokenSource();
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
				isTransferRunning = false;
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				miniLog.Text = "Ready.";
				progressBar1.Value = 0;
				Cursor.Current = Cursors.Default;
			}
			else
				MessageBox.Show("Please wait until the current file transfer has finished before starting a new one.", "File Transfer in Progress");
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
			Session.IsReadOnly(label1, currentBinderDir);
			Cursor.Current = Cursors.Default;
		}

		private async void button2_Click_1(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			int index = currentBinderDir.LastIndexOf("/");
			currentBinderDir = currentBinderDir.Substring(0, index);
			if (Equals(currentBinderDir, ""))
				currentBinderDir = "/";
			if(Equals(currentBinderDir, "/"))
				button2.Enabled = false;
			else
				button2.Enabled = true;
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			Session.IsReadOnly(label1, currentBinderDir);
			Cursor.Current = Cursors.Default;
		}

		private void localList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			localList.FocusedItem = (ListViewItem)e.Item;
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void UpdateProgressTextFromExternalThread(int completed, int total, string logText)
		{
			this.progressBar1.Invoke(new Action(() =>
			{
				this.progressBar1.Maximum = total;
				this.progressBar1.Value = completed;
			}));
			this.miniLog.Invoke(new Action( () => {
				this.miniLog.Text = logText;
			}));
		}
		private void binderList_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private async void binderList_DragDrop(object sender, DragEventArgs e)
		{
			if(!Session.isTransferRunning)
			{
				Cursor.Current = Cursors.WaitCursor;
				isTransferRunning = true;
				Session.cts = new CancellationTokenSource();
				List<string> selectedItems = new List<string>();
				foreach (ListViewItem item in localList.SelectedItems)
					selectedItems.Add(item.Name);
				Task t = Session.UploadDirectory(currentBinderDir, selectedItems, progressBar1, miniLog);
				await t;
				isTransferRunning = false;
				var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
				Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
				Session.IsReadOnly(label1, currentBinderDir);
				miniLog.Text = "Ready.";
				progressBar1.Value = 0;
				Cursor.Current = Cursors.Default;				
			}
			else
				MessageBox.Show("Please wait until the current file transfer has finished before starting a new one.", "File Transfer in Progress");
		}

		private async void button4_Click(object sender, EventArgs e)
		{
			button4.Enabled = false;
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			Session.IsReadOnly(label1, currentBinderDir);
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			button4.Enabled = true;
		}

		private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (isTransferRunning)
			{
				if (MessageBox.Show("There is a file transfer in progress. Are you sure you want to close? This could result in missing or corrupted files.", "Confirm close", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					isChangingForms = true;
					isTransferRunning = false;
					Session.CancelTransfer();
					Session.CloseSession();
					this.Close();
					LoginPage lp = new LoginPage();
					lp.Show();
				}
			}
			else
			{
				isChangingForms = true;
				Session.CloseSession();
				this.Close();
				LoginPage lp = new LoginPage();
				lp.Show();
			}
			
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (isTransferRunning)
			{
				if (MessageBox.Show("There is a file transfer in progress. Are you sure you want to close? This could result in missing or corrupted files.", "Confirm close", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					isTransferRunning = false;
					Session.CancelTransfer();
					Session.CloseSession();
					Application.Exit();
				}
			}
			else
			{
				Session.CloseSession();
				Application.Exit();
			}
		}

		private void selectSiteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (isTransferRunning)
			{
				if (MessageBox.Show("There is a file transfer in progress. Are you sure you want to close? This could result in missing or corrupted files.", "Confirm close", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					isChangingForms = true;
					isTransferRunning = false;
					Session.CancelTransfer();
					SitePage sp = new SitePage();
					sp.Show();
					this.Close();
				}
			}
			else 
			{
				isChangingForms = true;
				SitePage sp = new SitePage();
				sp.Show();
				this.Close();
			}
		}

		private async void newFolder_Click(object sender, EventArgs e)
		{
			try
			{
				if(Equals(currentBinderDir, "/"))
				{
					string boxName = Microsoft.VisualBasic.Interaction.InputBox("Enter box name: ", "Create new box", " ");
					if(boxName.Length > 0) //VB is awful
						await Session.CreateBox(boxName);
				}
				else
				{
					string folderName = Microsoft.VisualBasic.Interaction.InputBox("Enter folder name: ", "Create new folder", " ");
					if(folderName.Length > 0)
						await Session.CreateBinderFolder(folderName, currentBinderDir);
				}
				var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
				Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void cancelTransfer_Click(object sender, EventArgs e)
		{
			Session.CancelTransfer();
		}

		private async void openSiteInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Session.OpenInBrowser();
		}

		private void SyncPage_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(isTransferRunning)
			{
				if (MessageBox.Show("There is a file transfer in progress. Are you sure you want to close? This could result in missing or corrupted files.", "Confirm close", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					e.Cancel = true;
				}
				else
				{
					isTransferRunning = false;
					Session.CancelTransfer();
					Application.Exit();
				}
			}
			else
				Application.Exit();
		}
	}
}
