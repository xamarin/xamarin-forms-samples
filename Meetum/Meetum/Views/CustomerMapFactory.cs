using System;
using Xamarin.QuickUI;
using Xamarin.QuickUI.Maps;
using System.Linq;
using System.Diagnostics;

namespace Meetum.Views
{
    public static class CustomerMapFactory
    {
        public static StackLayout InitializeMap (ContentPage parent)
        {
            var map = MakeMap ();

            var searchAddress = new SearchBar { Placeholder = "Search Address" };

            searchAddress.SearchButtonPressed += async (e, a) => {
                var addressQuery = searchAddress.Text;
                searchAddress.Text = "";
                searchAddress.Unfocus ();

                var positions = (await (new Geocoder ()).GetPositionsForAddressAsync (addressQuery)).ToList ();
                if (!positions.Any ())
                    return;

                var position = positions.First ();
                map.MoveToRegion (MapSpan.FromCenterAndRadius (position,
                    Distance.FromMeters (4000)));
                map.Pins.Add (new Pin {
                    Label = addressQuery,
                    Position = position,
                    Address = addressQuery
                });
            };

            var buttonAddressFromPosition = new Button { Text = "Address From Position", TextColor = Color.White };
            buttonAddressFromPosition.Clicked += async (e, a) => {
                var addresses = (await (new Geocoder ()).GetAddressesForPositionAsync (new Position (41.8902, 12.4923))).ToList ();
                foreach (var ad in addresses)
                    Debug.WriteLine (ad);
            };

            parent.ToolbarItems.Add(new ToolbarItem("Zoom In", "zoom_in.png", () => map.MoveToRegion (map.VisibleRegion.WithZoom (5f))));
            parent.ToolbarItems.Add(new ToolbarItem("Zoom Out", "zoom_out.png", () => map.MoveToRegion (map.VisibleRegion.WithZoom (1 / 3f))));
            parent.ToolbarItems.Add(new ToolbarItem("Map Type", "map.png", async ()=> {
                    var result = await parent.DisplayActionSheet ("Select Map Type", null, null, "Street", "Satellite", "Hybrid");
                    switch (result) {
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
                }));

            var buttonZoomIn = new Button { Text = "Zoom In", TextColor = Color.White };
            buttonZoomIn.Clicked += (e, a) => map.MoveToRegion (map.VisibleRegion.WithZoom (5f));

            var buttonZoomOut = new Button { Text = "Zoom Out", TextColor = Color.White };
            buttonZoomOut.Clicked += (e, a) => map.MoveToRegion (map.VisibleRegion.WithZoom (1 / 3f));

            var mapTypeButton = new Button { Text = "Map Type", TextColor = Color.White };
            mapTypeButton.Clicked += async (e, a) => {
                var result = await parent.DisplayActionSheet ("Select Map Type", null, null, "Street", "Satellite", "Hybrid");
                switch (result) {
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
            };

            var stack = new StackLayout { Spacing = 0, BackgroundColor = Color.FromHex("DAD0C8")};

            map.VerticalOptions = LayoutOptions.FillAndExpand;
            map.HeightRequest = 100;
            map.WidthRequest = 960;
            stack.Children.Add (searchAddress);
            stack.Children.Add (map);

            var buttonStack = new StackLayout { 
                Orientation = StackOrientation.Horizontal,
                Spacing = 30,
                Padding = new Thickness(20, 0, 20, 0)
            };

            buttonStack.Children.Add (mapTypeButton);
            buttonStack.Children.Add (buttonZoomIn);
            buttonStack.Children.Add (buttonZoomOut);
            buttonStack.Children.Add (buttonAddressFromPosition);

            // Wrap in a horizonal scroll view to handle small screens.
            stack.Children.Add(new ScrollView { Content = buttonStack, HeightRequest = 44, Orientation = ScrollView.ScrollOrientation.Horizontal });

            return stack;
        }

        public static Map MakeMap ()
        {
            return new Map {
                Pins = {
                    new Pin {
                        Type = PinType.Place,
                        Position = new Position (41.890202, 12.492049),
                        Label = "Colosseum",
                        Address = "Piazza del Colosseo, 00184 Rome, Province of Rome, Italy"
                    },
                    new Pin {
                        Type = PinType.Place,
                        Position = new Position (41.898652, 12.476831),
                        Label = "Pantheon",
                        Address = "Piazza della Rotunda, 00186 Rome, Province of Rome, Italy"
                    },
                    new Pin {
                        Type = PinType.Place,
                        Position = new Position (41.903209, 12.454545),
                        Label = "Sistine Chapel",
                        Address = "Piazza della Rotunda, 00186 Rome, Province of Rome, Italy"
                    }
                }
            };
        }
    }
}

