using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public class PinEvents : ContentPage
    {
        public PinEvents()
        {
            Title = "Pin Events Demo";

            Map map = new Map
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(47.640663, -122.1376177), Distance.FromMiles(1)));

            Pin pin1 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(47.6368678, -122.137305),
                Label = "Example Pin 1",
                Address = "Example custom details..."
            };
            pin1.MarkerClicked += OnMarkerClickedAsync;
            pin1.InfoWindowClicked += OnInfoWindowClickedAsync;
            map.Pins.Add(pin1);

            Pin pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(47.6406414, -122.1344833),
                Label = "Example Pin 2",
                Address = "Example custom details..."
            };
            pin2.MarkerClicked += OnMarkerClickedAsync;
            pin2.InfoWindowClicked += OnInfoWindowClickedAsync;
            map.Pins.Add(pin2);

            Content = new StackLayout
            {
                Children = {
                    map
                }
            };
        }

        async void OnMarkerClickedAsync(object sender, PinClickedEventArgs e)
        {
            string pinName = ((Pin)sender).Label;
            await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
        }

        async void OnInfoWindowClickedAsync(object sender, PinClickedEventArgs e)
        {
            string pinName = ((Pin)sender).Label;
            await DisplayAlert("Info Window Clicked", $"The info window was clicked for {pinName}.", "Ok");
        }
    }
}