using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using WorkingWithFiles.WinPhone;

[assembly: Dependency(typeof(SaveAndLoad_WinPhone))]

namespace WorkingWithFiles.WinPhone
{
    public class SaveAndLoad_WinPhone : ISaveAndLoad
    {
		#region ISaveAndLoad implementation

        public async Task SaveTextAsync (string filename, string text)
        {
			StorageFolder localFolder = ApplicationData.Current.LocalFolder;
			IStorageFile file = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
			using (StreamWriter streamWriter = new StreamWriter(file.Path))
			{
				await streamWriter.WriteAsync(text);
			}
        }

		public async Task<string> LoadTextAsync (string filename)
		{
			StorageFolder localFolder = ApplicationData.Current.LocalFolder;
			IStorageFile file = await localFolder.GetFileAsync(filename);
			string text;

			using (StreamReader streamReader = new StreamReader(file.Path))
			{
				text = await streamReader.ReadToEndAsync();
			}
			return text;
		}

        public bool FileExists(string filename)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                localFolder.GetFileAsync(filename).AsTask().Wait ();
                return true;
            }
            catch {
                return false;
            }
        }

        #endregion
    }
}
