using System;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Storage;

using Xamarin.Forms;

// Accessing Pictures library requires "Pictures Library" capability in Package.appxmanifest

[assembly: Dependency(typeof(SpinPaint.UWP.SpinPaintDependencyService))]

namespace SpinPaint.UWP
{
    public class SpinPaintDependencyService : ISpinPaintDependencyService
    {
        public async Task<bool> SaveBitmap(byte[] buffer, string filename) //  Stream stream, string filename)
        {
            StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
            StorageFolder spinPaintFolder = null;

            try
            {
                spinPaintFolder = await picturesFolder.GetFolderAsync("SpinPaint");
            }
            catch
            { }

            if (spinPaintFolder == null)
            {
                try
                {
                    spinPaintFolder = await picturesFolder.CreateFolderAsync("SpinPaint");
                }
                catch
                {
                    return false;
                }
            }

            try
            { 
                StorageFile storageFile = await spinPaintFolder.CreateFileAsync(filename);
                //     MemoryStream memoryStream = new MemoryStream();
                //      await stream.CopyToAsync(memoryStream);
                //      memoryStream.Position = 0;


                //                WindowsRuntimeBuffer.Create()

                await FileIO.WriteBufferAsync(storageFile, WindowsRuntimeBuffer.Create(buffer, 0, buffer.Length, buffer.Length)); //  buffer); //  memoryStream.GetWindowsRuntimeBuffer());
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
