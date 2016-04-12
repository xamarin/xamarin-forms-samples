using Xamarin.Forms;

namespace EventToCommandBehavior
{
	public class HomePageCS : ContentPage
	{
		public HomePageCS ()
		{
			BindingContext = new HomePageViewModel ();

			var listView = new ListView ();
			listView.SetBinding (ItemsView<Cell>.ItemsSourceProperty, "People");
			listView.Behaviors.Add (new EventToCommandBehavior {
				EventName = "ItemSelected",
				Command = ((HomePageViewModel)BindingContext).OutputAgeCommand,
				Converter = new SelectedItemEventArgsToSelectedItemConverter ()
			});

			var selectedItemLabel = new Label ();
			selectedItemLabel.SetBinding (Label.TextProperty, "SelectedItemText");

			Content = new StackLayout { 
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Behaviors Demo",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.Center
					},
					listView,
					selectedItemLabel
				}
			};
		}
	}
}
