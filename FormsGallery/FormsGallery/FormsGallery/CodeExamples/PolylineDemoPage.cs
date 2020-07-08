using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class PolylineDemoPage : ContentPage
    {
        public PolylineDemoPage()
        {
            Label header = new Label
            {
                Text = "Polyline",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Polyline Demo";
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

