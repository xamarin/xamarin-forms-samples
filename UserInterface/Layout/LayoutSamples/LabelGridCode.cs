using System;

using Xamarin.Forms;

namespace LayoutSamples
{
	public class LabelGridCode : ContentPage
	{
		public LabelGridCode ()
		{
			Grid grid = new Grid ();
			Title = "Label Grid Demo - C#";
			Label topLeft = new Label { FontSize = 20, Text = "Top Left" };
			Label topRight = new Label { FontSize = 20, Text = "Top Right" };
			Label bottomLeft = new Label { FontSize = 20, Text = "Bottom Left" };
			Label bottomRight = new Label { FontSize = 20, Text = "Bottom Right" };
			grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Star) });
			grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
			grid.Children.Add (topLeft, 0, 0);
			grid.Children.Add (topRight, 1, 0);
			grid.Children.Add (bottomLeft, 0, 1);
			grid.Children.Add (bottomRight, 1, 1);
			Content = grid;
		}
	}
}


