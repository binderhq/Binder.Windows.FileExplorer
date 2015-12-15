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


		public static void PopulateTreeViewFromServer(TreeView treeView, string[] paths, char pathSeparator, ContextMenuStrip menu)
		{
			TreeNode lastNode = null;
			string subPathAgg;
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
				AddContextMenu(node, menu);
		}

		public static void PopulateTreeViewFromLocal(TreeView treeView, string path, ContextMenuStrip menu)
		{
			treeView.Nodes.Clear();
			try
			{
				var rootDirectoryInfo = new DirectoryInfo(path);
				treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
			}
			catch(UnauthorizedAccessException)
			{
				MessageBox.Show("You do not have permission to access to one or more files in the specified directory.","Unauthorised access",MessageBoxButtons.OK);
			}
			catch(ArgumentException)
			{
				MessageBox.Show("Please specify a valid directory","Directory not found", MessageBoxButtons.OK);
			}
		}


		private static void AddContextMenu(TreeNode node, ContextMenuStrip menu)
		{
			node.ContextMenuStrip = menu;
			foreach (TreeNode subNode in node.Nodes)
				AddContextMenu(subNode, menu);
		}

		public static void CloseSession()
		{
			string url = catalogUrl + "service.api/authentication/Sessions/" + _sessionToken + "?api_key=" + _sessionToken;
			_sessionToken = null;
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

		public static void GetFile(string siteId, string path, string filename, string savePath, ProgressBar progressBar, TextBox log)
		{
			Uri uri = new Uri(catalogUrl + "service.api/region/SiteNavigator/" + siteId + "/File/Contents?path=" + WebUtility.UrlEncode(path) + "&api_key=" + _sessionToken);
			WebClient myWebClient = new WebClient();
			myWebClient.DownloadProgressChanged += (s, e) =>
			{
				progressBar.Value = e.ProgressPercentage;
			};
			myWebClient.DownloadFileCompleted += (s, e) =>
			{
				progressBar.Value = 0;
				log.Text = "Ready.";
			};
			myWebClient.DownloadFileAsync(uri, savePath);
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

//		public class FileDownloadResponseModel
//		{
//			public string Name;
//			public string HiggsFileId;
//			public int Length;
//			public int StorageZoneId;
//			public string FileModifiedTimeUtc;
//		}
	}
}
