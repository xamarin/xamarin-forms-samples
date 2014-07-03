using System;
using Xamarin.Forms;
using EmployeeDirectory.Data;

namespace EmployeeDirectoryUI.CSharp
{
	public class GroupHeaderTemplate : ViewCell
	{
		public GroupHeaderTemplate ()
		{
			var label = new Label { YAlign = TextAlignment.Center };
			label.SetBinding (Label.TextProperty, "Title");
			View = new StackLayout {
				Padding = new Thickness (5, 0, 0, 0),
				Children = { label }
			};
		}
	}

	public class ListItemTemplate : ViewCell
	{
		public ListItemTemplate ()
		{
			var photo = new Image { HeightRequest = 44, WidthRequest = 44 };
			photo.SetBinding (Image.SourceProperty, "Photo");

			var nameLabel = new Label { 
				YAlign = TextAlignment.Center,
				Font = Font.SystemFontOfSize (NamedSize.Medium)
			};

			nameLabel.SetBinding (Label.TextProperty, "Name");

			var titleLabel = new Label { 
				YAlign = TextAlignment.Center,
				Font = Font.SystemFontOfSize (NamedSize.Micro)
			};

			titleLabel.SetBinding (Label.TextProperty, "Title");

			var information = new StackLayout {
				Padding = new Thickness (5, 0, 0, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { nameLabel, titleLabel }
			};

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = { photo, information }
			};
		}
	}

	public class DetailsItemTemplate : ViewCell
	{
		public DetailsItemTemplate ()
		{
			var propertyNameLabel = new Label { 
				YAlign = TextAlignment.Center,
				Font = Font.BoldSystemFontOfSize (NamedSize.Medium)
			};

			propertyNameLabel.SetBinding (Label.TextProperty, "Name");

			var propertyValueLabel = new Label { YAlign = TextAlignment.Center };
			propertyValueLabel.SetBinding (Label.TextProperty, "Value");

			View = new StackLayout {
				Padding = new Thickness (20, 0, 0, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { propertyNameLabel, propertyValueLabel }
			};
		}
	}
}

