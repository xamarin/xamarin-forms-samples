using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Xamarin.Forms;
using Services.Droid;
using DIContainerDemo;
using DIContainerDemo.Droid;

[assembly: Dependency(typeof(PhotoPicker))]
namespace Services.Droid
{
    public class PhotoPicker : IPhotoPicker
    {
        ILogger _logger;

        public PhotoPicker(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<Stream> GetImageStreamAsync()
        {
            _logger.Log("GetImageStreamAsync invoked.");

            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // Get the MainActivity instance
            var activity = MainActivity.Instance;

            // Start the picture-picker activity (resumes in MainActivity.cs)
            activity.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Photo"),
                MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property
            activity.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            // Return Task object
            return activity.PickImageTaskCompletionSource.Task;
        }
    }
}