using System;
using System.Linq;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class ImageAndSubtitle : PageViewBase
	{
		public ImageAndSubtitle (string itemsSourceFile, string title) : base (itemsSourceFile, title)
		{
			ListView.ItemTemplate = new DataTemplate (typeof(ItemTemplate));
		}

		public class ItemTemplate : ViewCell
		{
			public ItemTemplate ()
			{
				var titleLabel = new Label {
					Font = Font.SystemFontOfSize (NamedSize.Medium),
					YAlign = TextAlignment.Center
				};

				var subtitleLabel = new Label { 
					Font = Font.SystemFontOfSize (NamedSize.Micro),
					YAlign = TextAlignment.Center
				};

				var image = new Image {
					HorizontalOptions = LayoutOptions.Center,
					HeightRequest = 30,
					WidthRequest = 50
				};
						
				titleLabel.SetBinding (Label.TextProperty, "Title");
				subtitleLabel.SetBinding (Label.TextProperty, "Subtitle");
				image.SetBinding (Image.SourceProperty, "ImageSource");

				var imageStack = new StackLayout {
					Orientation = StackOrientation.Vertical,
					BackgroundColor = Color.White,
					Padding = new Thickness (0, 10, 0, 0),
					Children = { image }
				};

				var labelsStack = new StackLayout {
					Children = { titleLabel, subtitleLabel }
				};

				View = new StackLayout {
					Orientation = StackOrientation.Horizontal,
					Padding = new Thickness (15, 0, 0, 0),
					Children = { imageStack, labelsStack }
				};

				Height = 50;
			}
		}
	}
}

