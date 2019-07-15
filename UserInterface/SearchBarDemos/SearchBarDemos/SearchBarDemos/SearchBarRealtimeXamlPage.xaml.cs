using Xamarin.Forms;

namespace SearchBarDemos
{
    public partial class SearchBarRealtimeXamlPage : ContentPage
    {
        public SearchBarRealtimeXamlPage()
        {
            InitializeComponent();

            searchResults.ItemsSource = Data.GetSearchResults(searchBar.Text);
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            searchResults.ItemsSource = Data.GetSearchResults(e.NewTextValue);
        }
    }
}