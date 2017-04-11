using Xamarin.Forms;

namespace PickerDemo
{
	public class PickerItemsPageCS : ContentPage
	{
		public PickerItemsPageCS()
		{
			Title = "Picker Items";
			Icon = "csharp.png";

			var monkeyNameLabel = new Label();

			var picker = new Picker { Title = "Select a monkey" };
			picker.Items.Add("Baboon");
			picker.Items.Add("Capuchin Monkey");
			picker.Items.Add("Blue Monkey");
			picker.Items.Add("Squirrel Monkey");
			picker.Items.Add("Golden Lion Tamarin");
			picker.Items.Add("Howler Monkey");
			picker.Items.Add("Japanese Macaque");

			picker.SelectedIndexChanged += (sender, e) =>
			{
				int selectedIndex = picker.SelectedIndex;
				if (selectedIndex != -1)
				{
					monkeyNameLabel.Text = picker.Items[selectedIndex];
				}
			};

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
					new Label { Text = "Picker - Data in Items Collection", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
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

