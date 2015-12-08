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

namespace Binder.Windows.FileExplorer
{
	public partial class LoginPage : Form
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Session.CreateSession(this.username.Text, this.password.Text);
			this.log.Text = Session.ResponseMessage;
			if(Session.isSuccessful)
			{
				getinfo.Enabled = true;
				signout.Enabled = true;
				submit.Enabled = false;
			}
		}

		private void getinfo_Click(object sender, EventArgs e)
		{
			Session.CurrentUserInfo CurrentUserInfo = Session.CurrentUser();
			Session.CurrentRegionUserSitesResponse CurrentUserSites = Session.CurrentSites();
			string name = CurrentUserInfo.Name;
			string username = CurrentUserInfo.Username;
			string email = CurrentUserInfo.EmailAddress;

			string[] siteNames = CurrentUserSites.ConnectedSites.Select(x=>x.Site.Name).ToArray();
			string[] siteIds = CurrentUserSites.ConnectedSites.Select(x=>x.Site.Id).ToArray();

			this.log.Text =
				"Welcome, " + name +
				"\r\nYour email address is " + email +
				"\r\nYour username is " + username;

			this.boxesList.Items.AddRange(siteNames);
		}

		private void signout_Click(object sender, EventArgs e)
		{
			Session.CloseSession();
			getinfo.Enabled = false;
			signout.Enabled = false;
			submit.Enabled = true;
		}
	}
}
