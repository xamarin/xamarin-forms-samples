using SearchBarDemos.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SearchBarDemos
{
    public partial class SearchBarXamlPage : ContentPage
    {
        public SearchBarXamlPage()
        {
            InitializeComponent();
            searchResults.ItemsSource = DataService.Fruits;
        }

        void OnSearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar bar = (SearchBar)sender;
            searchResults.ItemsSource = DataService.GetSearchResults(bar.Text);
        }
    }
}