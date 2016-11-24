using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using MyCompany.Forms.PlatformConfiguration.iOS;
using MyCompany.Forms.PlatformConfiguration.Android;
using MyCompany.Forms.PlatformConfiguration.UWP;

namespace ShadowPlatformSpecific
{
	public class ShadowPlatformSpecificPageCS : ContentPage
	{
		public ShadowPlatformSpecificPageCS()
		{
			var shadowLabel = new Label { Text = "Label Shadow Effect", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };

			Content = new Grid
			{
				Margin = new Thickness(20),
				Children = {
					new Label { Text = "Effect Exposed by a Platform Specific", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
					shadowLabel
				}
			};

			shadowLabel.On<iOS>().SetIsShadowed(true);
			shadowLabel.On<Android>().SetIsShadowed(true);
			shadowLabel.On<Windows>().SetIsShadowed(true);
		}
	}
}
