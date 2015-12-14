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
			Session.PopulateTreeViewFromServer(binderTree, filePaths, '/');
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
			Session.PopulateTreeViewFromLocal(localTree, this.directoryBox.Text);
			Cursor.Current = Cursors.Default;
		}
	}
}
