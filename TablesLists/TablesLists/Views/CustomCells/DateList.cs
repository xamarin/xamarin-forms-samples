using System;
using System.Linq;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class DateList : PageViewBase
	{
		public DateList (string itemsSourceFile, string title) : base (itemsSourceFile, title)
		{
			ListView.ItemTemplate = new DataTemplate (typeof(ItemTemplate));
		}

		public class ItemTemplate : ViewCell
		{
			private const int imageSize = 58;

			public ItemTemplate ()
			{
				var titleLabel = new Label {
					Font = Font.SystemFontOfSize (NamedSize.Large)
				};

				var dateLabel = new Label {
					Font = Font.BoldSystemFontOfSize (NamedSize.Medium),
					TextColor = Color.Black,
					XAlign = TextAlignment.Center,
					LineBreakMode = LineBreakMode.WordWrap
				};

				dateLabel.SetBinding (Label.TextProperty, "Subtitle");
				titleLabel.SetBinding (Label.TextProperty, "Title");

				var image = new Image { 
					Source = "Calendar.png",
					WidthRequest = imageSize,
					HeightRequest = imageSize
				};

				var absoluteLayout = new AbsoluteLayout {
					HorizontalOptions = LayoutOptions.Center
				};

				absoluteLayout.Children.Add (image, new Point (0, 0));
				absoluteLayout.Children.Add (dateLabel, new Point (3, 17));

				View = new StackLayout {
					Orientation = StackOrientation.Horizontal,
					Padding = new Thickness (10, 10, 60, 10),
					Children = { absoluteLayout, titleLabel }
				};
			}
		}
	}
}

