using Xamarin.Forms;

namespace SearchBarDemos
{
    public partial class SearchBarRealtimeXamlPage : ContentPage
    {
        public SearchBarRealtimeXamlPage()
        {
            InitializeComponent();

            searchResults.ItemsSource = Constants.GetFilteredFruits(searchBar.Text);
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            searchResults.ItemsSource = Constants.GetFilteredFruits(e.NewTextValue);
        }
    }
}