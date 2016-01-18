using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binder.Windows.FileExplorer.Forms
{
	public partial class SitePage : Form
	{
		
		public SitePage()
		{
			InitializeComponent();
		}

		private void SitePage_Load(object sender, EventArgs e)
		{
			this.sitesList.Items.Clear();
			//this.sitesList.Items.AddRange(Session.sites.);
			foreach(var site in Session.sites)
			{
				ListViewExt item = new ListViewExt();
				item.Text = site.Site.Name;
				item.Name = site.Site.Id;
				sitesList.Items.Add(item);
			}
			Cursor.Current = Cursors.Default;
		}

		private void selectSite_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (sitesList.SelectedItem != null)
			{
				ListViewItem selectedItem = (ListViewItem) sitesList.SelectedItem;
				Session.currentSelectedSite = selectedItem.Name;
				SyncPage sp = new SyncPage();
				sp.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Please select a site","Selection error",MessageBoxButtons.OK);
			}
			Cursor.Current = Cursors.Default;
		}

		private void sitesList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			selectSite_Click(sender, e);
		}
	}
	
	public class ListViewExt : ListViewItem
	{
		public override string ToString()
		{
			return this.Text;
		}
	}
}
