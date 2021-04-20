using Xamarin.Forms;

namespace MonkeyApp
{
	public partial class SearchPage : ContentPage
	{
		public SearchPage()
		{
			InitializeComponent();
			BindingContext = new SearchPageViewModel();
		}

		void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}

		async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var monkey = ((ListView)sender).SelectedItem as Monkey;
			if (monkey != null)
			{
				var page = new MonkeyDetailsPage();
				page.BindingContext = monkey;
				await Navigation.PushAsync(page);
			}
		}
	}
}
