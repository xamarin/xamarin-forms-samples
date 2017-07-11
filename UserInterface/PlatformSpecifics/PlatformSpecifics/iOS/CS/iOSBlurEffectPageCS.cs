using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
	public class iOSBlurEffectPageCS : ContentPage
	{
		public iOSBlurEffectPageCS()
		{
			var boxView = new BoxView { HeightRequest = 300, WidthRequest = 300 };
			var noBlurButton = new Button { Text = "No Blur" };
			noBlurButton.Clicked += (sender, e) => boxView.On<iOS>().UseBlurEffect(BlurEffectStyle.None);
			var extraLightBlurButton = new Button { Text = "Extra Light Blur" };
			extraLightBlurButton.Clicked += (sender, e) => boxView.On<iOS>().UseBlurEffect(BlurEffectStyle.ExtraLight);
			var lightBlurButton = new Button { Text = "Light Blur" };
			lightBlurButton.Clicked += (sender, e) => boxView.On<iOS>().UseBlurEffect(BlurEffectStyle.Light);
			var darkBlurButton = new Button { Text = "Dark Blur" };
			darkBlurButton.Clicked += (sender, e) => boxView.On<iOS>().UseBlurEffect(BlurEffectStyle.Dark);

			Title = "Blur Effect";
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
					new AbsoluteLayout {
						HorizontalOptions = LayoutOptions.Center,
						Children = {
							new Image { Source = "monkeyface.png" },
							boxView
						}
					},
					noBlurButton, extraLightBlurButton, lightBlurButton, darkBlurButton
				}
			};
		}
	}
}
