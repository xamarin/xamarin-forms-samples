using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using TablesLists.Data;
using TablesLists.ViewModel;

namespace TablesLists.View
{
	public class MainView : ContentPage
	{
		private PageViewModel viewModel;
		private ListView listView;

		public MainView ()
		{
			listView = new ListView {
				IsGroupingEnabled = true,
				GroupHeaderTemplate = new DataTemplate (typeof(HeaderTemplate)),
				ItemTemplate = new DataTemplate (typeof(ItemTemplate))
			};

			listView.ItemSelected += MenuItemSelected;
			Content = listView;
			Title = "TablesAndLists";
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			var menuItems = await ItemsRepository.OpenIsolatedStorage ("MainMenuItems.xml");
			viewModel = new PageViewModel (menuItems);
			listView.ItemsSource = viewModel.Groups;
		}

		private async void MenuItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var selectedItem = e.SelectedItem as Item;

			if (selectedItem != null) {
				var page = CreateInstance (selectedItem) as ContentPage;
				await Navigation.PushAsync (page);
			}
		}

		private object CreateInstance (Item item)
		{
			var assembly = Assembly.Load (new AssemblyName ("TablesLists"));
			var type = assembly.GetType (item.NavigationPage);

			return Activator.CreateInstance (type, new object[] { item.ItemsSourceFile, item.Title });
		}

		public class HeaderTemplate : ViewCell
		{
			public HeaderTemplate ()
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

		public class ItemTemplate : ViewCell
		{
			public ItemTemplate ()
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

