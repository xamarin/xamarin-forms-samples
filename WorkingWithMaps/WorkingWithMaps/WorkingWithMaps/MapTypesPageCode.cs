using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public class MapTypesPageCode : ContentPage
    {
        Map map;
        public MapTypesPageCode()
        {
            Title = "Map types demo";

            map = new Map();

            // Create a Slider for zoom
            var slider = new Slider(1, 18, 12)
            {
                Margin = new Thickness(20, 0, 20, 0)
            };
            slider.ValueChanged += (sender, e) =>
            {
                double zoomLevel = e.NewValue; // between 1 and 18
                double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
                if (map.VisibleRegion != null)
                {
                    map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongDegrees, latlongDegrees));
                }
            };

            // Create buttons
            Button streetButton = new Button { Text = "Street" };
            Button satelliteButton = new Button { Text = "Satellite" };
            Button hybridButton = new Button { Text = "Hybrid" };

            streetButton.Clicked += OnButtonClicked;
            satelliteButton.Clicked += OnButtonClicked;
            hybridButton.Clicked += OnButtonClicked;

            StackLayout buttons = new StackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                Children = { streetButton, satelliteButton, hybridButton }
            };

            // Build the page
            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(map);
            stackLayout.Children.Add(slider);
            stackLayout.Children.Add(buttons);
            Content = stackLayout;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            switch (button.Text)
            {
                case "Street":
                    map.MapType = MapType.Street;
                    break;
                case "Satellite":
                    map.MapType = MapType.Satellite;
                    break;
                case "Hybrid":
                    map.MapType = MapType.Hybrid;
                    break;
            }
        }
    }
}
