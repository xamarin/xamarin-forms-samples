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
			label.Behaviors.Add (new EffectBehavior {
				Group = "Xamarin",
				Name = "LabelShadowEffect"
			});

			Content = new Grid { 
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Effects Demo with a Behavior",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.Center
					},
					label
				}
			};
		}
	}
}

