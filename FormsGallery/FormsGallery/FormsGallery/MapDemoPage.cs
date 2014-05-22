using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

// Map requires:
//      - Xamarin.Forms.Maps and Xamarin.Forms.Maps.* assemblies, 
//      - a platform-specific call to Xamarin.FormsMaps.Init() in:
//              - iOS: AppDelegate.cs
//              - Android: MainActivity.cs
//              - WP: MainPage.xaml.cs 
//      - platform-specific permission:
//              - iOS: None
//              -
//              - WP: WMAppManifest.xaml, Capabilities, ID_CAP_MAP

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
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

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
