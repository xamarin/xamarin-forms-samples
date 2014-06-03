using System;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;
using Xamarin.Forms;

namespace EmployeeDirectoryUI.CSharp
{
	public class SearchListView : ContentPage
	{
		private Search search;
		private SearchViewModel viewModel;
		private IFavoritesRepository favoritesRepository;
		private ListView listView;

		public SearchListView ()
		{
			InitializeViewModel ();
			var searchEntry = new Entry { Placeholder = "Search For" };
			searchEntry.SetBinding (Entry.TextProperty, "SearchText");
			searchEntry.TextChanged += OnValueChanged;

			listView = new ListView () {
				IsGroupingEnabled = true,
				GroupHeaderTemplate = new DataTemplate (typeof(GroupHeaderTemplate)),
				ItemTemplate = new DataTemplate (typeof(ListItemTemplate)),
				ItemsSource = viewModel.Groups
			};

			listView.ItemSelected += OnItemSelected;
			Content = new StackLayout {
				Children = { searchEntry, listView }
			};

			Title = "Search";
		}

		private void InitializeViewModel ()
		{
			var task = Task.Run(async () => {
				favoritesRepository = await XmlFavoritesRepository.OpenFile ("XamarinFavorites.xml");
			});
			task.Wait();

			search = new Search (string.Empty);
			viewModel = new SearchViewModel (App.Service, search);

			viewModel.SearchCompleted += OnSearchCompleted;
			viewModel.Error += (sender, e) => {
				DisplayAlert ("Help", e.Exception.Message, "OK", null);
			};

			BindingContext = viewModel;
		}

		private void OnSearchCompleted (object sender, SearchCompletedEventArgs e)
		{
			if (viewModel.Groups == null) {
				listView.ItemsSource = new string [1];
			} else {
				listView.ItemsSource = viewModel.Groups;
			}
		}

		private void OnValueChanged (object sender, TextChangedEventArgs e)
		{
			viewModel.Search ();
		}

		private void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var person = e.SelectedItem as Person;
			var employeeView = new EmployeeView {
				BindingContext = new PersonViewModel (person, favoritesRepository)
			};
					
			Navigation.PushAsync (employeeView);
		}
	}
}