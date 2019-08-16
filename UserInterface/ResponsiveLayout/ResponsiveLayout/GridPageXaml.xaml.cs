using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ResponsiveLayout
{
	public partial class GridPageXaml : ContentPage
	{
		private double width;
		private double height;
		public GridPageXaml ()
		{
			InitializeComponent ();
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

