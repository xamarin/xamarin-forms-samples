using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

// Map requires:
//      - Installing the Xamarin.Forms.Maps NuGet package
//              (Use the same version number as the Xamarin.Forms package)
//      - a platform-specific call to Xamarin.FormsMaps.Init() in:
//              - iOS: AppDelegate.cs
//              - Android: MainActivity.cs
//              - UWP: App.xaml.cs (with API key)
//      - platform-specific permission:
//              - iOS: location request in info.plist
//              - Android: API key in Android.Manifest.xml, plus location permissions
//              - UWP: package.appxmanifest Capabilities: Location

namespace FormsGallery.CodeExamples
{
    class MapDemoPage : ContentPage
    {
        public MapDemoPage()
        {
            Label header = new Label
            {
                Text = "Map",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Map map = new Map();

            // Let's visit Xamarin HQ in San Francisco!
            Position position = new Position(37.79762, -122.40181);
            map.MoveToRegion(new MapSpan(position, 0.01, 0.01));
            map.Pins.Add(new Pin
            {
                Label = "Xamarin",
                Position = position
            });

            // Build the page.
            Title = "Map Demo";
            Content = new StackLayout
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
