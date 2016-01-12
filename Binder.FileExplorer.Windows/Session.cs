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
using Binder.API.Region.Foundation.FileAccess;

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
					
					item.Name = dir.FullName;
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
			else if (i >=  0x400) // Kilobyte
			{
				suffix = "KB";
				readable = (double)i;
			}
			else
			{
				return i.ToString(sign + "0 B"); // Byte
			}
			readable = readable / 1024;

			return sign + readable.ToString("0.## ") + suffix;
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

		public async static void GetFile(string siteId, string path, string filename, string savePath, ProgressBar progressBar, TextBox log)
		{
			log.Text = "Preparing download...";
			//todo: find out whats causing the 404
			var downloadRequest = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().CreateSiteNavigatorRequestDownloadAsync(path, siteId);
			var doDownload = await new Binder.APIMatic.Client.Controllers.RegionStorageZonesController()
				.GetStorageZonesGetHiggsFileAsync(filename, downloadRequest.HiggsFileId, downloadRequest.StorageZoneId.ToString());
		}

		public async static void DownloadDirectory(string path, string savePath, ProgressBar progressBar, TextBox log)
		{
				var directory = await GetSiteFilesFolders(currentSelectedSite, path);
				foreach(Binder.APIMatic.Client.Models.SiteFileModel file in directory.Files)
				{
					GetFile(currentSelectedSite, file.Path, file.Name, savePath, progressBar, log);
				}
				foreach(Binder.APIMatic.Client.Models.SubFolder folder in directory.Folders)
				{
					Directory.CreateDirectory(folder.Name);
					string newSavePath = savePath + folder.Name;
					DownloadDirectory(folder.Path, newSavePath, progressBar, log);
				}
		}

		public async static void CloseSession()
		{
			try
			{
				await new Binder.APIMatic.Client.Controllers.AuthenticationSessionsController().DeleteSessionsDeleteAsync(_sessionToken);
			}
			catch { }
			_sessionToken = null;
		}

		public async static void UploadFiles(string uploadTo, string uploadFrom, ProgressBar progressBar, TextBox log)
		{
			long storageZoneId = 1;
			var fileInfo = new FileInfo(uploadFrom);
			log.Text = "Preparing to upload " + fileInfo.Name;
			
			var region = await new Binder.APIMatic.Client.Controllers.RegionCurrentRegionController().GetCurrentRegionGetAsync();
			var storageZone = await new Binder.APIMatic.Client.Controllers.RegionStorageZonesController().GetStorageZonesGetAsync(storageZoneId.ToString());

			StorageEngine storageEngine = StorageEngineFactory.Create(storageZone.HiggsUrl, 
				region.PieceCheckerEndpoint,
				region.FileCompositionEndpoint,
				region.FileRegistrationEndpoint,
				storageZoneId);
			
			using(var fileStream = new FileStream(uploadFrom, FileMode.Open, FileAccess.Read))
			{
				Action<long> progress = (n) => {
						Console.WriteLine(100*(n/fileInfo.Length));
						progressBar.Invoke(new Action(() =>
						{
							progressBar.Maximum = 100;
							progressBar.Value = Convert.ToInt32((100*n)/fileInfo.Length);
							log.Text = "Uploading " + fileInfo.Name + " " + GetSizeReadable(n) + "/" + GetSizeReadable(fileInfo.Length) + " uploaded";
						}));
					};

				var storageResponse = storageEngine.StoreFile(fileStream, progress);

				var options = new Binder.APIMatic.Client.Models.CreateSiteFileVersionOptions()
				{
					Length = fileInfo.Length,
					FileModifiedTimeUtc = fileInfo.LastWriteTimeUtc,
					HiggsFileId = storageResponse.HiggsFileID,
					Name = fileInfo.Name,
					StorageZoneId = storageZoneId.ToString()
				};

				var siteFile = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController()
					.UpdateSiteNavigatorPostAsync(options, uploadTo, currentSelectedSite);

				progressBar.Value = 0;
				log.Text = "Uploaded " + fileInfo.Name;
			}
		}

		public async static void UploadDirectory(string uploadTo, List<string> uploadFrom, ProgressBar progressBar, TextBox log)
		{
			foreach(string item in uploadFrom)
			{
				FileAttributes attr = File.GetAttributes(item);

				if (attr.HasFlag(FileAttributes.Directory))
				{
					try
					{
						DirectoryInfo info = new DirectoryInfo(item);
						string newUploadTo = uploadTo + "/" + info.Name;
						DirectoryInfo[] newUploadFromFolders = info.GetDirectories();
						FileInfo[] newUploadFromFiles = info.GetFiles();

						log.Text = "Creating folder " + info.Name;

						List<string> newUploadFrom = new List<string>();
						foreach(DirectoryInfo folder in newUploadFromFolders)
							newUploadFrom.Add(folder.FullName);
						foreach(FileInfo file in newUploadFromFiles)
							newUploadFrom.Add(file.FullName);
						try
						{ 
							var folderRequest = new Binder.APIMatic.Client.Models.CreateFolderRequest()
								{
									FolderName = info.Name
								};
							var createFolder = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().UpdateSiteNavigatorCreateFolderAsync(folderRequest, uploadTo, currentSelectedSite);
						}
						catch { }
						UploadDirectory(newUploadTo, newUploadFrom, progressBar, log);
					}
					catch(Exception e)
					{
						log.Text = e.Message + " - Skipping upload.";
					}
				}
				else
					UploadFiles(uploadTo, item, progressBar, log);
				//log.Text = "Ready.";
			}
		}

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