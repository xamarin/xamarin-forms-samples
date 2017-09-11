using Xamarin.Forms;

namespace WorkingWithImages
{
    public class LocalImages : ContentPage
    {
        public LocalImages()
        {
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label { Text = "Image FileSource XAML", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                    new Image { Source = "waterfront.jpg" },
                    new Label { Text = "The image has been added to each application project. On iOS and Android multiple resolutions are supplied and resolved at runtime." }
                }
            };
        }
    }
}
