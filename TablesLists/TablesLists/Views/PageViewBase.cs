using System;
using System.Linq;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists
{
	public class PageViewBase : ContentPage
	{
		protected ListView ListView { get; set; }

		public string ItemsSourceFile { get; private set; }

		public PageViewBase (string itemsSourceFile, string title)
		{
			ListView = new ListView ();
			ItemsSourceFile = itemsSourceFile;
			Content = ListView;
			Title = title;
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			var menuItems = await ItemsRepository.OpenIsolatedStorage (ItemsSourceFile);
			var viewModel = new PageViewModel (menuItems);
			ListView.ItemsSource = viewModel.Groups.SelectMany (group => group.Items);
		}
	}
}

