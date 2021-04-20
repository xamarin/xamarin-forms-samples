using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSSearchBarPageCS : ContentPage
    {
        public iOSSearchBarPageCS()
        {
            Xamarin.Forms.SearchBar searchBar = new Xamarin.Forms.SearchBar { Placeholder = "Enter search term" };
            searchBar.On<iOS>().SetSearchBarStyle(UISearchBarStyle.Minimal);

            Button styleButton = new Button { Text = "Toggle SearchBar Style" };
            styleButton.Clicked += (s, e) =>
            {
                switch (searchBar.On<iOS>().GetSearchBarStyle())
                {
                    case UISearchBarStyle.Default:
                        searchBar.On<iOS>().SetSearchBarStyle(UISearchBarStyle.Minimal);
                        break;
                    case UISearchBarStyle.Minimal:
                        searchBar.On<iOS>().SetSearchBarStyle(UISearchBarStyle.Prominent);
                        break;
                    case UISearchBarStyle.Prominent:
                        searchBar.On<iOS>().SetSearchBarStyle(UISearchBarStyle.Default);
                        break;
                }
            };

            Button backgroundButton = new Button { Text = "Toggle Background" };
            backgroundButton.Clicked += (s, e) => searchBar.BackgroundColor = (searchBar.BackgroundColor == Color.Teal) ? Color.Default : Color.Teal;

            Title = "SearchBar Style";
            Content = new StackLayout
            {
                Children =
                {
                    searchBar,
                    styleButton,
                    backgroundButton
                }
            };
        }
    }
}
