using SearchBarDemos.Services;
using Xamarin.Forms;

namespace SearchBarDemos
{
    public class SearchBarRealtimeCodePage : ContentPage
    {
        ListView searchResults;

        public SearchBarRealtimeCodePage()
        {
            Title = "Code Realtime SearchBar";
            Padding = 10;

            SearchBar searchBar = new SearchBar
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Search fruits...",
                CancelButtonColor = Color.Orange,
                PlaceholderColor = Color.Orange,
                TextTransform = TextTransform.Lowercase
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
                Children =
                {
                    searchBar,
                    label,
                    searchResults
                }
            };

            searchBar.TextChanged += OnTextChanged;
            searchResults.ItemsSource = DataService.Fruits;
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            searchResults.ItemsSource = DataService.GetSearchResults(e.NewTextValue);
        }
    }
}