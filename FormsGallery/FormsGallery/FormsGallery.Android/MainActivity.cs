using Android.App;
using Android.Content.PM;
using Android.OS;

namespace FormsGallery.Droid
{
    [Activity(Label = "FormsGallery", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.SetFlags(new string[] {"SwipeView_Experimental", "IndicatorView_Experimental", "CarouselView_Experimental", "MediaElement_Experimental" });
            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

