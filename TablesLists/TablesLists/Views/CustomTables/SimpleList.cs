using System;
using System.Linq;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;
using System.Collections.Generic;

namespace TablesLists.View
{
	public class SimpleList : PageViewBase
	{
		public SimpleList (string itemsSourceFile, string title) : base (itemsSourceFile, title)
		{
			if (Device.OS == TargetPlatform.Android) {
				Padding = new Thickness (15, 0, 0, 0);
			} else {
				ListView.IsGroupingEnabled = true;
				ListView.ItemTemplate = new DataTemplate (typeof(ItemTemplate));
				ListView.GroupHeaderTemplate = new DataTemplate (typeof(HeaderTemplate));
			}
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			var menuItems = await ItemsRepository.OpenIsolatedStorage (ItemsSourceFile);
			var viewModel = new PageViewModel (menuItems);

			if (Device.OS == TargetPlatform.Android) {
				ListView.ItemsSource = viewModel.Groups.SelectMany (group => group.Items).
					Select (item => item.Title);
			} else {
				ListView.ItemsSource = viewModel.Groups;
			}
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

				View = new StackLayout {
					Padding = new Thickness (15, 10, 0, 0),
					Children = { label }
				};
			}
		}

		public class HeaderTemplate : ViewCell
		{
			public HeaderTemplate ()
			{
				var label = new Label () {
					Font = Font.SystemFontOfSize (NamedSize.Medium)
				};

				label.SetBinding (Label.TextProperty, "Title");

				View = new StackLayout {
					Padding = new Thickness (15, 0, 0, 0),
					Children = { label }
				};
			}
		}
	}
}

