using Xamarin.Forms;

namespace MonkeyApp
{
	public partial class SuggestionsPage : ContentPage
	{
		public SuggestionsPage()
		{
			InitializeComponent();
			BindingContext = new SuggestionsPageViewModel();
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
				// Remove delimiters
				monkey.Name = monkey.Name.Replace("[", string.Empty).Replace("]", string.Empty);

				// Navigate
				var page = new MonkeyDetailsPage();
				page.BindingContext = monkey;
				await Navigation.PushAsync(page);
			}
		}
	}
}
