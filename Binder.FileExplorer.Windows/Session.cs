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
		public static string ResponseMessage;
		public static bool isSuccessful;
		public static string currentSelectedSite;
		public static string[] siteNames;
		public static string[] siteIds;

		public static void CreateSession(string username, string password)
		{
			try
			{
				string ApiUrl = catalogUrl + "service.api/authentication/Sessions";
				var response = ApiUrl.PostJsonAsync( new { Username = username, ClearTextPassword = password }).Result;
				isSuccessful = response.IsSuccessStatusCode;

				if(isSuccessful)
				{
					var x = response.Content.ReadAsStringAsync().Result;
					var y = JsonConvert.DeserializeObject<CreateSessionResponse>(x);
					_sessionToken = y.SessionToken;
//					ResponseMessage = "Login successful";
				}
				else
				{
					throw new ArgumentNullException();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Invalid username or password", "Login error", MessageBoxButtons.OK);
			}

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
						new ListViewItem.ListViewSubItem(item, file.Length + "B"), 
						new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToString())};

					item.SubItems.AddRange(subItems);
					if (!imageList.Images.ContainsKey(file.Extension))
					{
						// If not, add the image to the image list.
						iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
						imageList.Images.Add(file.Extension, iconForFile);
					}
					item.ImageKey = file.Extension;
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

		//TODO: Get zip file downloads working properly - THIS DOES NOT WORK AT THE MOMENT
		public static void GetZipFile(string path, string savePath, ProgressBar progressBar, TextBox log)
		{
			log.Text = "Preparing...";
			var zipId = ZipFileRequest(currentSelectedSite, path).Id;
			Uri uri = new Uri(catalogUrl + "service.api/region/ZipFileRequests/" + zipId + "/Contents?api_key=" + _sessionToken);
			Uri uri2 = new Uri(catalogUrl + "service.api/region/ZipFileRequests/" + zipId + "?api_key=" + _sessionToken);
			WebClient myWebClient = new WebClient();
			bool isReady = false;

			myWebClient.OpenReadAsync(uri2);

			while(!isReady && !myWebClient.IsBusy)
			{
				isReady = ZipBuildComplete(zipId, savePath, log, progressBar);
			}
			if(isReady)
			{
				log.Text = "Downloading...";
				myWebClient.DownloadFileAsync(uri, savePath);
				log.Text = "Ready.";
				progressBar.Value = 0;
			}

		}

		public static void CloseSession()
		{
			string url = catalogUrl + "service.api/authentication/Sessions/" + _sessionToken + "?api_key=" + _sessionToken;
			_sessionToken = null;
			isSuccessful = false;
		}

		private static bool ZipBuildComplete(string zipId, string savePath, TextBox log, ProgressBar progressBar)
		{
			int percentComplete = ZipFileCheck(zipId).ProgressPercent;
			if (percentComplete == 100)
			{
				log.Text = "Zip creation complete.";
				return true;
			}
			else if (percentComplete > 0)
			{
				progressBar.Value = percentComplete;
				log.Text = percentComplete.ToString() + "% built";
				return false;
			}
			else
			{
				log.Text = "Zip file creation " + ZipFileCheck(zipId).Status;
				return false;
			}
		}
		
		public static CurrentUserInfo CurrentUser()
		{
			string url = catalogUrl + "service.api/authentication/CurrentUser?api_key=" + _sessionToken;
			var response = url.GetAsync().Result;
			var x1 = response.Content.ReadAsStringAsync().Result;
			var y1 = JsonConvert.DeserializeObject<CurrentUserInfo>(x1);
			return y1;
		}

		public static CurrentRegionUserSitesResponse CurrentSites()
		{
			string url = catalogUrl + "service.api/region/RegionCurrentUser/Sites?api_key=" + _sessionToken;
			var response = url.GetAsync().Result;
			var x2 = response.Content.ReadAsStringAsync().Result;
			var y2 = JsonConvert.DeserializeObject<CurrentRegionUserSitesResponse>(x2);
			return y2;
		}

		public static ShortFileInfo[] GetDirectory(string siteID)
		{
			string url = catalogUrl + "service.api/region/SiteNavigator/" + siteID + "/Folder/AllFiles?path=%2F&api_key=" + _sessionToken;
			var response = url.GetAsync().Result;
			var x = response.Content.ReadAsStringAsync().Result;
			var y = JsonConvert.DeserializeObject<ShortFileInfo[]>(x);
			return y;
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

		public static ZipFileRequestModel ZipFileRequest(string siteId, string path)
		{
			string url = catalogUrl + "service.api/region/ZipFileRequests?api_key=" + _sessionToken;
			var response = url.PostJsonAsync( new { SiteIdOrSubdomain = siteId, SourcePath = path }).Result;
			var x = response.Content.ReadAsStringAsync().Result;
			var y = JsonConvert.DeserializeObject<ZipFileRequestModel>(x);
			return y;
		}

		public static ZipFileRequestModel ZipFileCheck(string zipId)
		{
			string url = catalogUrl + "service.api/region/ZipFileRequests/" + zipId + "?api_key=" + _sessionToken;
			var response = url.GetAsync().Result;
			var x = response.Content.ReadAsStringAsync().Result;
			var y = JsonConvert.DeserializeObject<ZipFileRequestModel>(x);
			return y;
		}

		public class CurrentRegionUserSitesResponse
		{
			public SiteDetails[] ConnectedSites;
		}
		
		public class SiteDetails
		{
			public SiteModel Site;
		}

		public class SiteModel
		{
			public string Id;
			public string Name;
			public string Subdomain;
			public string DefautStorageZoneId;
		}

		public class CreateSessionResponse
		{
			public string UserId;
			public string Username;
			public string SessionToken;
		}

		public class CurrentUserInfo
		{
			public string Username;
			public string EmailAddress;
			public string Name;
		}

		public class ShortFileInfo
		{
			public string RemoteFilePath;
			public int Length;
		}

		public class ZipFileRequestModel
		{
			public string Id;
			public int ProgressPercent;
			public string OutputFilename;
			public string Status;
		} 
	}
}
