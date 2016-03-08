using Xamarin.Forms;

namespace EffectsDemo
{
	public class HomePageCS : ContentPage
	{
		public HomePageCS ()
		{
			var label = new Label {
				Text = "Label Shadow Effect",
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			ShadowEffect.SetHasShadow (label, true);
			ShadowEffect.SetColor (label, Device.OnPlatform (Color.Black, Color.White, Color.White));
			ShadowEffect.SetRadius (label, 5);
			ShadowEffect.SetDistanceX (label, 5);
			ShadowEffect.SetDistanceY (label, 5);

			Content = new Grid { 
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Effects Demo",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.Center
					},
					label
				}
			};
		}
	}
}

