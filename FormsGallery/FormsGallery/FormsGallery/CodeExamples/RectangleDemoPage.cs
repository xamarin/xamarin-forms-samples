using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class RectangleDemoPage : ContentPage
    {
        public RectangleDemoPage()
        {
            Label header = new Label
            {
                Text = "Rectangle",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Rectangle Demo";
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

