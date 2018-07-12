using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Android.Content.PM;

namespace WorkingWithImages.Droid
{
	[Activity (Label = "WorkingWithImages", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, 
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : 
	global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity // superclass new in 1.3
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ()); // method is new in 1.3
		}
	}
		
}

