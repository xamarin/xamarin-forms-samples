using System;

using Xamarin.Forms;

namespace ResponsiveLayout
{
	public class GridPageCode : ContentPage
	{
		private double width = 0;
		private double height = 0;
		Grid innerGrid;
		Grid controlsGrid;
		public GridPageCode ()
		{
			Title = "Grid - C#";
			var outerGrid = new Grid ();
			innerGrid = new Grid { Padding = new Thickness(10)};
			controlsGrid = new Grid ();
			outerGrid.RowDefinitions.Add (new RowDefinition{ Height = new GridLength (1, GridUnitType.Star) });
			outerGrid.RowDefinitions.Add (new RowDefinition{ Height = new GridLength (60) });

			innerGrid.RowDefinitions.Add (new RowDefinition{ Height = new GridLength (1, GridUnitType.Star) });
			innerGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
			innerGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
			innerGrid.Children.Add (new Image { Source = "deer.jpg", HeightRequest = 300, WidthRequest = 300 }, 0, 0);
			outerGrid.Children.Add (innerGrid, 0, 0);

			controlsGrid.RowDefinitions.Add (new RowDefinition{ Height = new GridLength (1, GridUnitType.Auto) });
			controlsGrid.RowDefinitions.Add (new RowDefinition{ Height = new GridLength (1, GridUnitType.Auto) });
			controlsGrid.RowDefinitions.Add (new RowDefinition{ Height = new GridLength (1, GridUnitType.Auto) });
			controlsGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Auto) });
			controlsGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
			controlsGrid.Children.Add (new Label { Text = "Name:" }, 0, 0);
			controlsGrid.Children.Add (new Label { Text = "Date:" }, 0, 1);
			controlsGrid.Children.Add (new Label { Text = "Tags:" }, 0, 2);
			controlsGrid.Children.Add (new Entry (), 1, 0);
			controlsGrid.Children.Add (new Entry (), 1, 1);
			controlsGrid.Children.Add (new Entry (), 1, 2);

			var buttonsGrid = new Grid ();
			outerGrid.Children.Add (buttonsGrid, 0, 1);

			buttonsGrid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength (1, GridUnitType.Star) });
			buttonsGrid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength (1, GridUnitType.Star) });
			buttonsGrid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength (1, GridUnitType.Star) });
			buttonsGrid.Children.Add (new Button { Text = "Previous" }, 0, 0);
			buttonsGrid.Children.Add (new Button { Text = "Save" }, 1, 0);
			buttonsGrid.Children.Add (new Button { Text = "Next" }, 2, 0);

			Content = outerGrid;
		}
		protected override void OnSizeAllocated (double width, double height){
			base.OnSizeAllocated (width, height);
			if (width != this.width || height != this.height) {
				this.width = width;
				this.height = height;
				if (width > height) {
					innerGrid.RowDefinitions.Clear();
					innerGrid.ColumnDefinitions.Clear ();
					innerGrid.RowDefinitions.Add (new RowDefinition{ Height = new GridLength (1, GridUnitType.Star) });
					innerGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
					innerGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
					innerGrid.Children.Remove (controlsGrid);
					innerGrid.Children.Add (controlsGrid, 1, 0);
				} else {
					innerGrid.ColumnDefinitions.Clear ();

					innerGrid.ColumnDefinitions.Add (new ColumnDefinition{ Width = new GridLength (1, GridUnitType.Star) });
					innerGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) });
					innerGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Star) });
					innerGrid.Children.Remove (controlsGrid);
					innerGrid.Children.Add (controlsGrid, 0, 1);
				}
			}
		}
	}
}


