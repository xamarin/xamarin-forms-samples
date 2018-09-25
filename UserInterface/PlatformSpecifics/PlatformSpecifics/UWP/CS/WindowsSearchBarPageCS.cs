using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public class WindowsSearchBarPageCS : ContentPage
    {
        public WindowsSearchBarPageCS()
        {
			var searchBar = new Xamarin.Forms.SearchBar { Text = "Enter search term here" };
			searchBar.On<Windows>().SetIsSpellCheckEnabled(true);

			var toggleButton = new Button { Text = "Toggle spell check" };
			toggleButton.Clicked += (sender, e) => 
			{
				searchBar.On<Windows>().SetIsSpellCheckEnabled(!searchBar.On<Windows>().GetIsSpellCheckEnabled());
			};

			Title = "SearchBar Spell Check";
			Content = new StackLayout
            {
				Margin = new Thickness(20),
                Children = { searchBar, toggleButton }
            };
        }
    }
}
