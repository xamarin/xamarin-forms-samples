using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MediaElementDemos.Helpers
{
    public class FileAccess
    {
        // This method copies the video from the app package to the app data
        // directory for your app. To copy the video to the temp directory
        // for your app, comment out the first line of code, and uncomment
        // the second line of code.
        public static async Task CopyVideoIfNotExists(string filename)
        {
            string folder = FileSystem.AppDataDirectory;
            //string folder = Path.GetTempPath();
            string videoFile = Path.Combine(folder, "XamarinVideo.mp4");

            if (!File.Exists(videoFile))
            {
                using (Stream inputStream = await FileSystem.OpenAppPackageFileAsync(filename))
                {
                    using (FileStream outputStream = File.Create(videoFile))
                    {
                        await inputStream.CopyToAsync(outputStream);
                    }
                }
            }
        }
    }
}
