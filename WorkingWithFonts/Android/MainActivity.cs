using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Android.Content.PM;


namespace WorkingWithFonts.Android
{
	[Activity (Label = "WorkingWithFonts.Android.Android", Icon = "@drawable/icon", MainLauncher = true, 
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : 
	global::Xamarin.Forms.Platform.Android.FormsApplicationActivity // superclass new in 1.3
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			var label = new TextView (this);


			Typeface font = Typeface.CreateFromAsset (Assets, "SF Hollywood Hills.ttf");
			label.Typeface = font;

			LoadApplication (new App ()); // method is new in 1.3
		}
	}


}

