using System;
using EffectsDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName ("MyCompany")]
[assembly:ExportEffect (typeof(FocusEffect), "FocusEffect")]
namespace EffectsDemo.Droid
{
	public class FocusEffect : PlatformEffect
	{
		Android.Graphics.Color backgroundColor;

		protected override void OnAttached ()
		{
			try {
				backgroundColor = Android.Graphics.Color.LightGreen;
				Control.SetBackgroundColor (backgroundColor);

			} catch (Exception ex) {
				Console.WriteLine ("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached ()
		{
		}

		protected override void OnElementPropertyChanged (System.ComponentModel.PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged (args);
			try {
				if (args.PropertyName == "IsFocused") {
					if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == backgroundColor) {
						Control.SetBackgroundColor (Android.Graphics.Color.Black);
					} else {
						Control.SetBackgroundColor (backgroundColor);
					}
				}
			} catch (Exception ex) {
				Console.WriteLine ("Cannot set property on attached control. Error: ", ex.Message);
			}
		}
	}
}
