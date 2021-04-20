using System;

using Xamarin.Forms;

namespace LayoutSamples
{
	public class StackLayoutDemoCode : ContentPage
	{
		int currentState = 0;
		int maxStates = 2;
		StackLayout layout;
		Button StackChangeButton;
		public StackLayoutDemoCode ()
		{
			Title = "StackLayout Demo - C#";
			layout = new StackLayout { Spacing = 0 };
			StackChangeButton = new Button {
				Text = "Spacing: 0",
				FontSize = 20,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			StackChangeButton.Clicked += StackChangeButton_Clicked;
			BoxView yellowBox = new BoxView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Color = Color.Yellow
			};
			BoxView greenBox = new BoxView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Color = Color.Green
			};
			BoxView blueBox = new BoxView {
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Color = Color.Blue,
				HeightRequest = 75
			};
			layout.Children.Add (StackChangeButton);
			layout.Children.Add (yellowBox);
			layout.Children.Add (greenBox);
			layout.Children.Add (blueBox);
			Content = layout;
		}
			
		void StackChangeButton_Clicked (object sender, EventArgs e)
		{
			currentState++;
			if (currentState > maxStates) {
				currentState = 0;
			}

			switch (currentState) {
			case 0:
				layout.Spacing = 0;
				StackChangeButton.Text = "Spacing: 0";
				break;
			case 1:
				layout.Spacing = 1;
				StackChangeButton.Text = "Spacing: 1";
				break;
			case 2:
				layout.Spacing = 10;
				StackChangeButton.Text = "Spacing: 10";
				break;
			}


		}

	}
}


