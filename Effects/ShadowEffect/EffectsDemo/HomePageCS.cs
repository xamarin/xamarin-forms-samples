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
			label.Effects.Add (new ShadowEffect {
				Radius = 5,
				Color = Device.OnPlatform (Color.Black, Color.White, Color.Red),
				DistanceX = 5,
				DistanceY = 5
			});

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
