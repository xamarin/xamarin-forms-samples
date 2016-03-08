using System;
using CoreGraphics;
using EffectsDemo.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ResolutionGroupName ("MyCompany")]
[assembly:ExportEffect (typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.iOS
{
	public class LabelShadowEffect : PlatformEffect
	{
		protected override void OnAttached ()
		{
			try {
				Control.Layer.CornerRadius = (nfloat)ShadowEffect.GetRadius (Element);
				Control.Layer.ShadowColor = ShadowEffect.GetColor (Element).ToCGColor ();
				Control.Layer.ShadowOffset = new CGSize ((double)ShadowEffect.GetDistanceX (Element), (double)ShadowEffect.GetDistanceY (Element));
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
