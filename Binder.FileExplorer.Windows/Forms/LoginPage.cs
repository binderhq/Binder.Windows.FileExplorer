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
				Cursor.Current = Cursors.WaitCursor;
				submit.Enabled = false;
				var user = await Session.CreateSession(this.username.Text, this.password.Text);
				Session.sites = await Session.CurrentSites();
				sitep = new SitePage();
				syncp = new SyncPage();
				sitep.Show();
				submit.Enabled = true;
				Cursor.Current = Cursors.Default;
				this.Hide();
		}

		private void signOut_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
			try
			{
				Session.CloseSession();
			}
			catch { }
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
