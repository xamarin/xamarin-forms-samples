using System.Windows.Input;
using Xamarin.Forms;

namespace SearchBarDemos
{
    public partial class SearchBarXamlPage : ContentPage
    {
        public ICommand PerformSearchCommand { get; set; }

        public SearchBarXamlPage()
        {
            InitializeComponent();

            PerformSearchCommand = new Command<SearchBar>((SearchBar searchBar) =>
            {
                searchResults.ItemsSource = Data.GetSearchResults(searchBar.Text);
            });

            BindingContext = this;

            searchResults.ItemsSource = Data.Fruits;
        }
    }
}