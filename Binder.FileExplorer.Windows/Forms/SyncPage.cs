using Binder.Windows.FileExplorer.Forms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
		private string uploadHere;
		private string downloadHere;
		private static bool isTransferRunning = false;
		private static bool isChangingForms = false;
		private ListViewColumnSorter lvwColumnSorter;

		public SyncPage()
		{
			InitializeComponent();
			lvwColumnSorter = new ListViewColumnSorter();
			this.localList.ListViewItemSorter = lvwColumnSorter;
			this.binderList.ListViewItemSorter = lvwColumnSorter;
		}

		private async void SyncPage_Load(object sender, EventArgs e)
		{
			isChangingForms = false;
			binderList.AllowDrop = true;
			localList.AllowDrop = true;
			currentBinderDir = "/";
			this.Text = Session.currentSelectedSiteName + " - File Management";
			currentLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			directoryBox.Text = currentLocalDir;
			binderBox.Text = currentBinderDir;
			Session.IsReadOnly(toolStripLabel1, currentBinderDir);
			var user = await Session.GetCurrentUser();
			loggedInAsLabel.Text = "Logged in as: " + user.Name + " (" + user.Username + ")";
			uploadHere = currentBinderDir;
			downloadHere = currentLocalDir;
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			this.Close();
			SitePage sp = new SitePage();
			sp.Show();
		}

		private void directoryBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				directoryBox.Enabled = false;
				toolStrip2.Enabled = false;
				toolStrip3.Enabled = false;
				localList.Enabled = false;
				string oldLocalDir = currentLocalDir;
				currentLocalDir = directoryBox.Text;
				try
				{
					if(Equals(currentLocalDir, "") || Equals(currentLocalDir, "\\"))
					{
						throw new DirectoryNotFoundException();
					}
					if(!currentLocalDir.EndsWith("\\"))
					{
						currentLocalDir = currentLocalDir + "\\";
						directoryBox.Text = currentLocalDir;
					}
					Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				}
				catch(Exception err)
				{
					MessageBox.Show(err.Message);
					currentLocalDir = oldLocalDir;
					directoryBox.Text = oldLocalDir;
					Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				}
				if(directoryBox.Text.Length > 3)
					toolStripButton4.Enabled = true;
				else
					toolStripButton3.Enabled = false;
				directoryBox.Enabled = true;
				toolStrip2.Enabled =   true;
				toolStrip3.Enabled =   true;
				localList.Enabled =    true;
			}
		}

		private void localList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			directoryBox.Enabled = false;
			toolStrip2.Enabled = false;
			toolStrip3.Enabled = false;
			localList.Enabled = false;
			string oldLocalDir = currentLocalDir;
			try
			{	
				if(localList.FocusedItem.ImageIndex == 0)
				{
					currentLocalDir = currentLocalDir.TrimEnd('\\') + "\\" + localList.FocusedItem.Text.ToString() + "\\";
					Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
					directoryBox.Text = currentLocalDir;
					if (directoryBox.Text.Length > 3)
						toolStripButton4.Enabled = true;
				}
				else
				{
					Process.Start(currentLocalDir.TrimEnd('\\') + "\\" + localList.FocusedItem.Text.ToString());
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
				currentLocalDir = oldLocalDir;
				directoryBox.Text = oldLocalDir;
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			}
			directoryBox.Enabled = true;
			toolStrip2.Enabled = true;
			toolStrip3.Enabled = true;
			localList.Enabled = true;
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
			ListViewItem itemBeingDragged = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
			if (itemBeingDragged.ListView == localList)
				return;
			if(!Session.isTransferRunning)
			{
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
				cancelTransfer.Enabled = true;
				Task t = Session.DownloadDirectory(downloadHere.TrimEnd('\\'), selectedFolders, selectedFiles, progressBar1, miniLog);
				await t;
				cancelTransfer.Enabled = false;
				isTransferRunning = false;
				Thread.Sleep(1000);
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				miniLog.Text = "Ready.";
				progressBar1.Value = 0;
			}
			else
				MessageBox.Show("Please wait until the current file transfer has finished before starting a new one.", "File Transfer in Progress");
		}

		private async void binderList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			binderBox.Enabled = false;
			toolStrip1.Enabled = false;
			binderList.Enabled = false;
			if (binderList.FocusedItem.ImageIndex == 0)
			{
				if(Equals(currentBinderDir, "/"))
					toolStripButton3.Enabled = true;
				currentBinderDir = currentBinderDir.TrimEnd('/') + "/" + binderList.FocusedItem.Text;
				var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
				Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
				binderBox.Text = currentBinderDir;
			}
			else
				await Session.PreviewFile(binderList.FocusedItem.Name);
			Session.IsReadOnly(toolStripLabel1, currentBinderDir);
			binderBox.Enabled = true;
			toolStrip1.Enabled = true;
			binderList.Enabled = true;
		}

		private void localList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (localList.SelectedItems.Count <= 1)
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
			ListViewItem itemBeingDragged = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
			if (itemBeingDragged.ListView == binderList)
				return;
			if(!Session.isTransferRunning)
			{
				isTransferRunning = true;
				Session.cts = new CancellationTokenSource();
				List<string> selectedItems = new List<string>();
				foreach (ListViewItem item in localList.SelectedItems)
					selectedItems.Add(item.Name);
				cancelTransfer.Enabled = true;
				Task t = Session.UploadDirectory(uploadHere, selectedItems, progressBar1, miniLog);
				await t;
				cancelTransfer.Enabled = false;
				isTransferRunning = false;
				miniLog.Text = "Ready.";
				Thread.Sleep(1000);
				var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
				Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
				Session.IsReadOnly(toolStripLabel1, currentBinderDir);
				progressBar1.Value = 0;			
			}
			else
				MessageBox.Show("Please wait until the current file transfer has finished before starting a new one.", "File Transfer in Progress");
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
					if(isChangingForms){
						isChangingForms = false;
						e.Cancel = true;
					}
					else
						Application.Exit();
				}
			}
			else
			{
				if (isChangingForms)
				{
					isChangingForms = false;
				}
				else
					Application.Exit();
			}
		}

		private void localList_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine if clicked column is already the column that is being sorted.
			if (e.Column == lvwColumnSorter.SortColumn)
			{
				// Reverse the current sort direction for this column.
				if (lvwColumnSorter.Order == SortOrder.Ascending)
				{
					lvwColumnSorter.Order = SortOrder.Descending;
				}
				else
				{
					lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}

			// Perform the sort with these new sort options.
			this.localList.Sort();
		}

		private void binderList_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine if clicked column is already the column that is being sorted.
			if (e.Column == lvwColumnSorter.SortColumn)
			{
				// Reverse the current sort direction for this column.
				if (lvwColumnSorter.Order == SortOrder.Ascending)
				{
					lvwColumnSorter.Order = SortOrder.Descending;
				}
				else
				{
					lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}

			// Perform the sort with these new sort options.
			this.binderList.Sort();
		}

		//Refresh remote side
		private async void toolStripButton2_Click(object sender, EventArgs e)
		{
			binderBox.Enabled = false;
			toolStrip1.Enabled = false;
			binderList.Enabled = false;
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			Session.IsReadOnly(toolStripLabel1, currentBinderDir);
			binderBox.Enabled = true;
			toolStrip1.Enabled = true;
			binderList.Enabled = true;
		}

		//Refresh local side
		private async void toolStripButton1_Click(object sender, EventArgs e)
		{
			directoryBox.Enabled = false;
			toolStrip2.Enabled = false;
			toolStrip3.Enabled = false;
			localList.Enabled = false;
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			directoryBox.Enabled = true;
			toolStrip2.Enabled = true;
			toolStrip3.Enabled = true;
			localList.Enabled = true;
		}

		//Up on level remote side
		private async void toolStripButton3_Click(object sender, EventArgs e)
		{
			binderBox.Enabled = false;
			toolStrip1.Enabled = false;
			binderList.Enabled = false;
			int index = currentBinderDir.LastIndexOf("/");
			currentBinderDir = currentBinderDir.Substring(0, index);
			if (Equals(currentBinderDir, ""))
				currentBinderDir = "/";
			if (Equals(currentBinderDir, "/"))
				toolStripButton3.Enabled = false;
			else
				toolStripButton3.Enabled = true;
			var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
			Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			Session.IsReadOnly(toolStripLabel1, currentBinderDir);
			binderBox.Text = currentBinderDir;
			binderBox.Enabled = true;
			toolStrip1.Enabled = true;
			binderList.Enabled = true;
		}

		//up one level local side
		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			directoryBox.Enabled = false;
			toolStrip2.Enabled = false;
			toolStrip3.Enabled = false;
			localList.Enabled = false;
			int index = currentLocalDir.TrimEnd('\\').LastIndexOf("\\");
			currentLocalDir = currentLocalDir.Substring(0, index) + "\\";
			if (currentLocalDir.Length == 3)
				toolStripButton4.Enabled = false;
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			directoryBox.Text = currentLocalDir;
			directoryBox.Enabled = true;
			toolStrip2.Enabled = true;
			toolStrip3.Enabled = true;
			localList.Enabled = true;
		}

		private async void toolStripButton5_Click(object sender, EventArgs e)
		{
			try
			{
				if (Equals(currentBinderDir, "/"))
				{
					string boxName = Microsoft.VisualBasic.Interaction.InputBox("Enter box name: ", "Create new box", " ");
					if (boxName.Length > 0) //VB is awful
						await Session.CreateBox(boxName);
				}
				else
				{
					string folderName = Microsoft.VisualBasic.Interaction.InputBox("Enter folder name: ", "Create new folder", " ");
					if (folderName.Length > 0)
						await Session.CreateBinderFolder(folderName, currentBinderDir);
				}
				var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
				Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		//delete from remote
		private async void toolStripButton6_Click(object sender, EventArgs e)
		{
			if(Equals(currentBinderDir, "/"))
				MessageBox.Show("Boxes cannot be deleted from this application. Please use the control centre on http://app.binder.works/");
			else
			{
				if(binderList.SelectedItems.Count == 0)
					MessageBox.Show("Please select an item to delete.", "No item selected");
				else
				{
					if(MessageBox.Show("Are you sure you want to delete the selected item(s)? This action cannot be undone.", "Confirm deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						List<ListViewItem> items = new List<ListViewItem>();
						foreach(ListViewItem item in binderList.SelectedItems)
							items.Add(item);
						await Session.DeleteFilesOnBider(items);
						var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
						Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
					}
				}
			}
		}

		private async void binderBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				binderBox.Enabled = false;
				toolStrip1.Enabled = false;
				binderList.Enabled = false;
				string oldBinderDir = currentBinderDir;
				currentBinderDir = binderBox.Text;
				try
				{
					var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
					Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
					if(directoryBox.Text.Length == 1)
						toolStripButton3.Enabled = false;
					else
						toolStripButton3.Enabled = true;
				}
				catch(Exception err)
				{
					MessageBox.Show(err.Message);
					currentBinderDir = oldBinderDir;
					binderBox.Text = oldBinderDir;
				}
				binderBox.Enabled = true;
				toolStrip1.Enabled = true;
				binderList.Enabled = true;
			}
		}

		//delete from local
		private async void toolStripButton7_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Are you sure you want to delete the selected item(s)? The item(s) will be sent to the recycling bin.", "Confirm deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				List<string> items = new List<string>();
				foreach(ListViewItem item in localList.SelectedItems)
					items.Add(item.Name);
				await Session.DeleteFilesOnLocal(items);
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			}
		}

		private async void toolStripButton8_Click(object sender, EventArgs e)
		{
			if(Equals(currentBinderDir, "/"))
				MessageBox.Show("Boxes cannot be renamed from this application. Please use the control centre on http://app.binder.works/");
			else
			{
				try
				{
					if (binderList.FocusedItem.ImageIndex == 0)
					{
						string newFolderName = Microsoft.VisualBasic.Interaction.InputBox("Enter new folder name: ", "Rename folder", binderList.FocusedItem.Text);
						if (newFolderName.Length > 0)
							await Session.RenameFolderOnBinder(binderList.FocusedItem.Name, newFolderName);
					}
					else
					{
						string newFilename = Microsoft.VisualBasic.Interaction.InputBox("Enter new file name: ", "Rename file", binderList.FocusedItem.Text);
						if (newFilename.Length > 0) //VB is still awful
							await Session.RenameFileOnBinder(binderList.FocusedItem.Name, newFilename);
					}
					var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
					Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
				}
				catch (NullReferenceException)
				{
					MessageBox.Show("Please select a file or folder to rename.", "No file or folder selected");
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}
		}

		private async void toolStripButton9_Click(object sender, EventArgs e)
		{
			try
			{
				string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new name: ", "Rename", localList.FocusedItem.Text);
				if(newName.Length > 0)
					await Session.RenameOnLocal(currentLocalDir, localList.FocusedItem.Text, newName);
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			}
			catch(NullReferenceException)
			{
				MessageBox.Show("Please select a file or folder to rename.", "No file or folder selected");
			}
		}

		private void toolStripButton10_Click(object sender, EventArgs e)
		{
			string folderName = Microsoft.VisualBasic.Interaction.InputBox("Enter folder name: ", "Create new folder", " ");
			try
			{
				if (folderName.Length > 0)
					Directory.CreateDirectory(currentLocalDir + "\\" + folderName);
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void toolStripButton11_Click(object sender, EventArgs e)
		{
			DialogResult folderToOpen = openFolder.ShowDialog();
			if (folderToOpen == System.Windows.Forms.DialogResult.OK)
			{
				currentLocalDir = openFolder.SelectedPath;
				directoryBox.Text = currentLocalDir;
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				if (directoryBox.Text.Length > 3)
					toolStripButton4.Enabled = true;
			}
		}

		private void binderList_DragOver(object sender, DragEventArgs e)
		{
			ListViewItem itemBeingDragged = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
			if(itemBeingDragged.ListView == binderList)
			{
				miniLog.Text = "Ready.";
				return;
			}
			binderList.SelectedItems.Clear();
			binderList.FocusedItem = null;
			var point = binderList.PointToClient(new Point(e.X, e.Y));
			var item = binderList.GetItemAt(point.X, point.Y);
			if (item != null)
			{
				if (item.ImageIndex == 0)
				{
					item.Focused = true;
					item.Selected = true;
					miniLog.Text = "Drop to upload to " + binderList.FocusedItem.Text;
					uploadHere = binderList.FocusedItem.Name;
				}
				else
				{
					miniLog.Text = "Drop to upload to " + currentBinderDir.Substring(currentBinderDir.LastIndexOf('/') + 1);
					uploadHere = currentBinderDir;
				}
			}
			else
			{
				if(Equals(currentBinderDir, "/"))
					miniLog.Text = "Cannot upload files to root directory.";
				else
					miniLog.Text = "Drop to upload to " + currentBinderDir.Substring(currentBinderDir.LastIndexOf('/') + 1);
				uploadHere = currentBinderDir;
			}
		}
	
		private void localList_DragOver(object sender, DragEventArgs e)
		{
			ListViewItem itemBeingDragged = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
			if (itemBeingDragged.ListView == localList)
			{
				miniLog.Text = "Ready.";
				return;
			}
			localList.SelectedItems.Clear();
			localList.FocusedItem = null;
			var point = localList.PointToClient(new Point(e.X, e.Y));
			var item = localList.GetItemAt(point.X, point.Y);
			if (item != null)
			{
				if (item.ImageIndex == 0)
				{
					item.Focused = true;
					item.Selected = true;
					miniLog.Text = "Drop to download to " + localList.FocusedItem.Text;
					downloadHere = localList.FocusedItem.Name;
				}
				else
				{
					miniLog.Text = "Drop to download to " + currentLocalDir.Substring(currentLocalDir.LastIndexOf('\\', currentLocalDir.Length - 2) + 1);
					downloadHere = currentLocalDir;
				}
			}
			else
			{
				miniLog.Text = "Drop to download to " + currentLocalDir.Substring(currentLocalDir.LastIndexOf('\\', currentLocalDir.Length - 2) + 1);
				downloadHere = currentLocalDir;
			}
		}

		private void localList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if(localList.FocusedItem != null)
				{
					string oldLocalDir = currentLocalDir;
					try
					{
						if (localList.FocusedItem.ImageIndex == 0)
						{
							currentLocalDir = currentLocalDir.TrimEnd('\\') + "\\" + localList.FocusedItem.Text.ToString() + "\\";
							Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
							directoryBox.Text = currentLocalDir;
							if (directoryBox.Text.Length > 3)
								toolStripButton4.Enabled = true;
						}
						else
						{
							Process.Start(currentLocalDir.TrimEnd('\\') + "\\" + localList.FocusedItem.Text.ToString());
						}
					}
					catch (Exception err)
					{
						MessageBox.Show(err.Message);
						currentLocalDir = oldLocalDir;
						directoryBox.Text = oldLocalDir;
						Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
					}
				}
			}
			else if(e.KeyCode == Keys.F5)
				toolStripButton1_Click(sender, e);
			else if(e.KeyCode == Keys.Back)
			{
				if(currentLocalDir.Length > 3)
					toolStripButton4_Click(sender, e);
			}
			else if(e.KeyCode == Keys.Delete)
			{
				if (localList.FocusedItem != null)
					toolStripButton7_Click(sender, e);
			}
			else if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
			{
				foreach (ListViewItem item in localList.Items)
				{
					item.Selected = true;
				}
			}
		}

		private async void binderList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if(binderList.FocusedItem != null)
				{
					if (binderList.FocusedItem.ImageIndex == 0)
					{
						if (Equals(currentBinderDir, "/"))
							toolStripButton3.Enabled = true;
						currentBinderDir = currentBinderDir.TrimEnd('/') + "/" + binderList.FocusedItem.Text;
						var currentDirectory = await Session.GetSiteFilesFolders(Session.currentSelectedSite, currentBinderDir);
						Session.PopulateListViewFromServer(binderList, currentDirectory.Folders, currentDirectory.Files, contextMenu, imageList1);
						binderBox.Text = currentBinderDir;
					}
					Session.IsReadOnly(toolStripLabel1, currentBinderDir);
				}
			}
			else if(e.KeyCode == Keys.F5)
				toolStripButton2_Click(sender, e);
			else if(e.KeyCode == Keys.Back)
			{
				if(!Equals(currentBinderDir, "/"))
					toolStripButton3_Click(sender, e);
			}
			else if(e.KeyCode == Keys.Delete)
			{
				if(binderList.FocusedItem != null)
					toolStripButton6_Click(sender, e);
			}
			else if(e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
			{
				foreach (ListViewItem item in binderList.Items)
				{
					item.Selected = true;
				}
			}
		}

		private void toolStripButton12_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(currentLocalDir);
		}
	}
}