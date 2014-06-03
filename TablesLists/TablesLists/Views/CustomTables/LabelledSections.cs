using System;
using System.Linq;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class LabelledSections : PageViewBase
	{
		public LabelledSections (string itemsSourceFile, string title) : base (itemsSourceFile, title)
		{
			ListView.IsGroupingEnabled = true;
			ListView.ItemTemplate = new DataTemplate (typeof(ItemTemplate));
			ListView.GroupHeaderTemplate = new DataTemplate (typeof(HeaderTemplate));
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			var menuItems = await ItemsRepository.OpenIsolatedStorage (ItemsSourceFile);
			var viewModel = new PageViewModel (menuItems);
			var items = viewModel.Groups.SelectMany (group => group.Items);
			ListView.ItemsSource = ItemsGroup.GroupAlphabetically (items);
		}

		public class ItemTemplate : ViewCell
		{
			public ItemTemplate ()
			{
				var label = new Label () {
					YAlign = TextAlignment.End,
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};

				label.SetBinding (Label.TextProperty, "Title");

				var stackLayout = new StackLayout {
					Padding = new Thickness (15, 0, 0, 0),
					Children = { label }
				};

				if (Device.OS == TargetPlatform.Android) {
					label.Font = Font.BoldSystemFontOfSize (NamedSize.Small);
					stackLayout.Padding = new Thickness (15, 10, 0, 0);
					Height = 25;
				}

				View = stackLayout;
			}
		}

		public class HeaderTemplate : ViewCell
		{
			public HeaderTemplate ()
			{
				var label = new Label { 
					YAlign = TextAlignment.Center
				};

				label.SetBinding (Label.TextProperty, "Title");

				var stackView = new StackLayout {
					Padding = new Thickness (0, 10, 0, 0),
					Children = { label }
				};

				View = stackView;

				if (Device.OS == TargetPlatform.Android) {
					label.Font = Font.SystemFontOfSize (NamedSize.Large);
					stackView.Padding = new Thickness (15, 10, 0, 0);
					Height = 50;
				}
			}
		}
	}
}

