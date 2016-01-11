using System;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Drawing;
using Binder.APIMatic.Client;

namespace Binder.Windows.FileExplorer
{
	public static class Session
	{
		public const string catalogUrl = "https://development.edocx.com.au:443/";

		public static string SessionToken
		{
			get
			{
				if(String.IsNullOrWhiteSpace(_sessionToken)) 
				{
					throw new IOException();
				}
				else {
					return _sessionToken;
				} 

			}
		}
		private static string _sessionToken;
		public static string currentSelectedSite;
		public static List<Binder.APIMatic.Client.Models.SiteDetails> sites;

		public async static Task<Binder.APIMatic.Client.Models.CreateSessionResponse> CreateSession(string username, string password)
		{
			Binder.APIMatic.Client.Configuration.BaseUri = "https://development.edocx.com.au:443/service.api/";
			var user = await new Binder.APIMatic.Client.Controllers.AuthenticationSessionsController()
				.CreateSessionsPostAsync(new APIMatic.Client.Models.CreateSessionRequest() { Username = username, ClearTextPassword = password });
			Binder.APIMatic.Client.Configuration.ApiKey = user.SessionToken;
			_sessionToken = user.SessionToken;
			return user;
		}

		public static void PopulateTreeViewFromServer(TreeView treeView, ImageList images, string[] paths, char pathSeparator, ContextMenuStrip menu)
		{
			TreeNode lastNode = null;
			string subPathAgg;
			treeView.ImageList = images;
			foreach (string path in paths)
			{
				subPathAgg = string.Empty;
				foreach (string subPath in path.Split(pathSeparator))
				{
					subPathAgg += subPath + pathSeparator;
					TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
					if (nodes.Length == 0)
						if (lastNode == null)
							lastNode = treeView.Nodes.Add(subPathAgg, subPath);
						else
							lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
					else
						lastNode = nodes[0];
				}
				lastNode = null;

			}
			foreach (TreeNode node in treeView.Nodes)
			{
				NodeImager(node, menu);
			}
		}

