﻿using System;
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
using Binder.Windows.FileExplorer.Forms;

namespace Binder.Windows.FileExplorer
{
	public partial class LoginPage : Form
	{
		public SitePage sitep;
		public SyncPage syncp;
		public LoginPage()
		{
			InitializeComponent();
			Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			submit.Enabled = false;
			Cursor.Current = Cursors.WaitCursor;
			Session.CreateSession(this.username.Text, this.password.Text);
			if(Session.isSuccessful)
			{
				Session.CurrentUserInfo CurrentUserInfo = Session.CurrentUser();
				Session.CurrentRegionUserSitesResponse CurrentUserSites = Session.CurrentSites();
				string name = CurrentUserInfo.Name;
				string username = CurrentUserInfo.Username;
				string email = CurrentUserInfo.EmailAddress;

				Session.siteNames = CurrentUserSites.ConnectedSites.Select(x=>x.Site.Name).ToArray();
				Session.siteIds = CurrentUserSites.ConnectedSites.Select(x=>x.Site.Id).ToArray();
				this.signOut.Enabled = true;
				sitep = new SitePage();
				syncp = new SyncPage();
				sitep.Show();
			}
			else
				submit.Enabled = true;
			Cursor.Current = Cursors.Default;
		}

		private void signOut_Click(object sender, EventArgs e)
		{
			sitep.Close();
			syncp.Close();
			Session.CloseSession();
			this.username.Clear();
			this.password.Clear();
			this.signOut.Enabled = false;
			this.submit.Enabled = true;
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
			sitep.Close();
			syncp.Close();
			Session.CloseSession();
		}

		private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
		{
			sitep.Close();
			syncp.Close();
			Session.CloseSession();
		}
	}
}
