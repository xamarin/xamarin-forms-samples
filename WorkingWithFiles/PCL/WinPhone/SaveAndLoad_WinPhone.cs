using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WorkingWithFiles.WinPhone;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad_WinPhone))]

namespace WorkingWithFiles.WinPhone
{
    public class SaveAndLoad_WinPhone : ISaveAndLoad
    {
        public string LoadText(string filename) {
            var task = LoadTextAsync(filename);
            task.Wait();
            return task.Result;
        }
        async Task<string> LoadTextAsync(string filename)
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            if (local != null)
            {
                // Get the file.
                var file = await local.GetItemAsync(filename);

                // Read the data.
                using (StreamReader streamReader = new StreamReader(file.Path))
                {
                   var text = streamReader.ReadToEnd();
                   Debug.WriteLine("loaded text: " + text);
                   return text;
                }
            }
            return "";
        }

        public async void SaveText(string filename, string text)
        {
            Debug.WriteLine("saving this text: " + text);
            // Get the local folder.
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            // Create a new file named DataFile.txt.
            var file = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

            using (StreamWriter writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                writer.Write(text);
            }
        }
    }
}
