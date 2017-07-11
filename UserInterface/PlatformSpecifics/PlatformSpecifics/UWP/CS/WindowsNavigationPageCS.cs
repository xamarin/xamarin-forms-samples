using Xamarin.Forms;

namespace PlatformSpecifics
{
    public class WindowsNavigationPageCS : NavigationPage
    {
        public WindowsNavigationPageCS()
        {
            WindowsPlatformSpecificsHelpers.AddToolBarItems(this);
            PushAsync(CreateContentPageOne());
        }

        ContentPage CreateContentPageOne()
        {
            var navigateButton = new Button { Text = "Navigate", HorizontalOptions = LayoutOptions.Center };
            navigateButton.Clicked += async (sender, e) => await PushAsync(CreateContentPageTwo());

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
                        navigateButton
                    }
                }
            };
        }

        ContentPage CreateContentPageTwo()
        {
            return new ContentPage
            {
                Title = "ContentPage Two",
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        new Label { Text = "Toolbar placement and number of items doesn't change", HorizontalOptions = LayoutOptions.Center }
                    }
                }
            };
        }
    }
}
