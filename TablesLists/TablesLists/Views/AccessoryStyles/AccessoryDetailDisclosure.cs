using System;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class AccessoryDetailDisclosure : PageViewBase
	{
		public AccessoryDetailDisclosure (string itemsSourceFile, string title) : base (itemsSourceFile, title)
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

		public class ItemTemplate : AccessoryItemTemplate
		{

		}
	}
}

