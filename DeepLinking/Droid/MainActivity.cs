using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace DeepLinking.Droid
{
	[Activity (Label = "DeepLinking.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	[IntentFilter (new[] { Intent.ActionView },
		Categories = new[] {
			Intent.ActionView,
			Intent.CategoryDefault,
			Intent.CategoryBrowsable
		},
		DataScheme = "http",
		DataHost = "DeepLinking",
		DataPathPrefix = "/deeplinking/")
	]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			AndroidAppLinks.Init (this);

			LoadApplication (new App ());
		}
	}
}
