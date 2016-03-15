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
using Binder.Client.StorageEngine;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
//using Binder.API.Region.Foundation.FileAccess;

namespace Binder.Windows.FileExplorer
{
	public static class Session
	{
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
		public static string currentSelectedSiteName;
		public static CancellationTokenSource cts;
		public static bool isTransferRunning = false;
		public static List<Binder.APIMatic.Client.Models.SiteDetails> sites;

		public async static Task CreateSession(string username, string password)
		{
			Binder.APIMatic.Client.Configuration.BaseUri = Properties.Settings.Default.baseUri;
			var user = await new Binder.APIMatic.Client.Controllers.AuthenticationSessionsController()
				.CreateSessionsPostAsync(new APIMatic.Client.Models.CreateSessionRequest() { Username = username, ClearTextPassword = password });
			Binder.APIMatic.Client.Configuration.ApiKey = user.SessionToken;
			_sessionToken = user.SessionToken;
		}

		public async static Task<Binder.APIMatic.Client.Models.CurrentUserModel> GetCurrentUser()
		{
			var user = await new Binder.APIMatic.Client.Controllers.AuthenticationCurrentUserController().GetCurrentUserGetAsync();
			return user;
		}
		
		public static void PopulateListViewFromServer(ListView list, List<Binder.APIMatic.Client.Models.SubFolder> folders, List<Binder.APIMatic.Client.Models.SiteFileModel> files, ContextMenuStrip menu, ImageList imageList)
		{
			if(folders == null && files == null)
				return;
			Cursor.Current = Cursors.WaitCursor;
			list.Items.Clear();
			ListViewItem.ListViewSubItem[] subItems;
			ListViewItem item = null;
			foreach (Binder.APIMatic.Client.Models.SubFolder folder in folders)
			{
				item = new ListViewItem(folder.Name, 0);
				subItems = new ListViewItem.ListViewSubItem[]
					{new ListViewItem.ListViewSubItem(item, "File folder"),
					new ListViewItem.ListViewSubItem(item, ""), 
					new ListViewItem.ListViewSubItem(item, "")};

				item.Name = folder.Path;
				item.SubItems.AddRange(subItems);
				item.Group = list.Groups[0];
				list.Items.Add(item);
			}
			foreach (Binder.APIMatic.Client.Models.SiteFileModel file in files)
			{
				Icon iconForFile = SystemIcons.WinLogo;
				item = new ListViewItem(file.Name, 1);
				subItems = new ListViewItem.ListViewSubItem[]
					{new ListViewItem.ListViewSubItem(item, ExtensionNamer(Path.GetExtension(file.Name))), 
					new ListViewItem.ListViewSubItem(item, GetSizeReadable((int) file.Length)), 
					new ListViewItem.ListViewSubItem(item, file.LastWriteTimeUtc.ToString())};

				item.SubItems.AddRange(subItems);
				string fileExtension = Path.GetExtension(file.Name);
				if (!imageList.Images.ContainsKey(fileExtension))
				{
					try
					{
						iconForFile = IconTools.GetIconForExtension(fileExtension, ShellIconSize.SmallIcon);
						imageList.Images.Add(fileExtension, iconForFile);
					}
					catch { }
				}
				item.ImageKey = fileExtension;
				item.Name = file.Path;
				item.Group = list.Groups[1];
				if(file.CheckedOutInfo != null)
				{
					item.UseItemStyleForSubItems = true;
					var checkedOutColor = Color.FromArgb(223, 240, 216);
					item.BackColor = checkedOutColor;
					item.ToolTipText = "This item is checked out";
				}
				list.Items.Add(item);
			}
			list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			Cursor.Current = Cursors.Default;
		}

		public static void PopulateListViewFromLocal(ListView list, DirectoryInfo directory, ImageList imageList)
		{
			Cursor.Current = Cursors.WaitCursor;
			list.Items.Clear();
			ListViewItem.ListViewSubItem[] subItems;
			ListViewItem item = null;
			foreach (DirectoryInfo dir in directory.GetDirectories())
			{
				item = new ListViewItem(dir.Name, 0);
				subItems = new ListViewItem.ListViewSubItem[]
					{new ListViewItem.ListViewSubItem(item, "File folder"),
					new ListViewItem.ListViewSubItem(item, ""), 
					new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToString())};
				
				item.Name = dir.FullName;
				item.SubItems.AddRange(subItems);
				item.Group = list.Groups[0];
				list.Items.Add(item);
			}
			foreach (FileInfo file in directory.GetFiles())
			{
				Icon iconForFile = SystemIcons.WinLogo;
				item = new ListViewItem(file.Name, 1);
				subItems = new ListViewItem.ListViewSubItem[]
					{new ListViewItem.ListViewSubItem(item, ExtensionNamer(file.Extension)), 
					new ListViewItem.ListViewSubItem(item, GetSizeReadable(file.Length)), 
					new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToString())};

