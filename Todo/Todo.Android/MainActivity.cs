using Android.App;
using Android.OS;
using Android.Content.PM;

namespace Todo
{
    [Activity(Label = "Todo", Icon = "@drawable/icon", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity :
    global::Xamarin.Forms.Platform.Android.FormsApplicationActivity // superclass new in 1.3
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}
