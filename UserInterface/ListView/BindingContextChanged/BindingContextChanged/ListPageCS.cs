using System.Collections.Generic;
using Xamarin.Forms;

namespace BindingContextChanged
{
	public class ListPageCS : ContentPage
	{
		public ListPageCS ()
		{
			var customCell = new DataTemplate (typeof(CustomCell));
			customCell.SetBinding (CustomCell.NameProperty, "Name");
			customCell.SetBinding (CustomCell.AgeProperty, "Age");
			customCell.SetBinding (CustomCell.LocationProperty, "Location");

			var listView = new ListView {
				ItemTemplate = customCell
			};

			var button = new Button { Text = "Change Binding Context" };
			button.Clicked += (sender, e) => {
				var people = new List<Person> {
					new Person ("Steve", 21, "USA"),
					new Person ("John", 37, "USA"),
					new Person ("Tom", 42, "UK"),
					new Person ("Lucas", 29, "Germany"),
					new Person ("Tariq", 39, "UK"),
					new Person ("Jane", 30, "USA")
				};

				listView.ItemsSource = people;
			};

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Binding Context Changed Demo",
						HorizontalOptions = LayoutOptions.Center,
						FontAttributes = FontAttributes.Bold
					},
					listView,
					button
				}
			};
		}
	}
}