				item.SubItems.AddRange(subItems);
				if (!imageList.Images.ContainsKey(file.Extension))
				{
					try
					{
						// If not, add the image to the image list.
					//	iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
						if (String.IsNullOrWhiteSpace(file.Extension))
						{
							iconForFile = IconTools.GetIconForExtension("unknownfiletype", ShellIconSize.SmallIcon);
							imageList.Images.Add("unknownfiletype", iconForFile);
						}
						else
						{
							iconForFile = IconTools.GetIconForFile(file.FullName, ShellIconSize.SmallIcon);
							imageList.Images.Add(file.Extension, iconForFile);
						}
					}
					catch { }
				}
				if(String.IsNullOrWhiteSpace(file.Extension))
					item.ImageKey = "unknownfiletype";
				else
					item.ImageKey = file.Extension;
				item.Name = file.FullName;
				item.Group = list.Groups[1];
				list.Items.Add(item);
			}
			list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			Cursor.Current = Cursors.WaitCursor;
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

		public static void CancelTransfer()
		{
			//cts = new CancellationTokenSource();
			cts.Cancel();
		}

		public async static void CloseSession()
		{
			if(!Equals(_sessionToken, null))
			{
				await new Binder.APIMatic.Client.Controllers.AuthenticationSessionsController().DeleteSessionsDeleteAsync(_sessionToken);
				Binder.APIMatic.Client.Configuration.ApiKey = null;
				_sessionToken = null;
			}
		}
		
