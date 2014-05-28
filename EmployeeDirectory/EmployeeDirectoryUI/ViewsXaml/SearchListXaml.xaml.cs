using System;
using Xamarin.Forms;
using System.Linq;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;

namespace EmployeeDirectoryUI.Xaml
{
	public partial class SearchListXaml : ContentPage
	{
		private Search search;
		private SearchViewModel viewModel;
		private IFavoritesRepository favoritesRepository;

		public SearchListXaml ()
		{
			InitializeComponent ();

			favoritesRepository = XmlFavoritesRepository.OpenFile ("XamarinFavorites.xml").Result;

			search = new Search ("test");
			viewModel = new SearchViewModel (App.Service, search);

			viewModel.SearchCompleted += (sender, e) => {
				if (viewModel.Groups == null) {
					listView.ItemsSource = new string [1];
				} else {
					listView.ItemsSource = viewModel.Groups;
				}
			};

			viewModel.Error += (sender, e) => {
				DisplayAlert ("Error", e.Exception.Message, "OK", null);
			};

			BindingContext = viewModel;
		}

		private void OnValueChanged (object sender, TextChangedEventArgs e)
		{
			viewModel.Search ();
		}

		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var personInfo = e.SelectedItem as Person;
			var employeeView = new EmployeeXaml {
				BindingContext = new PersonViewModel (personInfo, favoritesRepository)
			};

			Navigation.PushAsync(employeeView);
		}
	}
}