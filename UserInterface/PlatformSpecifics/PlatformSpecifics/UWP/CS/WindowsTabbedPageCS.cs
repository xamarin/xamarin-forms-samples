using System.Windows.Input;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public class WindowsTabbedPageCS : TabbedPage
    {
        ICommand _returnToPlatformSpecificsPage;

        public WindowsTabbedPageCS(ICommand restore)
        {
            _returnToPlatformSpecificsPage = restore;

            Children.Add(CreateContentPageOne());
            Children.Add(CreateContentPageTwo());
            WindowsPlatformSpecificsHelpers.AddToolBarItems(this);
        }

        ContentPage CreateContentPageOne()
        {
            var returnButton = new Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => _returnToPlatformSpecificsPage.Execute(null);

            return new ContentPage
            {
                Title = "ContentPage One",
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        new Label { Text = "Toolbar Items", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                        WindowsPlatformSpecificsHelpers.CreateAddRemoveToolbarItemButtons(this),
                        WindowsPlatformSpecificsHelpers.CreateToolbarPlacementChanger(this),
                        returnButton
                    }
                }
            };
        }

        ContentPage CreateContentPageTwo()
        {
            var returnButton = new Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => _returnToPlatformSpecificsPage.Execute(null);

            return new ContentPage
            {
                Title = "ContentPage Two",
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        new Label { Text = "Toolbar placement and number of items doesn't change", HorizontalOptions = LayoutOptions.Center },
                        returnButton
                    }
                }
            };
        }
    }
}
