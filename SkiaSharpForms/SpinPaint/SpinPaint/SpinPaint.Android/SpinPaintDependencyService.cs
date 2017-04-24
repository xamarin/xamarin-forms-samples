using System.Threading.Tasks;

using Android.OS;
using Java.IO;

using Xamarin.Forms;

// Requires android.permission.WRITE_EXTERNAL_STORAGE in AndroidManifest.xml

[assembly: Dependency(typeof(SpinPaint.Droid.SpinPaintDependencyService))]

namespace SpinPaint.Droid
{
    public class SpinPaintDependencyService : ISpinPaintDependencyService
    {
        public Task<bool> SaveBitmap(byte[] buffer, string filename)
        {
            try
            {
                File spinPaintDirectory = new File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "SpinPaint");
                spinPaintDirectory.Mkdirs();

                using (File bitmapFile = new File(spinPaintDirectory, filename))
                {
                    bitmapFile.CreateNewFile();
                    using (FileOutputStream outputStream = new FileOutputStream(bitmapFile))
                    {
                        //      System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                        //      await stream.CopyToAsync(memoryStream);
                        //     memoryStream.Position = 0;

                        outputStream.Write(buffer); //  memoryStream.GetBuffer());
                    }
                }
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true); //  true;
        }
    }
}