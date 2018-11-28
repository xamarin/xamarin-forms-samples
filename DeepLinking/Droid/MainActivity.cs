using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Firebase;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace DeepLinking.Droid
{
	[Activity (Label = "DeepLinking.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	[IntentFilter (new[] { Intent.ActionView },
		Categories = new[] 
        {
			Intent.ActionView,
			Intent.CategoryDefault,
			Intent.CategoryBrowsable
		},
        DataScheme = "http",
        DataHost = "deeplinking",
        DataPathPrefix = "/",
        AutoVerify = true)
    ]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
            ToolbarResource = Resource.Layout.Toolbar;
            TabLayoutResource = Resource.Layout.Tabbar;

            base.OnCreate (bundle);

            // Check that the data has been retrieved from google-services.json
            //var apps = FirebaseApp.GetApps(this);

            Xamarin.Forms.Forms.Init(this, bundle);
            FirebaseApp.InitializeApp(this);
            AndroidAppLinks.Init(this);
            LoadApplication (new App ());
		}
	}
}
