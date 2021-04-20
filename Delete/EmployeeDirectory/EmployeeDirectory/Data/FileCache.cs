using System;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using PCLStorage;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace EmployeeDirectory
{
    public static class FileCache
    {
        private static IFolder folder;
        private static JeffWilcox.Utilities.Silverlight.MD5 md5;
        private static object locker = new object();
        private static Dictionary<string, Task<bool>> downloadTasks = new Dictionary<string, Task<bool>>();

        static FileCache()
        {
            Init();
        }

        static async void Init()
        {
            md5 = JeffWilcox.Utilities.Silverlight.MD5.Create("MD5");
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            await rootFolder.CreateFolderAsync("Cache", CreationCollisionOption.OpenIfExists).ContinueWith(createFolderTask =>
            {
                createFolderTask.Wait();
                folder = createFolderTask.Result;
            });
        }

        public static async Task<string> Download(string url)
        {
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(url.Trim()));
            var fileName = string.Join("", hash.Select(x => x.ToString("x2")));

            return await Download(url, fileName);
        }

        public static async Task<string> Download(Uri url, string email)
        {
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(email.Trim()));
            var fileName = string.Join("", hash.Select(x => x.ToString("x2")));

            return await Download(url.AbsoluteUri, fileName);
        }

        public static async Task<string> Download(string url, string fileName)
        {
            try
            {
                var path = Path.Combine(folder.Path, fileName);
                var exists = await folder.CheckExistsAsync(fileName);
                if (exists == ExistenceCheckResult.FileExists && !downloadTasks.ContainsKey(path))
                {
                    return path;
                }

                var succes = await GetDownload(url, path);
                return succes ? path : "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "";
            }
        }

        private static Task<bool> GetDownload(string url, string fileName)
        {
            lock (locker)
            {
                Task<bool> task;
                if (downloadTasks.TryGetValue(fileName, out task))
                    return task;

                downloadTasks.Add(fileName, task = download(url, fileName));
                return task;
            }
        }

        private static async Task<bool> download(string url, string fileName)
        {
            IFile file = null;
            try
            {
                var client = new HttpClient();
                var data = await client.GetByteArrayAsync(url);
                var fileNamePaths = fileName.Split('\\');
                fileName = fileNamePaths[fileNamePaths.Length - 1];
                file = await FileSystem.Current.LocalStorage.CreateFileAsync(fileName,
                    CreationCollisionOption.ReplaceExisting);
                using (var fileStream = await file.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
                {
                    fileStream.Write(data, 0, data.Length);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            if (file != null)
                await file.DeleteAsync();
            return false;
        }
    }
}

