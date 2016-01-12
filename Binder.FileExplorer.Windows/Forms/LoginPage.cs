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

		private void LoginPage_Load(object sender, EventArgs e)
		{
			if(!Equals(Properties.Settings.Default.username,""))
			{
				username.Text = Properties.Settings.Default.username;
				checkBox1.Checked = true;
				if(!Equals(Properties.Settings.Default.password,""))
				{
					password.Text = Properties.Settings.Default.password;
					checkBox2.Checked = true;
					checkBox2.Enabled = true;
				}
			} 
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			submit.Enabled = false;
			Cursor.Current = Cursors.WaitCursor;
			try 
			{
				if(checkBox1.Checked)
				{
					
					if(checkBox2.Checked)
					{
						
					}
				}
				var user = await Session.CreateSession(this.username.Text, this.password.Text);
//				Session.CurrentRegionUserSitesResponse CurrentUserSites = Session.CurrentSites();
				Session.sites = await Session.CurrentSites();
//				Session.siteNames = CurrentUserSites.ConnectedSites.Select(x=>x.Site.Name).ToArray();
//				Session.siteIds = CurrentUserSites.ConnectedSites.Select(x=>x.Site.Id).ToArray();
				this.signOut.Enabled = true;
				sitep = new SitePage();
				syncp = new SyncPage();
				sitep.Show();
			}
			catch(Exception ex)
			{
				submit.Enabled = true;
				MessageBox.Show(ex.Message + "\n\nInvalid username or password", "Login error", MessageBoxButtons.OK);
			}
			Cursor.Current = Cursors.Default;
		}

		private void signOut_Click(object sender, EventArgs e)
		{
			sitep.Close();
			syncp.Close();
			Session.CloseSession();
			if(!checkBox2.Checked)
			{
				this.password.Clear();
				if(!checkBox1.Checked)
					this.username.Clear();
			}
			this.signOut.Enabled = false;
			this.submit.Enabled = true;
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
			try
			{
				sitep.Close();
				syncp.Close();
			}
			catch { }
			Session.CloseSession();
		}

		private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				sitep.Close();
				syncp.Close();
			}
			catch { }
			Session.CloseSession();
		}

		private void checkBox1_Click(object sender, EventArgs e)
		{
			if(checkBox1.Checked)
			{
				checkBox2.Enabled = true;
				Properties.Settings.Default.username = username.Text;
				Properties.Settings.Default.Save();
			}
			else if(!checkBox1.Checked)
			{
				checkBox2.Checked = false;
				checkBox2.Enabled = false;

				Properties.Settings.Default.username = "";
				Properties.Settings.Default.password = "";
				Properties.Settings.Default.Save();
			}
		}

		private void checkBox2_Click(object sender, EventArgs e)
		{
			if(checkBox2.Checked)
			{ 
				Properties.Settings.Default.password = password.Text;
				Properties.Settings.Default.Save();
			}
			else if(!checkBox2.Checked)
			{
				Properties.Settings.Default.password = "";
				Properties.Settings.Default.Save();
			}
		}
	}
}
