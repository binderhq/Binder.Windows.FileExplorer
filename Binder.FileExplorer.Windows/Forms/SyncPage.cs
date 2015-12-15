using Binder.Windows.FileExplorer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binder.Windows.FileExplorer
{
	public partial class SyncPage : Form
	{
		public SyncPage()
		{
			InitializeComponent();
		}

		private void SyncPage_Load(object sender, EventArgs e)
		{
			string[] filePaths = Session.GetDirectory(Session.currentSelectedSite).Select(x => x.RemoteFilePath).ToArray();
			this.binderTree.Nodes.Clear();
			Session.PopulateTreeViewFromServer(binderTree, filePaths, '/', this.contextMenu);
		}

		private void backButton_Click(object sender, EventArgs e)
		{
			this.Close();
			SitePage sp = new SitePage();
			sp.Show();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			Session.PopulateTreeViewFromLocal(localTree, this.directoryBox.Text, this.contextMenu);
			Cursor.Current = Cursors.Default;
		}

		private void downloadMenu_Click(object sender, EventArgs e)
		{
			string pathToDownload = this.binderTree.SelectedNode.Name.TrimEnd('/');
			string fileToDownload = this.binderTree.SelectedNode.Text;
//			DialogResult result = MessageBox.Show("Download file " + pathToDownload + "?", "Confirm download", MessageBoxButtons.YesNo);

			saveFile.FileName = fileToDownload;
			DialogResult downloadTo = saveFile.ShowDialog();

			if(downloadTo == System.Windows.Forms.DialogResult.OK)
			{
				this.miniLog.Text = "Downloading...";
				Session.GetFile(Session.currentSelectedSite, pathToDownload, fileToDownload, saveFile.FileName, this.progressBar1, this.miniLog);
			}

//			if(result == System.Windows.Forms.DialogResult.Yes)
		}
	}
}
