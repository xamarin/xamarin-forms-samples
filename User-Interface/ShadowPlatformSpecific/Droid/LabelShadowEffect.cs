using MyCompany.Forms.PlatformConfiguration.Android;
using ShadowPlatformSpecific.Droid;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace ShadowPlatformSpecific.Droid
{
	public class LabelShadowEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			UpdateShadow();
		}

		protected override void OnDetached()
		{
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);

			if (args.PropertyName == Shadow.IsShadowedProperty.PropertyName)
			{
				UpdateShadow();
			}
		}

		void UpdateShadow()
		{
			try
			{
				if (((Label)Element).OnThisPlatform().IsShadowed())
				{
					float radius = 5;
					float distanceX = 5;
					float distanceY = 5;
					Android.Graphics.Color color = Android.Graphics.Color.Black;
					(Control as Android.Widget.TextView).SetShadowLayer(radius, distanceX, distanceY, color);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}
	}
}
