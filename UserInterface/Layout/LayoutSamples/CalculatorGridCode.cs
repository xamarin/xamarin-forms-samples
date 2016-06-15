using System;

using Xamarin.Forms;

namespace LayoutSamples
{
	public class CalculatorGridCode : ContentPage
	{
		public CalculatorGridCode ()
		{
			Title = "Calculator - C#";
			BackgroundColor = Color.FromHex ("#404040");

			var plainButton = new Style (typeof(Button)) {
				Setters = {
					new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#eee") },
					new Setter { Property = Button.TextColorProperty, Value = Color.Black },
					new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
					new Setter { Property = Button.FontSizeProperty, Value = 40 }
				}
			};
			var darkerButton = new Style (typeof(Button)) {
				Setters = {
					new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#ddd") },
					new Setter { Property = Button.TextColorProperty, Value = Color.Black },
					new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
					new Setter { Property = Button.FontSizeProperty, Value = 40 }
				}
			};
			var orangeButton = new Style (typeof(Button)) {
				Setters = {
					new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#E8AD00") },
					new Setter { Property = Button.TextColorProperty, Value = Color.White },
					new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
					new Setter { Property = Button.FontSizeProperty, Value = 40 }
				}
			};
				
			var controlGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };
			controlGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (150) });
			controlGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Star) });
			controlGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Star) });
			controlGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Star) });
			controlGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Star) });
			controlGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Star) });

			controlGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
			controlGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
			controlGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });
			controlGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) });

			var label = new Label {
				Text = "0",
				HorizontalTextAlignment = TextAlignment.End,
				VerticalTextAlignment = TextAlignment.End,
				TextColor = Color.White,
				FontSize = 60
			};
			controlGrid.Children.Add (label, 0, 0);

			Grid.SetColumnSpan (label, 4);

			controlGrid.Children.Add (new Button { Text = "C", Style = darkerButton }, 0, 1);
			controlGrid.Children.Add (new Button { Text = "+/-", Style = darkerButton }, 1, 1);
			controlGrid.Children.Add (new Button { Text = "%", Style = darkerButton }, 2, 1);
			controlGrid.Children.Add (new Button { Text = "div", Style = orangeButton }, 3, 1);
			controlGrid.Children.Add (new Button { Text = "7", Style = plainButton }, 0, 2);
			controlGrid.Children.Add (new Button { Text = "8", Style = plainButton }, 1, 2);
			controlGrid.Children.Add (new Button { Text = "9", Style = plainButton }, 2, 2);
			controlGrid.Children.Add (new Button { Text = "X", Style = orangeButton }, 3, 2);
			controlGrid.Children.Add (new Button { Text = "4", Style = plainButton }, 0, 3);
			controlGrid.Children.Add (new Button { Text = "5", Style = plainButton }, 1, 3);
			controlGrid.Children.Add (new Button { Text = "6", Style = plainButton }, 2, 3);
			controlGrid.Children.Add (new Button { Text = "-", Style = orangeButton }, 3, 3);
			controlGrid.Children.Add (new Button { Text = "1", Style = plainButton }, 0, 4);
			controlGrid.Children.Add (new Button { Text = "2", Style = plainButton }, 1, 4);
			controlGrid.Children.Add (new Button { Text = "3", Style = plainButton }, 2, 4);
			controlGrid.Children.Add (new Button { Text = "+", Style = orangeButton }, 3, 4);
			controlGrid.Children.Add (new Button { Text = ".", Style = plainButton }, 2, 5);
			controlGrid.Children.Add (new Button { Text = "=", Style = orangeButton }, 3, 5);

			var zeroButton = new Button { Text = "0", Style = plainButton };
			controlGrid.Children.Add (zeroButton, 0, 5);
			Grid.SetColumnSpan (zeroButton, 2);

			Content = controlGrid;
		}
	}
}


