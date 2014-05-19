using System;
using Xamarin.Forms;
using System.Linq;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;

namespace EmployeeDirectory
{
	public partial class EmployeeListXaml : ContentPage
	{
		public EmployeeListXaml ()
		{
			InitializeComponent ();

			var tbi = new ToolbarItem ("?", "Search.png", () => {
				// search page
				var search = new SearchListXaml();
				Navigation.Push(search);
			}, 0, 0);

			ToolbarItems.Add (tbi);
		}

		FavoritesViewModel viewModel;
		IFavoritesRepository favoritesRepository;

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			if (LoginViewModel.ShouldShowLogin (App.LastUseTime)) {
				Navigation.PushModal (new LoginView ());
			}

			//
			// Load the favorites
			//
			favoritesRepository = await XmlFavoritesRepository.OpenIsolatedStorage ("XamarinFavorites.xml");

			if (favoritesRepository.GetAll ().Count () == 0) {
				favoritesRepository = await XmlFavoritesRepository.OpenFile ("XamarinFavorites.xml");
			}

			viewModel = new FavoritesViewModel (favoritesRepository, false);

			listView.ItemSource = viewModel.Groups;
		}

		public void OnItemSelected (object sender, EventArg<object> e) {
			var p = ((EventArg<object>)e).Data as Person;
			var em = new EmployeeXaml();

			var pvm = new PersonViewModel (p, favoritesRepository);
			em.BindingContext = pvm;
			Navigation.Push(em);
		}
	}
}