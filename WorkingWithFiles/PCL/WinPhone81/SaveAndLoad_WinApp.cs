using System;
using System.Threading.Tasks;
using Windows.Storage;
using WinPhone81;
using WorkingWithFiles;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad_WinApp))]

namespace WinPhone81
{
    // https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh758325.aspx

    public class SaveAndLoad_WinApp : ISaveAndLoad
    {

        #region ISaveAndLoad implementation

        public async Task SaveTextAsync(string filename, string text)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, text);
        }

        public async Task<string> LoadTextAsync(string filename)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            return text;
        }

        public bool FileExists(string filename)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                localFolder.GetFileAsync(filename).AsTask().Wait();
                return true;
            }
            catch
            {
                return false;
            }
        }



        #endregion
    }
}
