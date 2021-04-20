using SearchBarDemos.Services;
using Xamarin.Forms;

namespace SearchBarDemos
{
    public partial class SearchBarRealtimeXamlPage : ContentPage
    {
        public SearchBarRealtimeXamlPage()
        {
            InitializeComponent();

            searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            searchResults.ItemsSource = DataService.GetSearchResults(e.NewTextValue);
        }
    }
}