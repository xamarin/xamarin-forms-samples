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
				WidthRequest = Device.RuntimePlatform == Device.UWP ? 250 : 220
			};
			entry.Effects.Add (Effect.Resolve ("Xamarin.FocusEffect"));

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Effects Demo - Focus Effect",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.Center
					},
					entry
				}
			};
		}
	}
}
