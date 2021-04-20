using System.Windows.Input;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public class iOSTitleViewPageCS : ContentPage
    {
        public iOSTitleViewPageCS(ICommand restore)
        {
            var searchBar = new SearchBar();
            searchBar.Effects.Add(Effect.Resolve("XamarinDocs.SearchBarEffect"));

            var button = new Button { Text = "Return to Platform-Specifics List" };
            button.Clicked += (sender, e) => restore.Execute(null);

            Title = "My Title";
            Content = new StackLayout
            {
                Children = {
                    new StackLayout
                    {
                        BackgroundColor = Color.Cornsilk,
                        Children = { searchBar }
                    },
                    new StackLayout
                    {
                        Margin = new Thickness(20),
                        Children = 
                        {
                            new Label { Text="The separator at the bottom of the navigation bar has been removed." },
                            button
                        }
                    }
                }
            };
        }
    }
}
