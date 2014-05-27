using System;
using System.Linq;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class DefaultItem : PageViewBase
	{
		public DefaultItem (string itemsSourceFile, string title) : base (itemsSourceFile, title)
		{
			ListView.ItemTemplate = new DataTemplate (typeof(ItemTemplate));
		}

		public class ItemTemplate : ViewCell
		{
			public ItemTemplate ()
			{
				var titleLabel = new Label {
					Font = Font.SystemFontOfSize (NamedSize.Large),
					YAlign = TextAlignment.Center
				};

				var image = new Image { 
					HorizontalOptions = LayoutOptions.Start 
				};

				titleLabel.SetBinding (Label.TextProperty, "Title");
				image.SetBinding (Image.SourceProperty, "ImageSource");

				View = new StackLayout {
					Orientation = StackOrientation.Horizontal,
					Padding = new Thickness (15, 0, 0, 0),
					Children = { image, titleLabel }
				};

				Height = 50;
			}
		}
	}
}

