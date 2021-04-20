using Xamarin.Forms;

namespace EffectsDemo
{
	public class HomePageCS : ContentPage
	{
		public HomePageCS ()
		{
			var entry = new Entry {
				Text = "Effect attached to an Entry",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = Device.RuntimePlatform == Device.UWP ? 250 : 200
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
