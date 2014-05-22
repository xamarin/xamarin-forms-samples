using System;
using Xamarin.Forms;
using System.Linq;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;

namespace EmployeeDirectoryUI.Xaml
{
	public partial class EmployeeListXaml : ContentPage
	{
		private FavoritesViewModel viewModel;
		private IFavoritesRepository favoritesRepository;

		public EmployeeListXaml ()
		{
			InitializeComponent ();

			var toolBarItem = new ToolbarItem ("?", "Search.png", () => {
				var search = new SearchListXaml();
				Navigation.PushAsync(search);
			}, 0, 0);

			ToolbarItems.Add (toolBarItem);
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			if (LoginViewModel.ShouldShowLogin (App.LastUseTime))
				Navigation.PushModalAsync (new LoginXaml ());

			favoritesRepository = await XmlFavoritesRepository.OpenIsolatedStorage ("XamarinFavorites.xml");

			if (favoritesRepository.GetAll ().Count () == 0)
				favoritesRepository = await XmlFavoritesRepository.OpenFile ("XamarinFavorites.xml");

			viewModel = new FavoritesViewModel (favoritesRepository, false);

			listView.ItemSource = viewModel.Groups;
		}

		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e) 
		{
			var person = e.SelectedItem as Person;
			var employeeView = new EmployeeXaml {
				BindingContext = new PersonViewModel (person, favoritesRepository)
			};

			Navigation.PushModalAsync(employeeView);
		}
	}
}