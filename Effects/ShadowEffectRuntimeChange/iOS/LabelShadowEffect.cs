using System;
using System.ComponentModel;
using CoreGraphics;
using EffectsDemo.iOS;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ResolutionGroupName ("MyCompany")]
[assembly:ExportEffect (typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.iOS
{
	[Preserve(AllMembers = true)]
	public class LabelShadowEffect : PlatformEffect
	{
		protected override void OnAttached ()
		{
			try {
				UpdateRadius ();
				UpdateColor ();
				UpdateOffset ();
				Control.Layer.ShadowOpacity = 1.0f;
			} catch (Exception ex) {
				Console.WriteLine ("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached ()
		{
		}

		protected override void OnElementPropertyChanged (PropertyChangedEventArgs args)
		{
			if (args.PropertyName == ShadowEffect.RadiusProperty.PropertyName) {
				UpdateRadius ();
			} else if (args.PropertyName == ShadowEffect.ColorProperty.PropertyName) {
				UpdateColor ();
			} else if (args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
			           args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName) {
				UpdateOffset ();
			}
		}

		void UpdateRadius ()
		{
			Control.Layer.CornerRadius = (nfloat)ShadowEffect.GetRadius (Element);
		}

		void UpdateColor ()
		{
			Control.Layer.ShadowColor = ShadowEffect.GetColor (Element).ToCGColor ();
		}

		void UpdateOffset ()
		{
			Control.Layer.ShadowOffset = new CGSize ((double)ShadowEffect.GetDistanceX (Element), (double)ShadowEffect.GetDistanceY (Element));
		}
	}
}
