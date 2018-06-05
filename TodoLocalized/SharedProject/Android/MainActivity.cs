using Android.App;
using Android.OS;

using Xamarin.Forms.Platform.Android;


namespace TodoLocalized
{
    [Activity(Label = "Todo.Android.Android", Theme = "@style/MainTheme", MainLauncher = true)]
    public class MainActivity : FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Instance = this;
            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

