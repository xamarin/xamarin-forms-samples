using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace UnevenListCells
{
	public class MyViewCell : ViewCell
	{
		public MyViewCell ()
		{
			var image = new Image {
				Source = ImageSource.FromFile ("monkey.jpg"),
				HeightRequest = 50,
			};

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (object sender, EventArgs e) => {
				if (image.HeightRequest < 250) {
					image.HeightRequest = image.Height + 100;
					ForceUpdateSize ();
				}
			};
			image.GestureRecognizers.Add (tapGestureRecognizer);

			var stackLayout = new StackLayout {
				Padding = new Thickness (20, 5, 5, 5),
				Orientation = StackOrientation.Horizontal,
				Children = {
					image,
					new Label { Text = "Monkey", VerticalOptions = LayoutOptions.Center } 
				}
			};

			View = stackLayout;				
		}
	}

	public class HomePageCS : ContentPage
	{
		public HomePageCS ()
		{
			var listView = new ListView { HasUnevenRows = true };
			listView.ItemTemplate = new DataTemplate (typeof(MyViewCell));
			var items = Enumerable.Range (0, 10);
			listView.ItemsSource = items;

			Content = new StackLayout { 
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "HasUnevenRows Dynamic Resizing Demo",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.Center
					},
					listView
				}
			};
		}
	}
}
