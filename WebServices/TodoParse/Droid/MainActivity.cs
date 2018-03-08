using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TodoParse.Droid
{
    [Activity(Label = "TodoParse.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);

            App.TodoManager = new TodoItemManager(ParseStorage.Default);
            App.Speech = new Speech();

            LoadApplication(new App());
        }
    }
}
