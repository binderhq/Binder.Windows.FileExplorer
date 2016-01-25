namespace Binder.Windows.FileExplorer.Forms
{
	partial class SitePage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SitePage));
			this.sitesList = new System.Windows.Forms.ListBox();
			this.selectSite = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// sitesList
			// 
			this.sitesList.Dock = System.Windows.Forms.DockStyle.Top;
			this.sitesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sitesList.FormattingEnabled = true;
			this.sitesList.ItemHeight = 20;
			this.sitesList.Location = new System.Drawing.Point(0, 0);
			this.sitesList.Name = "sitesList";
			this.sitesList.Size = new System.Drawing.Size(303, 344);
			this.sitesList.Sorted = true;
			this.sitesList.TabIndex = 0;
			this.sitesList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sitesList_KeyUp);
			this.sitesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sitesList_MouseDoubleClick);
			// 
			// selectSite
			// 
			this.selectSite.Location = new System.Drawing.Point(188, 352);
			this.selectSite.Name = "selectSite";
			this.selectSite.Size = new System.Drawing.Size(103, 23);
			this.selectSite.TabIndex = 1;
			this.selectSite.Text = "OK";
			this.selectSite.UseVisualStyleBackColor = true;
			this.selectSite.Click += new System.EventHandler(this.selectSite_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 352);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(103, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Return to login";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// SitePage
			// 
			this.AcceptButton = this.selectSite;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(303, 387);
			this.ControlBox = false;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.selectSite);
			this.Controls.Add(this.sitesList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SitePage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select a site";
			this.Load += new System.EventHandler(this.SitePage_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox sitesList;
		private System.Windows.Forms.Button selectSite;
		private System.Windows.Forms.Button button1;
	}
}