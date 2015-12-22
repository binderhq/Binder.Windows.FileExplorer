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

		public SyncPage()
		{
			InitializeComponent();
		}

		private void SyncPage_Load(object sender, EventArgs e)
		{
			var currentDirectory = Session.GetDirectory(Session.currentSelectedSite);
			string[] filePaths = currentDirectory.Select(x => x.RemoteFilePath).ToArray();
			this.binderTree.Nodes.Clear();
			Session.PopulateTreeViewFromServer(binderTree, this.imageList1, filePaths, '/', this.contextMenu);
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
				//Session.PopulateTreeViewFromLocal(localTree, this.imageList1, this.directoryBox.Text, this.contextMenu);
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				Cursor.Current = Cursors.Default;
			}
		}

		private void downloadMenu_Click(object sender, EventArgs e)
		{
			string pathToDownload = this.binderTree.SelectedNode.Name;
			string fileToDownload = this.binderTree.SelectedNode.Text;

			saveFile.FileName = fileToDownload;
			DialogResult downloadTo = saveFile.ShowDialog();

			if(downloadTo == System.Windows.Forms.DialogResult.OK)
			{
//				if(this.binderTree.SelectedNode.ImageIndex == 1)
					Session.GetFile(Session.currentSelectedSite, pathToDownload, fileToDownload.TrimEnd('/'), saveFile.FileName, this.progressBar1, this.miniLog);
//				else if (this.binderTree.SelectedNode.ImageIndex == 0)
//					Session.GetZipFile(pathToDownload, saveFile.FileName, this.progressBar1, this.miniLog);
			}
		}

		private void binderTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right) binderTree.SelectedNode = e.Node;
		}

		private void directoryBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				Cursor.Current = Cursors.WaitCursor;
				currentLocalDir = directoryBox.Text;
				//Session.PopulateTreeViewFromLocal(localTree, this.imageList1, this.directoryBox.Text, this.contextMenu);
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				Cursor.Current = Cursors.Default;
			}
		}

		private void localList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if(localList.FocusedItem.ImageIndex == 0)
			{
				currentLocalDir = currentLocalDir.TrimEnd('\\') + "\\" + localList.FocusedItem.Text.ToString();
				Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
				directoryBox.Text = currentLocalDir;
			}
			else
			{
				Process.Start(currentLocalDir.TrimEnd('\\') + "\\" + localList.FocusedItem.Text.ToString());
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int index = currentLocalDir.LastIndexOf("\\");
			if (index > 0)
				currentLocalDir = currentLocalDir.Substring(0, index);
			Session.PopulateListViewFromLocal(localList, new DirectoryInfo(currentLocalDir), imageList1);
			directoryBox.Text = currentLocalDir;
		}
	}
}
