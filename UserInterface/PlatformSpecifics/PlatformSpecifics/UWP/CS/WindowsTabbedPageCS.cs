using Xamarin.Forms;

namespace PlatformSpecifics
{
    public class WindowsTabbedPageCS : TabbedPage
    {
        public WindowsTabbedPageCS()
        {
            Children.Add(CreateContentPageOne());
            Children.Add(CreateContentPageTwo());
            WindowsPlatformSpecificsHelpers.AddToolBarItems(this);
        }

        ContentPage CreateContentPageOne()
        {
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
                        WindowsPlatformSpecificsHelpers.CreateToolbarPlacementChanger(this)
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
