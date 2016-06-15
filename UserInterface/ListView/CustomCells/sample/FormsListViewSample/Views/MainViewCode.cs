using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FormsListViewSample
{
	public class MainViewCode : ContentPage
	{
		public ObservableCollection<VeggieViewModel> veggies { get; set; }
		public MainViewCode ()
		{
			veggies = new ObservableCollection<VeggieViewModel> ();
			ListView lstView = new ListView ();
			lstView.RowHeight = 60;
			this.Title = "ListView Code Sample";
			lstView.ItemsSource = veggies;
			lstView.ItemTemplate = new DataTemplate (typeof(CustomVeggieCell));
			Content = lstView;
			veggies.Add (new VeggieViewModel{ Name="Tomato", Type="Fruit", Image="tomato.png"});
			veggies.Add (new VeggieViewModel{ Name="Romaine Lettuce", Type="Vegetable", Image="lettuce.png"});
			veggies.Add (new VeggieViewModel{ Name="Zucchini", Type="Vegetable", Image="zucchini.png"});
		}

		public class CustomVeggieCell : ViewCell
		{
			public CustomVeggieCell()
			{
				AbsoluteLayout cellView = new AbsoluteLayout (){ BackgroundColor= Color.Olive};
				var nameLabel = new Label ();
				nameLabel.SetBinding (Label.TextProperty, new Binding ("Name"));
				AbsoluteLayout.SetLayoutBounds (nameLabel,
					new Rectangle(.25, .25, 400, 40));
				nameLabel.FontSize = 24;
				cellView.Children.Add (nameLabel);
				var typeLabel = new Label ();
				typeLabel.SetBinding (Label.TextProperty, new Binding ("Type"));
				AbsoluteLayout.SetLayoutBounds (typeLabel,
					new Rectangle(50, 35, 200, 25));
				cellView.Children.Add (typeLabel);
				var image = new Image ();
				image.SetBinding (Image.SourceProperty, new Binding ("Image"));
				AbsoluteLayout.SetLayoutBounds (image,
					new Rectangle(250, .25, 200, 25));
				cellView.Children.Add (image);
				this.View = cellView;
			}

		}
	}
}


