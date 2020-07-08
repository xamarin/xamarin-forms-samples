using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class LineDemoPage : ContentPage
    {
        public LineDemoPage()
        {
            Label header = new Label
            {
                Text = "Line",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Line Demo";
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

