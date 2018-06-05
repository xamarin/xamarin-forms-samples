using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TodoParse.Droid
{
    [Activity(Label = "TodoParse.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);

            App.TodoManager = new TodoItemManager(ParseStorage.Default);
            App.Speech = new Speech();

            LoadApplication(new App());
        }
    }
}
