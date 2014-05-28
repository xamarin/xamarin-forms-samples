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

		public EmployeeListView ()
		{
			var toolBarItem = new ToolbarItem ("?", "Search.png", () => {
				var search = new SearchListView ();
				Navigation.PushAsync (search);
			}, 0, 0);

			ToolbarItems.Add (toolBarItem);

			listView = new ListView () {
				IsGroupingEnabled = true,
				GroupHeaderTemplate = new DataTemplate (typeof(GroupHeaderTemplate)),
				ItemTemplate = new DataTemplate (typeof(ListItemTemplate)),
			};

			listView.ItemTapped += OnItemSelected;
			Content = listView;
			Title = "Employee Directory";
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			if (LoginViewModel.ShouldShowLogin (App.LastUseTime))
				await Navigation.PushAsync (new LoginView ());

			favoritesRepository = await XmlFavoritesRepository.OpenIsolatedStorage ("XamarinFavorites.xml");

			if (favoritesRepository.GetAll ().Count () == 0)
				favoritesRepository = await XmlFavoritesRepository.OpenFile ("XamarinFavorites.xml");

			viewModel = new FavoritesViewModel (favoritesRepository, false);

			listView.ItemsSource = viewModel.Groups;
		}

		private void OnItemSelected (object sender, ItemTappedEventArgs e)
		{
			var person = e.Item as Person;
			var selectedEmployee = new EmployeeView {
				BindingContext = new PersonViewModel (person, favoritesRepository)
			};

			Navigation.PushAsync (selectedEmployee);
		}
	}
}