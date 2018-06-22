using System;
using System.IO;
using System.Threading.Tasks;

using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

using Xamarin.Forms;

using SkiaSharpFormsDemos.UWP;

[assembly: Dependency(typeof(PhotoLibrary))]
namespace SkiaSharpFormsDemos.UWP
{
    public class PhotoLibrary : IPhotoLibrary
    {
        public async Task<Stream> PickPhotoAsync()
        {
            // Create and initialize the FileOpenPicker
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
            };

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            // Get a file and return a Stream 
            StorageFile storageFile = await openPicker.PickSingleFileAsync();

            if (storageFile == null)
            {
                return null;
            }

            IRandomAccessStreamWithContentType raStream = await storageFile.OpenReadAsync();
            return raStream.AsStreamForRead();
        }

        public Task<bool> SavePhotoAsync(byte[] data, string folder, string filename)
        {
            throw new NotImplementedException();
        }
    }
}