using System;
using Xamarin.Forms;

namespace GridLayoutDemo
{
	public class App
	{
		public static Page GetMainPage ()
		{
			return new GridLayoutPage ();
		}
	}

	public class GridLayoutPage : ContentPage
	{
		int count = 1;

		public GridLayoutPage ()
		{
			var layout = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding	= 20	
			};

			var grid = new Grid {
				RowSpacing = 50
			};

			grid.Children.Add (new Label { Text = "This" }, 0, 0); // Left, First element
			grid.Children.Add (new Label { Text = "text is" }, 1, 0); // Right, First element
			grid.Children.Add (new Label { Text = "in a" }, 0, 1); // Left, Second element
			grid.Children.Add (new Label { Text = "grid!" }, 1, 1); // Right, Second element

			var gridButton = new Button { Text = "So is this Button! Click me." };
			gridButton.Clicked += delegate {
				gridButton.Text = string.Format ("Thanks! {0} clicks.", count++);
			};
			grid.Children.Add (gridButton, 0, 2); // Left, Third element

			layout.Children.Add (grid);
			Content = layout;
		}
	}
}

