using System.Collections.Generic;
using Xamarin.Forms;

namespace PickerDemo
{
	public class PickerItemsSourcePageCS : ContentPage
	{
		public PickerItemsSourcePageCS()
		{
			Title = "Picker ItemsSource";
			Icon = "csharp.png";

			var monkeyList = new List<string>();
			monkeyList.Add("Baboon");
			monkeyList.Add("Capuchin Monkey");
			monkeyList.Add("Blue Monkey");
			monkeyList.Add("Squirrel Monkey");
			monkeyList.Add("Golden Lion Tamarin");
			monkeyList.Add("Howler Monkey");
			monkeyList.Add("Japanese Macaque");

			var picker = new Picker { Title = "Select a monkey" };
			picker.ItemsSource = monkeyList;

			var monkeyNameLabel = new Label();
			monkeyNameLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: picker));

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
					new Label { Text = "Picker - Data in ItemsSource", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
					picker,
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						Children = {
							new Label { Text = "You chose:"},
							monkeyNameLabel
						}
					}
				}
			};
		}
	}
}
