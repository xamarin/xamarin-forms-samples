using Xamarin.Forms;

namespace MonkeyApp
{
	public class MonkeysPageCS : ContentPage
	{
		public MonkeysPageCS()
		{
			var picker = new Picker { Title = "Select a monkey" };
			picker.SetBinding(Picker.ItemsSourceProperty, "Monkeys");
			picker.SetBinding(Picker.SelectedItemProperty, "SelectedMonkey");
			picker.ItemDisplayBinding = new Binding("Name");

			var nameLabel = new Label { HorizontalOptions = LayoutOptions.Center };
			nameLabel.SetBinding(Label.TextProperty, "SelectedMonkey.Name");
			nameLabel.SetDynamicResource(VisualElement.StyleProperty, "TitleStyle");

			var locationLabel = new Label { FontAttributes = FontAttributes.Italic, HorizontalOptions = LayoutOptions.Center };
			locationLabel.SetBinding(Label.TextProperty, "SelectedMonkey.Location");

			var image = new Image { HeightRequest = 200, WidthRequest = 200, HorizontalOptions = LayoutOptions.CenterAndExpand };
			image.SetBinding(Image.SourceProperty, "SelectedMonkey.ImageUrl");

			var detailsLabel = new Label();
			detailsLabel.SetBinding(Label.TextProperty, "SelectedMonkey.Details");
			detailsLabel.SetDynamicResource(VisualElement.StyleProperty, "BodyStyle");

			Content = new ScrollView
			{
				Content = new StackLayout
				{
					Margin = new Thickness(20),
					Children =
					{
						new Label { Text = "Monkeys", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
						picker,
						nameLabel,
						locationLabel,
						image,
						detailsLabel
					}
				}
			};

			BindingContext = new MonkeysPageViewModel();
		}
	}
}
