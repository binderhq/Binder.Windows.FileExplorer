using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binder.Windows.FileExplorer;
using System.IO;

namespace Binder.Windows.FileExplorer
{
	public partial class LoginPage : Form
	{
		public string[] siteNames;
		public string[] siteIds;
		
		public LoginPage()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			submit.Enabled = false;
			Cursor.Current = Cursors.WaitCursor;
			Session.CreateSession(this.username.Text, this.password.Text);
			this.log.Text = Session.ResponseMessage;
			if(Session.isSuccessful)
			{
				Session.CurrentUserInfo CurrentUserInfo = Session.CurrentUser();
				Session.CurrentRegionUserSitesResponse CurrentUserSites = Session.CurrentSites();
				string name = CurrentUserInfo.Name;
				string username = CurrentUserInfo.Username;
				string email = CurrentUserInfo.EmailAddress;

				siteNames = CurrentUserSites.ConnectedSites.Select(x=>x.Site.Name).ToArray();
				siteIds = CurrentUserSites.ConnectedSites.Select(x=>x.Site.Id).ToArray();

				this.log.Text =
					"Welcome, " + name +
					"\r\nYour email address is " + email +
					"\r\nYour username is " + username;
				this.sitesList.Items.Clear();
				this.sitesList.Items.AddRange(siteNames);
				getinfo.Enabled = true;
				signout.Enabled = true;
			}
			else
				submit.Enabled = true;
			Cursor.Current = Cursors.Default;
		}

		private void getinfo_Click(object sender, EventArgs e)
		{
			getinfo.Enabled = false;
			Cursor.Current = Cursors.WaitCursor; 
			if (sitesList.SelectedItem != null)
			{
				Session.currentSelectedSite = siteIds[sitesList.SelectedIndex];
				this.log.Text = sitesList.SelectedItem + " selected. Site ID: " + Session.currentSelectedSite;
				string[] filePaths = Session.GetDirectory(Session.currentSelectedSite).Select(x=>x.RemoteFilePath).ToArray();
				this.siteDirView.Nodes.Clear();
				Session.PopulateTreeView(siteDirView, filePaths, '/');
			}
			else
				this.log.Text = "Please select an item";
			getinfo.Enabled = true;
			Cursor.Current = Cursors.WaitCursor;
		}

		private void signout_Click(object sender, EventArgs e)
		{
			signout.Enabled = false;
			Session.CloseSession();
			getinfo.Enabled = false;
			submit.Enabled = true;
		}
	}
}
