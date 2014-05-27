using System;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class ContactStyleItem : PageViewBase
	{
		public ContactStyleItem (string itemsSourceFile, string title) : base (itemsSourceFile, title)
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
			ListView.ItemsSource = viewModel.Groups;
		}

		public class ItemTemplate : ViewCell
		{
			public ItemTemplate ()
			{
				var titleLabel = new Label {
					Font = Font.SystemFontOfSize (NamedSize.Small),
					YAlign = TextAlignment.Center,
					XAlign = TextAlignment.End,
					TextColor = Color.Blue
				};

				var subtitleLabel = new Label {
					Font = Font.SystemFontOfSize (NamedSize.Small),
					YAlign = TextAlignment.Center,
					XAlign = TextAlignment.Start
				};

				titleLabel.SetBinding (Label.TextProperty, "Title");
				subtitleLabel.SetBinding (Label.TextProperty, "Subtitle");

				var gridView = new Grid {
					Padding = new Thickness (20, 10, 40, 10)
				};

				gridView.Children.Add (titleLabel, 0, 0);
				gridView.Children.Add (subtitleLabel, 1, 0);

				var collection = new ColumnDefinitionCollection {
					new ColumnDefinition { Width = new GridLength (10, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (10, GridUnitType.Star) }
				};

				gridView.ColumnDefinitions = collection;

				View = gridView;
			}
		}
	}
}

