using Xamarin.Forms;
using Rect = Xamarin.Forms.Shapes.Rectangle;

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

            Rect rectangle = new Rect
            {
                Fill = SolidColorBrush.Red,
                WidthRequest = 150,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center
            };

            Rect square = new Rect
            {
                Stroke = SolidColorBrush.Red,
                StrokeThickness = 4,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Rectangle Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    rectangle,
                    square
                }
            };
        }
    }
}

