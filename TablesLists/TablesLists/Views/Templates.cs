using System;
using Xamarin.Forms;

namespace TablesLists.View
{
	public class HeaderTemplate : ViewCell
	{
		public HeaderTemplate ()
		{
			var label = new Label () {
				Font = Font.SystemFontOfSize (NamedSize.Medium)
			};

			label.SetBinding (Label.TextProperty, "Title");

			View = new StackLayout {
				Padding = new Thickness (15, 3, 0, 0),
				Children = { label }
			};
		}
	}

	public class AccessoryItemTemplate : ViewCell
	{
		public AccessoryItemTemplate ()
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
				Children = { image, titleLabel }
			};

			Height = 50;
		}
	}
}

