using System;
using System.Linq;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class TwoLineListItem : PageViewBase
	{
		public TwoLineListItem (string itemsSourceFile, string title) : base (itemsSourceFile, title)
		{
			ListView.ItemTemplate = new DataTemplate (typeof(ItemTemplate));
		}

		public class ItemTemplate : ViewCell
		{
			public ItemTemplate ()
			{
				var titleLabel = new Label {
					Font = Font.BoldSystemFontOfSize (NamedSize.Medium),
					YAlign = TextAlignment.Center
				};

				var subtitleLabel = new Label { 
					Font = Font.SystemFontOfSize (NamedSize.Medium),
					YAlign = TextAlignment.Center
				};

				titleLabel.SetBinding (Label.TextProperty, "Title");
				subtitleLabel.SetBinding (Label.TextProperty, "Subtitle");

				View = new StackLayout {
					Padding = new Thickness (15, 0, 0, 0),
					Children = { titleLabel, subtitleLabel }
				};
				Height = 45;
			}
		}
	}
}

