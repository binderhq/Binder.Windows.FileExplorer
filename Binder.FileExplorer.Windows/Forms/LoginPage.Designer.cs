namespace Binder.Windows.FileExplorer
{
	partial class LoginPage
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.username = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.submit = new System.Windows.Forms.Button();
			this.log = new System.Windows.Forms.TextBox();
			this.signout = new System.Windows.Forms.Button();
			this.getinfo = new System.Windows.Forms.Button();
			this.boxesList = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// username
			// 
			this.username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.username.Location = new System.Drawing.Point(73, 12);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(199, 20);
			this.username.TabIndex = 0;
			// 
			// password
			// 
			this.password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.password.Location = new System.Drawing.Point(73, 38);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(199, 20);
			this.password.TabIndex = 1;
			this.password.UseSystemPasswordChar = true;
			// 
			// submit
			// 
			this.submit.Location = new System.Drawing.Point(12, 64);
			this.submit.Name = "submit";
			this.submit.Size = new System.Drawing.Size(123, 23);
			this.submit.TabIndex = 2;
			this.submit.Text = "Sign in";
			this.submit.UseVisualStyleBackColor = true;
			this.submit.Click += new System.EventHandler(this.button1_Click);
			// 
			// log
			// 
			this.log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.log.Location = new System.Drawing.Point(12, 118);
			this.log.Multiline = true;
			this.log.Name = "log";
			this.log.ReadOnly = true;
			this.log.ShortcutsEnabled = false;
			this.log.Size = new System.Drawing.Size(260, 120);
			this.log.TabIndex = 3;
			// 
			// signout
			// 
			this.signout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.signout.Enabled = false;
			this.signout.Location = new System.Drawing.Point(151, 64);
			this.signout.Name = "signout";
			this.signout.Size = new System.Drawing.Size(121, 23);
			this.signout.TabIndex = 4;
			this.signout.Text = "Sign out";
			this.signout.UseVisualStyleBackColor = true;
			this.signout.Click += new System.EventHandler(this.signout_Click);
			// 
			// getinfo
			// 
			this.getinfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.getinfo.Enabled = false;
			this.getinfo.Location = new System.Drawing.Point(12, 405);
			this.getinfo.Name = "getinfo";
			this.getinfo.Size = new System.Drawing.Size(260, 23);
			this.getinfo.TabIndex = 5;
			this.getinfo.Text = "Get info";
			this.getinfo.UseVisualStyleBackColor = true;
			this.getinfo.Click += new System.EventHandler(this.getinfo_Click);
			// 
			// boxesList
			// 
			this.boxesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.boxesList.FormattingEnabled = true;
			this.boxesList.Location = new System.Drawing.Point(12, 265);
			this.boxesList.Name = "boxesList";
			this.boxesList.Size = new System.Drawing.Size(260, 134);
			this.boxesList.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 249);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Boxes";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 102);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Log";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Username";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Password";
			// 
			// LoginPage
			// 
			this.AcceptButton = this.submit;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 440);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.boxesList);
			this.Controls.Add(this.getinfo);
			this.Controls.Add(this.signout);
			this.Controls.Add(this.log);
			this.Controls.Add(this.submit);
			this.Controls.Add(this.password);
			this.Controls.Add(this.username);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "LoginPage";
			this.Text = "LoginPage";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Button submit;
		private System.Windows.Forms.TextBox log;
		private System.Windows.Forms.Button signout;
		private System.Windows.Forms.Button getinfo;
		private System.Windows.Forms.ListBox boxesList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}