using SearchBarDemos.ViewModels;
using Xamarin.Forms;

namespace SearchBarDemos
{
    public class SearchBarCodeMvvmPage : ContentPage
    {
        public SearchBarCodeMvvmPage()
        {
            Title = "Code MVVM SearchBar";
            Padding = 10;
            BindingContext = new SearchViewModel();

            SearchBar searchBar = new SearchBar
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Search fruits...",
            };
            searchBar.SetBinding(SearchBar.SearchCommandProperty, "PerformSearch");
            searchBar.SetBinding(SearchBar.SearchCommandParameterProperty, new Binding { Source = searchBar, Path = "Text" });

            Label label = new Label
            {
                Text = "Enter a search term and press enter or click the magnifying glass to perform a search.",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            ListView searchResults = new ListView
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };
            searchResults.SetBinding(ListView.ItemsSourceProperty, "SearchResults");

            Content = new StackLayout
            {
                Children =
                {
                    searchBar,
                    label,
                    searchResults
                }
            };
        }
    }
}