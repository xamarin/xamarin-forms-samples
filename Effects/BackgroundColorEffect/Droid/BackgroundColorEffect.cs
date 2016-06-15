using System;
using EffectsDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName ("MyCompany")]
[assembly:ExportEffect (typeof(BackgroundColorEffect), "BackgroundColorEffect")]
namespace EffectsDemo.Droid
{
	public class BackgroundColorEffect : PlatformEffect
	{
		protected override void OnAttached ()
		{
			try {
				Control.SetBackgroundColor (Android.Graphics.Color.LightGreen);
			} catch (Exception ex) {
				Console.WriteLine ("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached ()
		{

		}
	}
}

