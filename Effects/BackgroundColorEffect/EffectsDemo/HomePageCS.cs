using Xamarin.Forms;

namespace EffectsDemo
{
	public class HomePageCS : ContentPage
	{
		public HomePageCS ()
		{
			double width;
			switch (Device.RuntimePlatform)
			{
				case Device.UWP:
					width = 250;
					break;
				case Device.Tizen:
					width = 340;
					break;
				default:
					width = 220;
					break;
			}

			var entry = new Entry {
				Text = "Effect attached to an Entry",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = width
			};
			entry.Effects.Add (Effect.Resolve ("MyCompany.BackgroundColorEffect"));

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Effects Demo",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.Center
					},
					entry
				}
			};
		}
	}
}
