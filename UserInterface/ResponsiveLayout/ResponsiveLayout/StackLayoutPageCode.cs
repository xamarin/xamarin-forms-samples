using System;

using Xamarin.Forms;

namespace ResponsiveLayout
{
	public class StackLayoutPageCode : ContentPage
	{
		private double width;
		private double height;
		StackLayout outerStack;

		public StackLayoutPageCode ()
		{
			Title = "StackLayout - C#";
			outerStack = new StackLayout { Spacing = 10, Padding = 5, Orientation = StackOrientation.Vertical };
			var scrollview = new ScrollView ();
			outerStack.Children.Add (scrollview);
			outerStack.Children.Add (new Image { Source = "deer.jpg" });

			var innerStack = new StackLayout {
				Spacing = 5,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				WidthRequest = 1000
			};
			scrollview.Content = innerStack;
			var nameStack = new StackLayout { Orientation = StackOrientation.Horizontal };
			var dateStack = new StackLayout { Orientation = StackOrientation.Horizontal };
			var tagStack = new StackLayout { Orientation = StackOrientation.Horizontal };
			var saveStack = new StackLayout { Orientation = StackOrientation.Horizontal };

			innerStack.Children.Add (nameStack);
			innerStack.Children.Add (dateStack);
			innerStack.Children.Add (tagStack);
			innerStack.Children.Add (saveStack);

			nameStack.Children.Add (new Label {
				Text = "Name:",
				FontSize = 20,
				WidthRequest = 75,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center
			});
			nameStack.Children.Add (new Entry { Text = "deer.jpg", HorizontalOptions = LayoutOptions.FillAndExpand });

			dateStack.Children.Add (new Label {
				Text = "Date:",
				FontSize = 20,
				WidthRequest = 75,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center
			});
			dateStack.Children.Add (new Entry { Text = "07/05/2015", HorizontalOptions = LayoutOptions.FillAndExpand });

			tagStack.Children.Add (new Label {
				Text = "Tags:",
				FontSize = 20,
				WidthRequest = 75,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center
			});
			tagStack.Children.Add (new Entry { Text = "deer, tiger", HorizontalOptions = LayoutOptions.FillAndExpand });

			saveStack.Children.Add (new Button {
				Text = "Save",
				HorizontalOptions = LayoutOptions.FillAndExpand
			});

			Content = outerStack;
		}

		protected override void OnSizeAllocated (double width, double height){
			base.OnSizeAllocated (width, height);
			if (width != this.width || height != this.height) {
				this.width = width;
				this.height = height;
				if (width > height) {
					outerStack.Orientation = StackOrientation.Horizontal;
				} else {
					outerStack.Orientation = StackOrientation.Vertical;
				}
			}
		}
	}
}


