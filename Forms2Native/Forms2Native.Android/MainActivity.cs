using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace Forms2Native
{
	/// <summary>
	/// Android app starts with Xamarin.Forms, then opens a natively rendered Page
	/// </summary>
	[Activity (Label = "Forms2Native", MainLauncher = true)]
	public class Activity1 : Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}


