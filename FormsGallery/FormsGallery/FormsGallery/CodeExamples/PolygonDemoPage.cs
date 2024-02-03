using Xamarin.Forms;
using Xamarin.Forms.Shapes;

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

            Polygon polygon = new Polygon
            {
                Points = new PointCollection
                {
                    new Point { X = 0, Y = 48 },
                    new Point { X = 0, Y = 144 },
                    new Point { X = 96, Y = 150 },
                    new Point { X = 100, Y = 0 },
                    new Point { X = 192, Y = 0 },
                    new Point { X = 192, Y = 96 },
                    new Point { X = 50, Y = 96 },
                    new Point { X = 48, Y = 192 },
                    new Point { X = 150, Y = 200 },
                    new Point { X = 144, Y = 48 }
                },
                Fill = SolidColorBrush.Blue,
                Stroke = SolidColorBrush.Red,
                StrokeThickness = 3,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Polygon Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    polygon
                }
            };
        }
    }
}

