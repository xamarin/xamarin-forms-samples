using System.Collections.Generic;
using Xamarin.Forms;

namespace BindingContextChanged
{
	public class ListPageCS : ContentPage
	{
		public ListPageCS ()
		{
			var customCell = new DataTemplate (typeof(CustomCell));
			customCell.SetBinding (CustomCell.TitleProperty, ".");

			var listView = new ListView {
				ItemsSource = new List<string> { "Apples", "Oranges", "Pears", "Bananas", "Mangos" },
				ItemTemplate = customCell
			};

			Content = new StackLayout { 
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Binding Context Changed Demo",
						HorizontalOptions = LayoutOptions.Center,
						FontAttributes = FontAttributes.Bold
					},
					listView
				}
			};
		}
	}
}
