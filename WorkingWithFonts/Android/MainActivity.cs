using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Android.Graphics;


namespace WorkingWithFonts.Android
{
	[Activity (Label = "WorkingWithFonts.Android.Android", MainLauncher = true)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);

			var label = new TextView (this);


Typeface font = Typeface.CreateFromAsset (Assets, "SF Hollywood Hills.ttf");
label.Typeface = font;

			SetPage (App.GetMainPage ());
		}
	}
}

