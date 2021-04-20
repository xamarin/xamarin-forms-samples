using Xamarin.Forms;
using Xamarin.Forms.Shapes;

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

            Ellipse ellipse = new Ellipse
            {
                Fill = SolidColorBrush.Red,
                WidthRequest = 150,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center
            };

            Ellipse circle = new Ellipse
            {
                Stroke = SolidColorBrush.Red,
                StrokeThickness = 4,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Ellipse Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    ellipse,
                    circle
                }
            };
        }
    }
}

