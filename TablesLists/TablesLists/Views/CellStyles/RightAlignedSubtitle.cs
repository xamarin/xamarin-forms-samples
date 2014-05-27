using System;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class RightAlignedSubtitle : PageViewBase
	{
		public RightAlignedSubtitle (string itemsSourceFile, string title) : base (itemsSourceFile, title)
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
					Font = Font.SystemFontOfSize (NamedSize.Medium),
					YAlign = TextAlignment.Center
				};

				var subtitleLabel = new Label { 
					Font = Font.SystemFontOfSize (NamedSize.Medium),
					YAlign = TextAlignment.Center,
					XAlign = TextAlignment.End,
					TextColor = Color.Gray
				};

				var image = new Image {
					HorizontalOptions = LayoutOptions.Center,
					HeightRequest = 30,
					WidthRequest = 50
				};

				titleLabel.SetBinding (Label.TextProperty, "Title");
				subtitleLabel.SetBinding (Label.TextProperty, "Subtitle");
				image.SetBinding (Image.SourceProperty, "ImageSource");

				var gridView = new Grid {
					Padding = new Thickness (10, 10, 60, 10)
				};

				gridView.Children.Add (image, 0, 0);
				gridView.Children.Add (titleLabel, 1, 0);
				gridView.Children.Add (subtitleLabel, 2, 0);

				var columnDef = new ColumnDefinition {
					Width = GridLength.Auto
				};

				var collection = new ColumnDefinitionCollection {
					columnDef,
					columnDef
				};

				columnDef = new ColumnDefinition {
					Width = new GridLength (10, GridUnitType.Star)
				};

				collection.Add (columnDef);

				gridView.ColumnDefinitions = collection;

				View = gridView;
			}
		}
	}
}

