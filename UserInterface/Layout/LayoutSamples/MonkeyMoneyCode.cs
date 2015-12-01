using System;

using Xamarin.Forms;

namespace LayoutSamples
{
	public class MonkeyMoneyCode : ContentPage
	{
		public MonkeyMoneyCode ()
		{
			Title = "MoneyMoney - C#";
			BackgroundColor = Color.Green;
			//circle buttons
			var outerLayout = new StackLayout{ Padding = new Thickness (0, 10, 0, 0) };
			var topRow = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (10, 0)
			};
			topRow.Children.Add (new Button {
				HeightRequest = 50,
				WidthRequest = 50,
				Text = "?",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				FontSize = 20,
				TextColor = Color.White,
				BackgroundColor = Color.Lime,
				BorderRadius = 25
			});
			topRow.Children.Add (new Button {
				HeightRequest = 50,
				WidthRequest = 50,
				Text = "2",
				HorizontalOptions = LayoutOptions.EndAndExpand,
				FontSize = 20,
				TextColor = Color.White,
				BackgroundColor = Color.Lime,
				BorderRadius = 25
			});
			outerLayout.Children.Add (topRow);
			//big total
			var totalLayout = new StackLayout { VerticalOptions = LayoutOptions.Fill };
			var totalLayoutMiddle = new StackLayout { HorizontalOptions = LayoutOptions.Center };
			totalLayoutMiddle.Children.Add (new Label { FontSize = 100, Text = "$0", TextColor = Color.White });
			totalLayout.Children.Add (totalLayoutMiddle);
			outerLayout.Children.Add (totalLayout);
			//button grid
			var grid = new Grid { VerticalOptions = LayoutOptions.FillAndExpand};
			for (int x = 0; x < 3; x++) { //add three rows and columns
				grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength(1,GridUnitType.Star)});
				grid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star)});
			}
			grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength(1,GridUnitType.Star)}); //fourth row
			int y = 0;
			for (int x = 0; x < 9; x++) {
				grid.Children.Add (new Button {
					Text = (x+1).ToString (),
					TextColor = Color.White,
					FontSize = 20,
					BackgroundColor = Color.Green
				}, x % 3, y); 
				if (x % 3== 2 && x > 0)
					y++;
			}
			grid.Children.Add (new Button {
				Text = "<-",
				TextColor = Color.White,
				FontSize = 20,
				BackgroundColor = Color.Green
			}, 2, 3);
			grid.Children.Add (new Button {
				Text = "0",
				TextColor = Color.White,
				FontSize = 20,
				BackgroundColor = Color.Green
			}, 1, 3);
			outerLayout.Children.Add (grid);
			//bottom buttons
			var bottomButtonLayout = new AbsoluteLayout { VerticalOptions = LayoutOptions.End, BackgroundColor = Color.Green};
			bottomButtonLayout.Children.Add (new Button {
				BackgroundColor = Color.White,
				TextColor = Color.Lime,
				Text = "REQUEST",
				BorderRadius = 0,
				FontSize = 20
			}, new Rectangle (0, 1, .5, 1), AbsoluteLayoutFlags.All);
			bottomButtonLayout.Children.Add (new Button {
				BackgroundColor = Color.White,
				TextColor = Color.Lime,
				Text = "PAY",
				BorderRadius = 0,
				FontSize = 20
			}, new Rectangle (1, 1, .49, 1), AbsoluteLayoutFlags.All);
			outerLayout.Children.Add (bottomButtonLayout);
			Content = outerLayout;
		}
	}
}


