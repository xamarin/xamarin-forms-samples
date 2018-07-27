using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Xamarin.Forms;
using Services.Droid;
using FactoriesDemo;
using FactoriesDemo.Droid;

[assembly: Dependency(typeof(PhotoPicker))]
namespace Services.Droid
{
    public class PhotoPicker : IPhotoPicker
    {
        Context _context;
        ILogger _logger;

        public PhotoPicker(Context context, ILogger logger)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<Stream> GetImageStreamAsync()
        {
            _logger.Log("GetImageStreamAsync invoked.");

            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            var activity = (MainActivity)_context;

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