using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;

using Xamarin.Forms;
using AssetsLibrary;

[assembly: Dependency(typeof(SpinPaint.iOS.SpinPaintDependencyService))]

namespace SpinPaint.iOS
{
    public class SpinPaintDependencyService : ISpinPaintDependencyService
    {
        public async Task<bool> SaveBitmap(byte[] buffer, string filename)
        {

            ALAssetsLibrary al = new ALAssetsLibrary();

            try
            {
                NSData data2 = NSData.FromArray(buffer);

        //        var x = await al.WriteImageToSavedPhotosAlbumAsync(data2, new NSDictionary());


                UIImage image = UIImage.LoadFromData(data2); //  NSData.FromArray(buffer));

                CoreGraphics.CGImage cgImage = image.CGImage;

                var zz = await al.WriteImageToSavedPhotosAlbumAsync(cgImage, ALAssetOrientation.Down);



       //         image.SaveToPhotosAlbum(null); //  (image55, error55) =>
         //       {
            //        var o = image55 as UIImage;
           //         System.Diagnostics.Debug.WriteLine("error:" + error55);
            //    });
            }
            catch (Exception exc)
            {
                ;
            }




            return true; //  Task.FromResult(true);



            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            string filePath = Path.Combine(folder, filename);

            

            NSData data = NSData.FromArray(buffer);

            NSError error;

            bool result = data.Save(filePath, false, out error);

            ;

            return result; //  Task.FromResult(result);
        }
    }
}