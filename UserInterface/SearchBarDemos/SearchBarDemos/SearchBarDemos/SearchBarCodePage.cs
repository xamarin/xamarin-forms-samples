using Xamarin.Forms;

namespace SearchBarDemos
{
    public class SearchBarCodePage : ContentPage
    {
        ListView searchResults;

        public SearchBarCodePage()
        {
            Title = "Code SearchBar Page";
            Padding = 10;

            SearchBar searchBar = new SearchBar
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Search fruits..."
            };
            searchBar.SearchButtonPressed += (sender, e) =>
            {
                searchResults.ItemsSource = Constants.GetFilteredFruits(searchBar.Text);
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

            searchResults.ItemsSource = Constants.Fruits;
        }
    }
}