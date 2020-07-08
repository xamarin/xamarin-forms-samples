using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class EllipseDemoPage : ContentPage
    {
        public EllipseDemoPage()
        {
            Label header = new Label
            {
                Text = "Ellipse",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Ellipse Demo";
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

