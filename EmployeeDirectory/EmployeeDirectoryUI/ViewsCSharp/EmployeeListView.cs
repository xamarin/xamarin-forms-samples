using System;
using Xamarin.Forms;
using System.Linq;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;
using EmployeeDirectory;

namespace EmployeeDirectoryUI.CSharp
{
	public class EmployeeListView : ContentPage
	{
		private FavoritesViewModel viewModel;
		private IFavoritesRepository favoritesRepository;
		private ListView listView;
		private ToolbarItem toolbarItem;

		public EmployeeListView ()
		{
			toolbarItem = new ToolbarItem ("?", "Search.png", () => {
				var search = new SearchListView ();
				Navigation.PushAsync (search);
			}, 0, 0);

			ToolbarItems.Add (toolbarItem);

			listView = new ListView () {
				IsGroupingEnabled = true,
				GroupHeaderTemplate = new DataTemplate (typeof(GroupHeaderTemplate)),
				ItemTemplate = new DataTemplate (typeof(ListItemTemplate)),
			};

			listView.ItemTapped += OnItemSelected;
			Content = listView;
			Title = "Favorites";
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			if (LoginViewModel.ShouldShowLogin (App.LastUseTime))
				await Navigation.PushModalAsync (new LoginView ());

			favoritesRepository = await XmlFavoritesRepository.OpenIsolatedStorage ("XamarinFavorites.xml");

			if (favoritesRepository.GetAll ().Count () == 0)
				favoritesRepository = await XmlFavoritesRepository.OpenFile ("XamarinFavorites.xml");

			viewModel = new FavoritesViewModel (favoritesRepository, true);
			listView.ItemsSource = viewModel.Groups;
			SetToolbarItems (true);
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			SetToolbarItems (false);
		}

		private void OnItemSelected (object sender, ItemTappedEventArgs e)
		{
			var person = e.Item as Person;
			var selectedEmployee = new EmployeeView {
				BindingContext = new PersonViewModel (person, favoritesRepository)
			};

			Navigation.PushAsync (selectedEmployee);
		}

		private void SetToolbarItems(bool show)
		{
			if (Device.RuntimePlatform != Device.WinPhone)
				return;

			if (show) {
				ToolbarItems.Add (toolbarItem);
			} else {
				ToolbarItems.Remove (toolbarItem);
			}
		}
	}
}
