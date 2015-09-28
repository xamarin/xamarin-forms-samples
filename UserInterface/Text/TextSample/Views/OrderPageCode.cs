using System;
using Xamarin.Forms;

namespace TextSample
{
	public class OrderPageCode : ContentPage
	{
		public OrderPageCode ()
		{
			Title = "Order Page - Code";
			var grid = new Grid {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (15)
			};
			for (int x = 0; x < 7; x++) {
				grid.RowDefinitions.Add (new RowDefinition{ Height = new GridLength(50) });
			}
			grid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength(90) });
			grid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength (1, GridUnitType.Star) });

			grid.Children.Add (new Label { Text = "Purchaser's Name:" }, 0, 0);
			grid.Children.Add (new Label { Text = "Billing Address:" }, 0, 1);
			grid.Children.Add (new Label { Text = "Tip:", FontAttributes = FontAttributes.Bold }, 0, 2);
			grid.Children.Add (new Label { Text = "Phone Number:" }, 0, 3);
			grid.Children.Add (new Label { Text = "Comments:" }, 0, 4);
			grid.Children.Add (new Entry { Placeholder = "Full Name on Card" }, 1, 0);
			grid.Children.Add (new Editor (), 1, 1);
			grid.Children.Add (new Entry{ Keyboard = Keyboard.Numeric }, 1, 2);
			grid.Children.Add (new Entry { Keyboard = Keyboard.Telephone }, 1, 3);
			grid.Children.Add (new Editor (), 1, 4);

			var fstring = new FormattedString ();
			fstring.Spans.Add (new Span { Text = "Wait! ", ForegroundColor = Color.Red });
			fstring.Spans.Add (new Span { Text = "Please double check that everything is right." });
			grid.Children.Add (new Label { FormattedText = fstring }, 1, 5);
			grid.Children.Add (new Button { TextColor = Color.White, BackgroundColor = Color.Gray, Text = "Save" }, 1, 6);
			Content = grid;
		}
	}
}


