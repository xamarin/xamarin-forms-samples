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
                searchResults.ItemsSource = Constants.GetFilteredFruits(searchBar.Text);
            });

            BindingContext = this;

            searchResults.ItemsSource = Constants.Fruits;
        }
    }
}