		public static void PopulateListViewFromServer(ListView list, List<Binder.APIMatic.Client.Models.SubFolder> folders, List<Binder.APIMatic.Client.Models.SiteFileModel> files, ContextMenuStrip menu, ImageList imageList)
		{
			list.Items.Clear();
			ListViewItem.ListViewSubItem[] subItems;
			ListViewItem item = null;
			try
			{
				foreach (Binder.APIMatic.Client.Models.SubFolder folder in folders)
				{
					item = new ListViewItem(folder.Name, 0);
					subItems = new ListViewItem.ListViewSubItem[]
						{new ListViewItem.ListViewSubItem(item, "File folder"),
						new ListViewItem.ListViewSubItem(item, ""), 
						new ListViewItem.ListViewSubItem(item, "")};

					item.SubItems.AddRange(subItems);
					list.Items.Add(item);
				}
				foreach (Binder.APIMatic.Client.Models.SiteFileModel file in files)
				{
					item = new ListViewItem(file.Name, 1);
					subItems = new ListViewItem.ListViewSubItem[]
						{new ListViewItem.ListViewSubItem(item, ExtensionNamer(Path.GetExtension(file.Name))), 
						new ListViewItem.ListViewSubItem(item, GetSizeReadable((int) file.Length)), 
						new ListViewItem.ListViewSubItem(item, file.LastWriteTimeUtc.ToString())};

					item.SubItems.AddRange(subItems);
					list.Items.Add(item);
					item.Name = file.Path;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		public static void PopulateTreeViewFromLocal(TreeView treeView, ImageList images, string path, ContextMenuStrip menu)
		{
			treeView.Nodes.Clear();
			treeView.ImageList = images;
			try
			{
				var rootDirectoryInfo = new DirectoryInfo(path);
				treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
			}
//			catch(UnauthorizedAccessException)
//			{
//				MessageBox.Show("You do not have permission to access to one or more files in the specified directory.","Unauthorised access",MessageBoxButtons.OK);
//			}
			catch(ArgumentException)
			{
				MessageBox.Show("Please specify a valid directory","Directory not found", MessageBoxButtons.OK);
			}
			foreach (TreeNode node in treeView.Nodes)
				NodeImager(node);
		}

		public static void PopulateListViewFromLocal(ListView list, DirectoryInfo directory, ImageList imageList)
		{
			list.Items.Clear();
			ListViewItem.ListViewSubItem[] subItems;
			ListViewItem item = null;
			try
			{
				foreach (DirectoryInfo dir in directory.GetDirectories())
				{
					item = new ListViewItem(dir.Name, 0);
					subItems = new ListViewItem.ListViewSubItem[]
						{new ListViewItem.ListViewSubItem(item, "File folder"),
						new ListViewItem.ListViewSubItem(item, ""), 
						new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString())};

					item.SubItems.AddRange(subItems);
					list.Items.Add(item);
				}
				foreach (FileInfo file in directory.GetFiles())
				{
					Icon iconForFile = SystemIcons.WinLogo;
					item = new ListViewItem(file.Name, 1);
					iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
					subItems = new ListViewItem.ListViewSubItem[]
						{new ListViewItem.ListViewSubItem(item, ExtensionNamer(file.Extension)), 
						new ListViewItem.ListViewSubItem(item, GetSizeReadable(file.Length)), 
						new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToString())};

					item.SubItems.AddRange(subItems);
					if (!imageList.Images.ContainsKey(file.Extension))
					{
						// If not, add the image to the image list.
						iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
						imageList.Images.Add(file.Extension, iconForFile);
					}
					item.ImageKey = file.Extension;
					item.Name = file.FullName;
					list.Items.Add(item);
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

			list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private static string ExtensionNamer(string ext)
		{
			if(Equals(ext, ""))
				return "Unknown file type";
			else
				return ext.ToUpper().TrimStart('.') + " file";
		}

		public static string GetSizeReadable(long i)
		{
			string sign = (i < 0 ? "-" : "");
			double readable = (i < 0 ? -i : i);
			string suffix;
			if (i >= 0x1000000000000000) // Exabyte
			{
				suffix = "EB";
				readable = (double)(i >> 50);
			}
			else if (i >= 0x4000000000000) // Petabyte
			{
				suffix = "PB";
				readable = (double)(i >> 40);
			}
			else if (i >= 0x10000000000) // Terabyte
			{
				suffix = "TB";
				readable = (double)(i >> 30);
			}
			else if (i >= 0x40000000) // Gigabyte
			{
				suffix = "GB";
				readable = (double)(i >> 20);
			}
			else if (i >= 0x100000) // Megabyte
			{
				suffix = "MB";
				readable = (double)(i >> 10);
			}
			else if (i >= 0x400) // Kilobyte
			{
				suffix = "KB";
				readable = (double)i;
			}
			else
			{
				return i.ToString(sign + "0 B"); // Byte
			}
			readable = readable / 1024;

			return sign + readable.ToString("0.### ") + suffix;
		}

		private static void NodeImager(TreeNode node)
		{
			if (node.Nodes.Count > 0)
			{
				node.ImageIndex = 0;
				node.SelectedImageIndex = 0;
			}
			else
			{
				node.ImageIndex = 1;
				node.SelectedImageIndex = 1;
			}
			foreach (TreeNode subNode in node.Nodes)
			{
				NodeImager(subNode);
			}
		}

		private static void NodeImager(TreeNode node, ContextMenuStrip menu)
		{
			if (node.Nodes.Count > 0)
			{
				node.ImageIndex = 0;
				node.SelectedImageIndex = 0;
			}
			else
			{
				AddContextMenu(node, menu);
				node.ImageIndex = 1;
				node.SelectedImageIndex = 1;
			}
			foreach (TreeNode subNode in node.Nodes)
			{
				NodeImager(subNode, menu);
			}
		}

		private static void AddContextMenu(TreeNode node, ContextMenuStrip menu)
		{
			node.ContextMenuStrip = menu;
			foreach (TreeNode subNode in node.Nodes)
				AddContextMenu(subNode, menu);
		}

		public static void GetFile(string siteId, string path, string filename, string savePath, ProgressBar progressBar, TextBox log)
		{
			log.Text = "Preparing...";
			Uri uri = new Uri(catalogUrl + "service.api/region/SiteNavigator/" + siteId + "/File/Contents?path=" + WebUtility.UrlEncode(path) + "&api_key=" + _sessionToken);
			WebClient myWebClient = new WebClient();
			myWebClient.DownloadProgressChanged += (s, e) =>
			{
				progressBar.Value = e.ProgressPercentage;
				log.Text = e.ProgressPercentage.ToString() + "% complete";
			};
			myWebClient.DownloadFileCompleted += (s, e) =>
			{
				progressBar.Value = 0;
				log.Text = "Ready.";
			};
			myWebClient.DownloadFileAsync(uri, savePath);
		}

		public async static void CloseSession()
		{
			await new Binder.APIMatic.Client.Controllers.AuthenticationSessionsController().DeleteSessionsDeleteAsync(_sessionToken);
			_sessionToken = null;
		}

		public static void UploadFiles(string uploadTo, string uploadFrom, string filename)
		{
			string url = catalogUrl + "service.api/region/SiteNavigator/" + currentSelectedSite + "/Folder/UploadedFiles?path=" + WebUtility.UrlEncode(uploadTo) + "&api_key=" + _sessionToken;
			PostFileAsync(url, uploadFrom, filename);
		}

	//Code from mckay
		public static Task<HttpResponseMessage> PostFileAsync(this Url url, string filepath, string filename)
		{
			return new FlurlClient(url).PostFileAsync(filepath, filename);
		}

		public static Task<HttpResponseMessage> PostFileAsync(this string url, string filepath, string filename)
		{
			return new FlurlClient(url).PostFileAsync(filepath, filename);
		}

		public static Task<HttpResponseMessage> PostFileAsync(this FlurlClient client, string filepath, string filename)
		{
			var data = File.ReadAllBytes(filepath);
			var content = new MultipartFormDataContent();
			var file = new ByteArrayContent(data);
			//content.Headers.Add("Content-Type", "multipart/form-data");
			//content.Headers.Add("Content-Length", data.Length.ToString());
			//content.Add(file, "attachment", "a.txt");
			content.Add(file, "upload", filename);
			return client.SendAsync(HttpMethod.Post, content: content);
		}
	//End McKay's code

		public async static Task<List<Binder.APIMatic.Client.Models.SiteDetails>>CurrentSites()
		{
			var availableSites = await new Binder.APIMatic.Client.Controllers.RegionRegionCurrentUserController().GetRegionCurrentUserAccessibleSitesAsync();
			return availableSites.ConnectedSites;
		}
		
		private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
		{
			var directoryNode = new TreeNode(directoryInfo.Name);
			try
			{
				foreach (var directory in directoryInfo.GetDirectories())
					directoryNode.Nodes.Add(CreateDirectoryNode(directory));
				foreach (var file in directoryInfo.GetFiles())
					directoryNode.Nodes.Add(new TreeNode(file.Name));
				return directoryNode;
			}
			catch (DirectoryNotFoundException)
			{
				return null;
			}
		}

		public async static Task<Binder.APIMatic.Client.Models.SiteFolderModel> GetSiteFilesFolders(string siteId, string path)
		{
			var SiteFileFolders = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController()
				.GetSiteNavigatorGetFolderAsync(path, siteId);
			return SiteFileFolders;
		}
	}
}
