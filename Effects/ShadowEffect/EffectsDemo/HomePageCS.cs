using System;
using Xamarin.Forms;

namespace EffectsDemo
{
	public class HomePageCS : ContentPage
	{
		readonly Label label;
		bool isLabelTeal = false;

		public HomePageCS ()
		{
			label = new Label {
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

			var button = new Button { Text = "Change Shadow Color", VerticalOptions = LayoutOptions.EndAndExpand };
			button.Clicked += OnButtonClicked;

			Content = new Grid { 
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Effects Demo",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.Center
					},
					label,
					button
				}
			};
		}

		void OnButtonClicked (object sender, EventArgs args)
		{
			if (isLabelTeal) {
				ShadowEffect.SetColor (label, Device.OnPlatform(Color.Black, Color.White, Color.Red));
				isLabelTeal = false;
			} else {
				ShadowEffect.SetColor (label, Color.Teal);
				isLabelTeal = true;
			}
		}
	}
}
