using System;
using System.ComponentModel;
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
		Android.Widget.TextView control;
		Android.Graphics.Color color;
		float radius, distanceX, distanceY;

		protected override void OnAttached ()
		{
			try {
				control = Control as Android.Widget.TextView;
				UpdateRadius ();
				UpdateColor ();
				UpdateOffset ();
				UpdateControl ();
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
				UpdateControl ();
			} else if (args.PropertyName == ShadowEffect.ColorProperty.PropertyName) {
				UpdateColor ();
				UpdateControl ();
			} else if (args.PropertyName == ShadowEffect.DistanceXProperty.PropertyName ||
			           args.PropertyName == ShadowEffect.DistanceYProperty.PropertyName) {
				UpdateOffset ();
				UpdateControl ();
			}
		}

		void UpdateControl ()
		{
			if (control != null) {
				control.SetShadowLayer (radius, distanceX, distanceY, color);
			}
		}

		void UpdateRadius ()
		{
			radius = (float)ShadowEffect.GetRadius (Element);
		}

		void UpdateColor ()
		{
			color = ShadowEffect.GetColor (Element).ToAndroid ();
		}

		void UpdateOffset ()
		{
			distanceX = (float)ShadowEffect.GetDistanceX (Element);
			distanceY = (float)ShadowEffect.GetDistanceY (Element);
		}
	}
}
