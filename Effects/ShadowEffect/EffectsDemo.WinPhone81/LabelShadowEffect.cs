using EffectsDemo.WinPhone81;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ResolutionGroupName ("MyCompany")]
[assembly: ExportEffect (typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace EffectsDemo.WinPhone81
{
	public class LabelShadowEffect : PlatformEffect
	{
		bool shadowAdded = false;

		protected override void OnAttached ()
		{
			try {
				if (!shadowAdded) {
					var textBlock = Control as Windows.UI.Xaml.Controls.TextBlock;

					var shadowLabel = new Label ();
					shadowLabel.Text = textBlock.Text;
					shadowLabel.FontAttributes = FontAttributes.Bold;
					shadowLabel.HorizontalOptions = LayoutOptions.Center;
					shadowLabel.VerticalOptions = LayoutOptions.CenterAndExpand;
					shadowLabel.TextColor = ShadowEffect.GetColor (Element);
					shadowLabel.TranslationX = ShadowEffect.GetDistanceX (Element);
					shadowLabel.TranslationY = ShadowEffect.GetDistanceY (Element);

					((Grid)Element.Parent).Children.Insert (0, shadowLabel);
					shadowAdded = true;
				}
			} catch (Exception ex) {
				Debug.WriteLine ("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached ()
		{
		}
	}
}
