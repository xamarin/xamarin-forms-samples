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
//              - Android: API key!
//              - WP: WMAppManifest.xaml, Capabilities, ID_CAP_MAP

namespace FormsGallery
{
    class MapDemoPage : ContentPage
    {
        public MapDemoPage()
        {
            Label header = new Label
            {
                Text = "Map",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            View view;

            if (Device.OS == TargetPlatform.Android)
            {
                view = new Label
                {
                    Text = "Android applications require API key " +
                           "to use the Google Map service.",
                    Font = Font.SystemFontOfSize(NamedSize.Large),
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
            }
            else
            {
                Map map = new Map();
                view = map;

                // Let's visit Xamarin HQ in San Francisco!
                Position position = new Position(37.79762, -122.40181);
                map.MoveToRegion(new MapSpan(position, 0.01, 0.01));
                map.Pins.Add(new Pin
                    {
                        Label = "Xamarin",
                        Position = position
                    });
            }

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    view
                }
            };
        }
    }
}
