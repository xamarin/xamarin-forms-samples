using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class PathDemoPage : ContentPage
    {
        public PathDemoPage()
        {
            Label header = new Label
            {
                Text = "Path",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Path Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header
                }
            };
        }
    }
}

