using System;
using Xamarin.Forms;

namespace WorkingWithImages
{
	// http://forums.xamarin.com/discussion/17729/image-placeholder

	public class LoadingPlaceholder : ContentPage
	{
		public LoadingPlaceholder ()
		{
			Padding = new Thickness (20);
			Title = "Image Loading Gallery";

			var source = new UriImageSource {
				Uri = new Uri ("http://www.nasa.gov/sites/default/files/styles/1600x1200_autoletterbox/public/images/298773main_EC02-0282-3_full.jpg"),
				CachingEnabled = false
			};

			var image = new Image {
				Source = source,
				WidthRequest = 200,
				HeightRequest = 200,
			};

			var indicator = new ActivityIndicator {Color = new Color (.5),};
			indicator.SetBinding (ActivityIndicator.IsRunningProperty, "IsLoading");
			indicator.BindingContext = image;

			var grid = new Grid();
			grid.RowDefinitions.Add (new RowDefinition());


			grid.Children.Add (image);
			grid.Children.Add (indicator);


			Content = grid;
		}
	}
}

