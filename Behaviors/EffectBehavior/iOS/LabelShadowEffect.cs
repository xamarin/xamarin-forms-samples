using System;
using CoreGraphics;
using EffectsDemo.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ResolutionGroupName ("Xamarin")]
[assembly:ExportEffect (typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.iOS
{
	public class LabelShadowEffect : PlatformEffect
	{
		protected override void OnAttached ()
		{
			try {
				Control.Layer.CornerRadius = 5;
				Control.Layer.ShadowColor = Color.Black.ToCGColor ();
				Control.Layer.ShadowOffset = new CGSize (5, 5);
				Control.Layer.ShadowOpacity = 1.0f;
			} catch (Exception ex) {
				Console.WriteLine ("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached ()
		{
		}
	}
}