		public async static Task GetFile(string path, string savePath, ProgressBar progressBar, TextBox log)
		{
			path = WebUtility.UrlEncode(path);
			long storageZoneId = 1;
			log.Text = "Preparing download...";

			var region = await new Binder.APIMatic.Client.Controllers.RegionCurrentRegionController().GetCurrentRegionGetAsync();
			var	storageZone = await new Binder.APIMatic.Client.Controllers.RegionStorageZonesController().GetStorageZonesGetAsync(storageZoneId.ToString());
			var request = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().CreateSiteNavigatorRequestDownloadAsync(path, currentSelectedSite);

			StorageEngine storageEngine = StorageEngineFactory.Create(storageZone.HiggsUrl,
				region.PieceCheckerEndpoint,
				region.FileCompositionEndpoint,
				region.FileRegistrationEndpoint,
				storageZoneId);
			try
			{
				var fileInfo = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().GetSiteNavigatorGetFileAsync(path, currentSelectedSite);
				using (var outputStream = new FileStream(savePath + ".!binder", FileMode.Create, FileAccess.Write))
				{
					try
					{ 
						Action<long> progress = (n) => {
							Console.WriteLine(100*(n/fileInfo.Length));
							progressBar.Invoke(new Action(() =>
							{ 
								progressBar.Maximum = 100;
								progressBar.Value = Convert.ToInt32((100*n)/fileInfo.Length);
								log.Text = "Downloading " + fileInfo.Name + " " + GetSizeReadable(n) + "/" + GetSizeReadable(((long) fileInfo.Length));
							}));
						};

						Task t = Task.Run( () => {
							storageEngine.GetFile(request.HiggsFileId, progress, outputStream, cts.Token);
						}, cts.Token);

						await t;
					}
					catch(Exception err)
					{
						MessageBox.Show(err.Message);
					}

				//	var downloadFile = await new Binder.APIMatic.Client.Controllers.RegionStorageZonesController().GetStorageZonesGetNamedHiggsFileAsync(filename, request.HiggsFileId, storageZoneId.ToString());
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}	
		}

		public async static Task DownloadDirectory(string downloadTo, List<string> downloadFromFolders, List<string> downloadFromFiles, ProgressBar progressBar, TextBox log)
		{
			isTransferRunning = true;
			foreach(string folder in downloadFromFolders)
			{
				try
				{
					var info = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().GetSiteNavigatorGetFolderAsync(WebUtility.UrlEncode(folder), currentSelectedSite);
					string newDownloadTo = downloadTo + "\\" + info.Name.Replace('<', '_')
																.Replace('>', '_')
																.Replace(':', '_')
																.Replace('"', '_')
																.Replace('/', '_')
																.Replace('\\', '_')
																.Replace('|', '_')
																.Replace('*', '_')
																.Replace('?', '_');
					List<Binder.APIMatic.Client.Models.SubFolder> newDownloadFromFolders = info.Folders;
					List<Binder.APIMatic.Client.Models.SiteFileModel> newDownloadFromFiles = info.Files;

					log.Text = "Creating folder " + newDownloadTo;

					List<string> newDownloadFromFoldersPaths = new List<string>();
					List<string> newDownloadFromFilesPaths = new List<string>();
					foreach(Binder.APIMatic.Client.Models.SubFolder subfolder in newDownloadFromFolders)
						newDownloadFromFoldersPaths.Add(subfolder.Path);
					foreach(Binder.APIMatic.Client.Models.SiteFileModel file in newDownloadFromFiles)
						newDownloadFromFilesPaths.Add(file.Path);
					try
					{
						Directory.CreateDirectory(newDownloadTo);
					}
					catch(Exception e)
					{
						MessageBox.Show(e.Message + " - Skipping download");
					}
					if(cts.Token.IsCancellationRequested)
						break;
					await DownloadDirectory(newDownloadTo, newDownloadFromFoldersPaths, newDownloadFromFilesPaths, progressBar, log);
				}
				catch(TaskCanceledException)
				{
					log.Text = "Cancelling...";
				}
				catch(Exception e)
				{
					MessageBox.Show(e.Message + " - Skipping download");
				}
			}
			foreach(string file in downloadFromFiles)
			{
				var info = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().GetSiteNavigatorGetFileAsync(WebUtility.UrlEncode(file), currentSelectedSite);
				string fullPath = downloadTo + "\\" + info.Name.Replace('<', '_')
																.Replace('>', '_')
																.Replace(':', '_')
																.Replace('"', '_')
																.Replace('/', '_')
																.Replace('\\', '_')
																.Replace('|', '_')
																.Replace('*', '_')
																.Replace('?', '_');
				if(!cts.Token.IsCancellationRequested)
					await GetFile(file, fullPath, progressBar, log);
				if(File.Exists(fullPath))
					File.Delete(fullPath);
				if(!cts.Token.IsCancellationRequested)
					File.Move(fullPath + ".!binder", fullPath);
				else
					break;
			}
			isTransferRunning = false;
		}

		public async static Task<Binder.APIMatic.Client.Models.CreateSiteFileVersionOptions> UploadFiles(string uploadTo, string uploadFrom, ProgressBar progressBar, TextBox log)
		{
			long storageZoneId = 1;
			var fileInfo = new FileInfo(uploadFrom);
			log.Text = "Preparing to upload " + fileInfo.Name;
			
			try
			{
				var binderFileInfo = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().GetSiteNavigatorGetFileAsync(uploadTo + "%2F" + fileInfo.Name, currentSelectedSite);
			}
			catch{}

			var region = await new Binder.APIMatic.Client.Controllers.RegionCurrentRegionController().GetCurrentRegionGetAsync();
			var storageZone = await new Binder.APIMatic.Client.Controllers.RegionStorageZonesController().GetStorageZonesGetAsync(storageZoneId.ToString());

			StorageEngine storageEngine = StorageEngineFactory.Create(storageZone.HiggsUrl, 
				region.PieceCheckerEndpoint,
				region.FileCompositionEndpoint,
				region.FileRegistrationEndpoint,
				storageZoneId);
			
			using(var fileStream = new FileStream(uploadFrom, FileMode.Open, FileAccess.Read))
			{
				Action<long> progress = (n) => 
					{
						Console.WriteLine(100*(n/fileInfo.Length));
						progressBar.Invoke(new Action(() =>
						{
							log.Text = "Uploading " + fileInfo.Name + " " + GetSizeReadable(n) + "/" + GetSizeReadable(fileInfo.Length);
							progressBar.Maximum = 100;
							progressBar.Value = Convert.ToInt32((100*n)/fileInfo.Length);

						}));

					};
				Binder.APIMatic.Client.Models.CreateSiteFileVersionOptions options = null;
				
				Task s = Task.Run( () => {
					var storageResponse = storageEngine.StoreFile(fileStream, progress, cts.Token);
					options = new Binder.APIMatic.Client.Models.CreateSiteFileVersionOptions()
					{
						Length = fileInfo.Length,
						FileModifiedTimeUtc = fileInfo.LastWriteTimeUtc,
						HiggsFileId = storageResponse.HiggsFileID,
						Name = fileInfo.Name,
						StorageZoneId = storageZoneId.ToString()
					};
					new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController()
							.UpdateSiteNavigatorPostAsync(options, WebUtility.UrlEncode(uploadTo), currentSelectedSite);
				}, cts.Token);
				
				await s;
				progressBar.Value = 0;


				return options;
			}
		}

		public async static Task UploadDirectory(string uploadTo, List<string> uploadFrom, ProgressBar progressBar, TextBox log)
		{
			isTransferRunning = true;
			if(Equals(uploadTo, "/"))
			{
				MessageBox.Show("Cannot upload to root directory.");
				return;
			}

			foreach(string item in uploadFrom)
			{		
				try
				{
					FileAttributes attr = File.GetAttributes(item);

					if (attr.HasFlag(FileAttributes.Directory))
					{
						DirectoryInfo info = new DirectoryInfo(item);
						string newUploadTo = uploadTo + "/" + info.Name;
						DirectoryInfo[] newUploadFromFolders = info.GetDirectories();
						FileInfo[] newUploadFromFiles = info.GetFiles();

						log.Text = "Creating folder " + newUploadTo;

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
							var createFolder = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().UpdateSiteNavigatorCreateFolderAsync(folderRequest, WebUtility.UrlEncode(uploadTo), currentSelectedSite);
						}
						catch(APIException e)
						{
							if(e.ResponseCode == 409)
								log.Text = "Folder " + item + " already exists.";
							else
								MessageBox.Show("Creation of folder " + item + " failed. " + e.Message);
						}
						catch(Exception e)
						{
							MessageBox.Show("Creation of folder " + item + " failed. " + e.Message);
						}
						try
						{
							if(cts.Token.IsCancellationRequested)
								break;
							await UploadDirectory(newUploadTo, newUploadFrom, progressBar, log);
						}
						catch (Exception e)
						{
							MessageBox.Show("Uploading of file " + newUploadFrom + " to " + newUploadTo + " failed. " + e.Message);
						}
					}
					else
					{
						try
						{
							if(!cts.Token.IsCancellationRequested)
								await UploadFiles(uploadTo, item, progressBar, log);
//							if(cts.Token.IsCancellationRequested)
//							{
//								log.Text = "Cancelling...";
//								Thread.Sleep(2000);
//								DirectoryInfo info = new DirectoryInfo(item);
//								await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().DeleteSiteNavigatorDeleteFileAsync(uploadTo + "/" + info.Name, currentSelectedSite);
//								//This is probably a REALLY BAD idea since it will delete the file even if the user wanted to keep an old version
//							}
						}
						catch (Exception e)
						{
							MessageBox.Show("Uploading of file " + item + " to " + uploadTo + " failed. " + e.Message);
						}
					}
				}
				catch(Exception err)
				{
					MessageBox.Show(err.Message);
				}
			}
			isTransferRunning = false;
		}

