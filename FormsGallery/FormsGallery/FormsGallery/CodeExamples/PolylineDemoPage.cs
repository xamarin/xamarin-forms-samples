using Xamarin.Forms;
using Xamarin.Forms.Shapes;

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

            Polyline polyline = new Polyline
            {
                Points = new PointCollection
                {
                    new Point { X = 0, Y = 0 },
                    new Point { X = 10, Y = 30 },
                    new Point { X = 15, Y = 0 },
                    new Point { X = 18, Y = 60 },
                    new Point { X = 23, Y = 30 },
                    new Point { X = 35, Y = 30 },
                    new Point { X = 40, Y = 0 },
                    new Point { X = 43, Y = 60 },
                    new Point { X = 48, Y = 30 },
                    new Point { X = 100, Y = 30 }
                },
                Stroke = SolidColorBrush.Red,
                HorizontalOptions = LayoutOptions.Center
            };

            // Build the page.
            Title = "Polyline Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    polyline
                }
            };
        }
    }
}

