using SearchBarDemos.Services;
using System;
using Xamarin.Forms;

namespace SearchBarDemos
{
    public class SearchBarCodePage : ContentPage
    {
        ListView searchResults;

        public SearchBarCodePage()
        {
            Title = "Code SearchBar";
            Padding = 10;

            SearchBar searchBar = new SearchBar
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Search fruits..."
            };

            Label label = new Label
            {
                Text = "Enter a search term and press enter or click the magnifying glass to perform a search.",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            searchResults = new ListView
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            Content = new StackLayout
            {
                Children =
                {
                    searchBar,
                    label,
                    searchResults
                }
            };

            searchBar.SearchButtonPressed += OnSearchButtonPressed;
            searchResults.ItemsSource = DataService.Fruits;
        }

        void OnSearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar bar = (SearchBar)sender;
            searchResults.ItemsSource = DataService.GetSearchResults(bar.Text);
        }
    }
}