using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Foundation;
using UIKit;

using DependencyServiceSample.iOS;
using CoreImage;

[assembly: Xamarin.Forms.Dependency (typeof (PicturePickerImplementation))]

namespace DependencyServiceSample.iOS
{
    public class PicturePickerImplementation : IPicturePicker
    {
        TaskCompletionSource<Stream> taskCompletionSource;
        UIImagePickerController imagePicker;

        public Task<Stream> GetImageStreamAsync()
        {
            imagePicker = new UIImagePickerController();
            imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled += OnImagePickerCancelled;

            taskCompletionSource = new TaskCompletionSource<Stream>();

            //      UIPopoverController popover = new UIPopoverController(imagePicker);

            UIWindow window = UIApplication.SharedApplication.KeyWindow;
       //     UIViewController rootViewController = window.RootViewController;
         //   var pvc = rootViewController.PresentedViewController;


         //   var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;


/*
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }
*/
            // Present

            vc.PresentModalViewController(imagePicker, true);



        //    vc.NavigationController.PresentModalViewController(imagePicker, true);

            //     UINavigationController navController = new UINavigationController();
            //     navController.PresentModalViewController(imagePicker, true);



            return taskCompletionSource.Task;
        }

        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            // TODO: Check that image and not video!!!!

            // TODO: Check for edited image first!!!!

            // TODO: Can the orienation be fixed?????

            UIImage image = args.OriginalImage;

            var x = image.Orientation;


            

            NSData data = image.AsPNG();
            Stream stream = data.AsStream();

            taskCompletionSource.SetResult(stream);
            imagePicker.DismissModalViewController(true);
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            taskCompletionSource.SetResult(null);
            imagePicker.DismissModalViewController(true);
        }
    }
}

