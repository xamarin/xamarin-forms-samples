using System.Threading.Tasks;
using Android.Content;
using Xamarin.Forms;

[assembly:Dependency(typeof(MediaElementDemos.Droid.VideoPicker))]
namespace MediaElementDemos.Droid
{
    public class VideoPicker : IVideoPicker
    {
        public Task<string> GetVideoFileAsync()
        {
            // Defint eht Intent for getting images
            Intent intent = new Intent();
            intent.SetType("video/*");
            intent.SetAction(Intent.ActionGetContent);

            // Get the MainActivity instance
            MainActivity activity = MainActivity.Current;

            // Start the picture-picker activity (resumes in MainActivity.cs)
            activity.StartActivityForResult(Intent.CreateChooser(intent, "SelectVideo"), MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property;
            activity.PickImageTaskCompletionSource = new TaskCompletionSource<string>();

            // Return Task object
            return activity.PickImageTaskCompletionSource.Task;
        }
    }
}
