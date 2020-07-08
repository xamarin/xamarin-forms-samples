using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class PolygonDemoPage : ContentPage
    {
        public PolygonDemoPage()
        {
            Label header = new Label
            {
                Text = "Polygon",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Polygon Demo";
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

