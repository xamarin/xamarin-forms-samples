using Xamarin.Forms;
using Xamarin.Forms.Shapes;

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

            Line line = new Line
            {
                X1 = 40,
                Y1 = 0,
                X2 = 0,
                Y2 = 120,
                Stroke = SolidColorBrush.Red,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Line Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    line
                }
            };
        }
    }
}

