using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

// Maps requires Xamarin.Forms.Maps assembly, 
//  a platform-specific call to Xamarin.FormsMaps.Init(),
//  and platform-specific permission.

namespace FormsGallery
{
    class MapDemoPage : ContentPage
    {
        Map map;

        public MapDemoPage()
        {
            Label header = new Label
            {
                Text = "Map",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            map = new Map
            {
            };

            // Let's visit Xamarin HQ in San Francisco!
            Position position = new Position(37.79762, -122.40181);
            map.MoveToRegion(new MapSpan(position, 0.01, 0.01));
            map.Pins.Add(new Pin
                {
                    Label = "Xamarin",
                    Position = position
                });

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 0);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    map
                }
            };
        }
    }
}
