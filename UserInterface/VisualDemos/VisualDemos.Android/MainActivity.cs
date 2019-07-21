using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace VisualDemos.Droid
{
    [Activity(Label = "VisualDemos", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}