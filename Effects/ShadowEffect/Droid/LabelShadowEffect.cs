using System;
using EffectsDemo;
using EffectsDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName ("MyCompany")]
[assembly:ExportEffect (typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.Droid
{
	public class LabelShadowEffect : PlatformEffect
	{
		protected override void OnAttached ()
		{
			try {
				var control = Control as Android.Widget.TextView;
				float radius = (float)ShadowEffect.GetRadius (Element);
				float distanceX = (float)ShadowEffect.GetDistanceX (Element);
				float distanceY = (float)ShadowEffect.GetDistanceY (Element);
				Android.Graphics.Color color = ShadowEffect.GetColor (Element).ToAndroid ();
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
