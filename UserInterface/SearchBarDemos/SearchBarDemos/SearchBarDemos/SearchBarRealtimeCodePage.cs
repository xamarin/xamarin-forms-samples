using Xamarin.Forms;

namespace SearchBarDemos
{
    public class SearchBarRealtimeCodePage : ContentPage
    {
        ListView searchResults;

        public SearchBarRealtimeCodePage()
        {
            Title = "Code Realtime SearchBar Page";
            Padding = 10;

            SearchBar searchBar = new SearchBar
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Search fruits...",
                CancelButtonColor = Color.Orange,
                PlaceholderColor = Color.Orange
            };
            searchBar.TextChanged += (sender, e) =>
            {
                searchResults.ItemsSource = Constants.GetFilteredFruits(searchBar.Text);
            };

            Label label = new Label
            {
                Text = "Type in the searchbox to filter results in realtime.",
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
                Children = {
                    searchBar,
                    label,
                    searchResults
                }
            };

            searchResults.ItemsSource = Constants.Fruits;
        }
    }
}