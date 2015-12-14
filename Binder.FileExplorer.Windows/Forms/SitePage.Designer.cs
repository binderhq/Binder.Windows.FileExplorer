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
			this.sitesList = new System.Windows.Forms.ListBox();
			this.selectSite = new System.Windows.Forms.Button();
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
			this.sitesList.TabIndex = 0;
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
			// SitePage
			// 
			this.AcceptButton = this.selectSite;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(303, 387);
			this.Controls.Add(this.selectSite);
			this.Controls.Add(this.sitesList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SitePage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select a site";
			this.Load += new System.EventHandler(this.SitePage_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox sitesList;
		private System.Windows.Forms.Button selectSite;
	}
}