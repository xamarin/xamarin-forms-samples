using System;
using EffectsDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName ("Xamarin")]
[assembly:ExportEffect (typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.Droid
{
	public class LabelShadowEffect : PlatformEffect
	{
		protected override void OnAttached ()
		{
			try {
				var control = Control as Android.Widget.TextView;
				float radius = 5;
				float distanceX = 5;
				float distanceY = 5;
				Android.Graphics.Color color = Color.White.ToAndroid ();
				control.SetShadowLayer (radius, distanceX, distanceY, color);
			} catch (Exception ex) {
				Console.WriteLine ("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached ()
		{
		}
	}
}
