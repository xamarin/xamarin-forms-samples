using System;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PanGesture.Droid
{
	[Activity (Label = "PanGesture.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			var width = Resources.DisplayMetrics.WidthPixels;
			var height = Resources.DisplayMetrics.HeightPixels;
			var density = Resources.DisplayMetrics.Density;

			App.ScreenWidth = (width - 0.5f) / density;
			App.ScreenHeight = (height - 0.5f) / density;

			LoadApplication (new App ());
		}
	}
}
