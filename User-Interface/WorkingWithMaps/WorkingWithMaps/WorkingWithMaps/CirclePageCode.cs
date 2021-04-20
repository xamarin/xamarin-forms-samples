using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public class CirclePageCode : ContentPage
    {
        public CirclePageCode()
        {
            Map map = new Map();

            Position position = new Position(37.79752, -122.40183);
            Pin pin = new Pin
            {
                Label = "Microsoft San Francisco",
                Address = "1355 Market St, San Francisco CA",
                Type = PinType.Place,
                Position = position
            };
            map.Pins.Add(pin);

            Circle circle = new Circle
            {
                Center = position,
                Radius = new Distance(250),
                StrokeColor = Color.FromHex("#88FF0000"),
                StrokeWidth = 8,
                FillColor = Color.FromHex("#88FFC0CB")
            };
            map.MapElements.Add(circle);

            Title = "Circle demo";
            Content = map;

            map.MoveToRegion(new MapSpan(position, 0.01, 0.01));
        }
    }
}