		public async static Task<List<Binder.APIMatic.Client.Models.SiteDetails>> CurrentSites()
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
			path = WebUtility.UrlEncode(path);
			try
			{
				var SiteFileFolders = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController()
					.GetSiteNavigatorGetFolderAsync(path, siteId);
				return SiteFileFolders;
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
				return null;
			}
		}

		public async static void IsReadOnly(ToolStripLabel label, string path)
		{
			path = WebUtility.UrlEncode(path);
			var folderInfo = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().GetSiteNavigatorGetFolderAsync(path, currentSelectedSite);
			var permissions = folderInfo.Privileges;

			if(!permissions.Contains("Write"))
			{
				label.Visible = true;
			}
			else
				label.Visible = false;
		}

		public async static Task CreateBinderFolder(string folderName, string path)
		{
			path = WebUtility.UrlEncode(path);
			var request = new Binder.APIMatic.Client.Models.CreateFolderRequest(){ FolderName = folderName };
			var createFolder = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().UpdateSiteNavigatorCreateFolderAsync(request, path, currentSelectedSite);
		}

		public async static Task OpenInBrowser()
		{
			var currentSiteDetails = await new Binder.APIMatic.Client.Controllers.RegionSitesController().GetSitesGetAsync(currentSelectedSite);
			var currentRegion = await new Binder.APIMatic.Client.Controllers.RegionCurrentRegionController().GetCurrentRegionGetAsync();
			string regionUrl = "";
			if(Equals(currentRegion.EcosystemId, "Development"))
				regionUrl = ".edo.cx/";
			else if(Equals(currentRegion.EcosystemId, "Production")) //I'm assuming its Production
				regionUrl = ".binder.com.au/";
			string url = "https://" + currentSiteDetails.Subdomain + regionUrl + "#/Account/PersistSession/" + Binder.APIMatic.Client.Configuration.ApiKey;
			System.Diagnostics.Process.Start(url);
		}

		public async static Task CreateBox(string name)
		{
			var request = new Binder.APIMatic.Client.Models.CreateBoxRequest(){ SiteIdOrSubdomain = currentSelectedSite, Name = name };
			var createBox = await new Binder.APIMatic.Client.Controllers.RegionBoxesController().CreateBoxesCreateBoxAsync(request);
			var userInfo = await new Binder.APIMatic.Client.Controllers.AuthenticationCurrentUserController().GetCurrentUserGetAsync();
			var userSiteInfo = await new Binder.APIMatic.Client.Controllers.RegionSitesController().GetSitesGetUsersAsync(currentSelectedSite);
			string siteUserId = userSiteInfo.Where(x=>x.UserId == userInfo.Id).First().Id;
			var permissionRequest = new Binder.APIMatic.Client.Models.CreateBoxUserRequest(){ SiteUserId = siteUserId, CanWrite = true };
			var setUser = await new Binder.APIMatic.Client.Controllers.RegionBoxesController().CreateBoxesAddBoxUserAsync(createBox.Id, permissionRequest);
		}

		public async static Task DeleteFilesOnBider(List<ListViewItem> items)
		{
			foreach(ListViewItem item in items)
			{
				if(item.ImageIndex == 0)
				{
				//	await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().DeleteSiteNavigatorDeleteFolderAsync(item.Name, currentSelectedSite);
					string url = Binder.APIMatic.Client.Configuration.BaseUri + "region/SiteNavigator/" + currentSelectedSite + "/Folder";
					var msg = await url.SetQueryParams(new { api_key = Binder.APIMatic.Client.Configuration.ApiKey, path = item.Name}).DeleteAsync();
					if(!msg.IsSuccessStatusCode)
						MessageBox.Show("Unable to delete folder.");
				}
				else
				{
				//	await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().DeleteSiteNavigatorDeleteFileAsync(item.Name, currentSelectedSite);
					string url = Binder.APIMatic.Client.Configuration.BaseUri + "region/SiteNavigator/" + currentSelectedSite + "/File";
					var msg = await url.SetQueryParams(new { api_key = Binder.APIMatic.Client.Configuration.ApiKey, path = item.Name}).DeleteAsync();
					if(!msg.IsSuccessStatusCode)
						MessageBox.Show("Unable to delete file");
				}
			}
		}

		public async static Task DeleteFilesOnLocal(List<string> items)
		{
			Task t = Task.Run( () => 
			{
				foreach(string item in items)
				{
					FileAttributes info = File.GetAttributes(item);
					try
					{
						if(info.HasFlag(FileAttributes.Directory))
							FileSystem.DeleteDirectory(item, UIOption.AllDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
						else
							FileSystem.DeleteFile(item, UIOption.AllDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
					}
					catch(Exception err)
					{
						MessageBox.Show(err.Message, "Error");
					}
				}
			});
			await t;
		}

		public async static Task RenameFileOnBinder(string path, string newFilename)
		{
			path = WebUtility.UrlEncode(path);
			var request = new Binder.APIMatic.Client.Models.PatchFileRequest(){NewFileName = newFilename};
			var rename = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().UpdateSiteNavigatorRenameFileAsync(request, path, currentSelectedSite);
		}

		public async static Task RenameFolderOnBinder(string path, string newFolderName)
		{
			path = WebUtility.UrlEncode(path);
			var request = new Binder.APIMatic.Client.Models.RenameFolderRequest(){NewFolderName = newFolderName};
			var rename = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().UpdateSiteNavigatorRenameFolderAsync(path, request, currentSelectedSite);
		}

		public async static Task RenameOnLocal(string path, string oldName, string newName)
		{
			FileAttributes info = File.GetAttributes(path + "\\" + oldName);
			if(info.HasFlag(FileAttributes.Directory))
			{
				Task t = Task.Run( () =>
				{
					try
					{
						Directory.Move(path + "\\" + oldName, path + "\\" + newName);
					}
					catch(IOException){}
					catch(Exception err)
					{
						MessageBox.Show(err.Message, "Error");
					}
				});
				await t;
			}
			else
			{
				Task t = Task.Run( () =>
				{
					try
					{
						File.Move(path + "\\" + oldName, path + "\\" + newName);
					}
					catch(IOException){}
					catch(Exception err)
					{
						MessageBox.Show(err.Message, "Error");
					}
				});
				await t;
			}
		}
		
		public async static Task PreviewFile(string path)
		{
			path = WebUtility.UrlEncode(path);
			var response = await new Binder.APIMatic.Client.Controllers.RegionSiteNavigatorController().GetSiteNavigatorGetOpenInWebInfoAsync(path, currentSelectedSite);
			System.Diagnostics.Process.Start(response.Url);
		}

		public async static Task CheckOutFile(string remotePath, string pathOnMachine)
		{
			var request = new Binder.APIMatic.Client.Models.CheckOutFileRequest()
								{
									SiteIdOrSubdomain = currentSelectedSite,
									RemotePath = remotePath,
									PathOnMachine = pathOnMachine,
									MachineName = System.Environment.MachineName
								};

			await new Binder.APIMatic.Client.Controllers.RegionCheckedOutFilesController().CreateCheckedOutFiesCheckOutFileAsync(request);
		}

		public async static Task CheckInFile(Binder.APIMatic.Client.Models.CreateSiteFileVersionOptions uploadResponse)
		{
			var response = await new Binder.APIMatic.Client.Controllers.RegionCheckedOutFilesController().GetCheckedOutFiesFindMatchingAsync(currentSelectedSite);
			var checkedOutFile = response.Where(x => x.LogicalFileModel.Name == uploadResponse.Name).FirstOrDefault();
			var request = new Binder.APIMatic.Client.Models.CheckInFileRequest()
								{
									Name = uploadResponse.Name,
									Length = (int) uploadResponse.Length,
									LastModified = uploadResponse.FileModifiedTimeUtc,
									HiggsFileId = uploadResponse.HiggsFileId
								};

			await new Binder.APIMatic.Client.Controllers.RegionCheckedOutFilesController().DeleteCheckedOutFiesCheckInFileAsync(checkedOutFile.Id, request, false);
		}

		public async static Task ClearCheckin(string fileName)
		{
			var response = await new Binder.APIMatic.Client.Controllers.RegionCheckedOutFilesController().GetCheckedOutFiesFindMatchingAsync(currentSelectedSite);
			var checkedOutFile = response.Where(x => x.LogicalFileModel.Name == fileName).FirstOrDefault();
			var request = new Binder.APIMatic.Client.Models.CheckInFileRequest()
								{
									Name = fileName
								};

			await new Binder.APIMatic.Client.Controllers.RegionCheckedOutFilesController().DeleteCheckedOutFiesCheckInFileAsync(checkedOutFile.Id, request, true);
		}

		public static void CompareListViewsForCheckIn(ListView remoteList, ListView localList)
		{
			List<ListViewItem> remoteListItems = new List<ListViewItem>();
			List<ListViewItem> localListItems = new List<ListViewItem>();
			foreach(ListViewItem item in remoteList.Items)
				remoteListItems.Add(item);
			foreach(ListViewItem item in localList.Items)
			{
				item.BackColor = Color.White;
				localListItems.Add(item);
			}

			List<ListViewItem> checkedOutItems = remoteListItems.Where(x => x.BackColor.Name != "Window").ToList();
			List<ListViewItem> matchedItems = localListItems.Where(x => checkedOutItems.Any(y => y.Text == x.Text)).ToList();
			var checkedOutColor = Color.FromArgb(223, 240, 216);
			foreach(ListViewItem item in matchedItems)
			{
				item.BackColor = checkedOutColor;
				item.ToolTipText = "This item is checked out";
			}
		}

		public class KonamiSequence
		{
			List<Keys> Keys = new List<Keys>{System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.Up,
										System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.Down, 
										System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.Right, 
										System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.Right, 
										System.Windows.Forms.Keys.B, System.Windows.Forms.Keys.A};
			private int mPosition = -1;
			public int Position
			{
				get { return mPosition; }
				private set { mPosition = value; }
			}
			public bool IsCompletedBy(Keys key)
			{
				if (Keys[Position + 1] == key)
					Position++;
				else if (Position == 1 && key == System.Windows.Forms.Keys.Up){}
				else if (Keys[0] == key)
					Position = 0;
				else
					Position = -1;
				if (Position == Keys.Count - 1)
				{
					Position = -1;
					return true;
				}
				return false;
			}
		}
	}
}