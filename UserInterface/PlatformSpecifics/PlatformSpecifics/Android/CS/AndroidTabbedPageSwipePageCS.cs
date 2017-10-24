using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public class AndroidTabbedPageSwipePageCS : Xamarin.Forms.TabbedPage
    {
        public AndroidTabbedPageSwipePageCS()
        {
            On<Android>().SetOffscreenPageLimit(2)
                         .SetIsSwipePagingEnabled(true);
            Title = "Tabbed Page";

            var firstPage = CreatePage(1);

            var button = new Button
            {
                Text = "Toggle Swipe Paging"
            };
            button.Clicked += (sender, e) =>
            {
                On<Android>().SetIsSwipePagingEnabled(!On<Android>().IsSwipePagingEnabled());
            };

            var stackLayout = firstPage.Content as StackLayout;
            stackLayout.Children.Add(button);

            Children.Add(firstPage);
            Children.Add(CreatePage(2));
            Children.Add(CreatePage(3));
            Children.Add(CreatePage(4));
            Children.Add(CreatePage(5));
        }

        ContentPage CreatePage(int pageNumber)
        {
            return new ContentPage
            {
                Title = string.Format("Page {0}", pageNumber),
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children = {
                        new Label { Text = string.Format("Page {0}", pageNumber), HorizontalOptions = LayoutOptions.Center }
                    }
                }
            };
        }
    }
}
