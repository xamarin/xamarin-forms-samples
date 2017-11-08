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
		private ToolbarItem toolbarItem;

		public EmployeeListXaml ()
		{
			InitializeComponent ();

			toolbarItem = new ToolbarItem ("search", "Search.png", () => {
				var search = new SearchListXaml ();
				Navigation.PushAsync (search);
			}, 0, 0);

			ToolbarItems.Add (toolbarItem);
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			if (LoginViewModel.ShouldShowLogin (App.LastUseTime))
				await Navigation.PushModalAsync (new LoginXaml ());

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

		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var person = e.SelectedItem as Person;
			var employeeView = new EmployeeXaml {
				BindingContext = new PersonViewModel (person, favoritesRepository)
			};

			Navigation.PushAsync (employeeView);
		}

		private void SetToolbarItems(bool show)
		{
			if (Device.RuntimePlatform != Device.WinPhone)
				return;

			if (show) {
				ToolbarItems.Add (toolbarItem);
			} else if (Device.RuntimePlatform == Device.WinPhone) {
				ToolbarItems.Remove (toolbarItem);
			}
		}
	}
}
