using Meetup.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using System.Diagnostics;

namespace Meetup.Shared.Pages
{
    public class MapPage : ContentPage
    {
        private MapViewModel ViewModel
        {
            get { return BindingContext as MapViewModel; }
        }
        static readonly Position xamarin = new Position(37.797536, -122.401933);
        public MapPage()
        {
            BindingContext = new MapViewModel();

            this.SetBinding(Page.TitleProperty, "Title");
            this.SetBinding(Page.IconProperty, "Icon");
            var map = MakeMap();

            var searchAddress = new SearchBar { Placeholder = "Search Address" };

            searchAddress.SearchButtonPressed += async (e, a) =>
            {
                var addressQuery = searchAddress.Text;
                searchAddress.Text = "";
                searchAddress.Unfocus();

                var positions = (await (new Geocoder()).GetPositionsForAddressAsync(addressQuery)).ToList();
                if (!positions.Any())
                    return;

                var position = positions.First();
                map.MoveToRegion(MapSpan.FromCenterAndRadius(position,
                    Distance.FromMeters(4000)));
                map.Pins.Add(new Pin
                {
                    Label = addressQuery,
                    Position = position,
                    Address = addressQuery
                });
            };

            /*ToolbarItems.Add(new ToolbarItem("Filter", "filter.png", async () =>
            {
                var page = new ContentPage();
                var result = await page.DisplayAlert("Title", "Message", "Accept", "Cancel");
                Debug.WriteLine("success: {0}", result);
            }));*/

            var buttonZoomIn = new Button { Text = "Zoom In", TextColor = Color.White };
            buttonZoomIn.Clicked += (e, a) => map.MoveToRegion(map.VisibleRegion.WithZoom(5f));

            var buttonZoomOut = new Button { Text = "Zoom Out", TextColor = Color.White };
            buttonZoomOut.Clicked += (e, a) => map.MoveToRegion(map.VisibleRegion.WithZoom(1 / 3f));

            var mapTypeButton = new Button { Text = "Map Type", TextColor = Color.White };
            mapTypeButton.Clicked += async (e, a) =>
            {
                var result = await DisplayActionSheet("Select Map Type", null, null, "Street", "Satellite", "Hybrid");
                switch (result)
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
            };

            var myLocationButton = new Button { Text = "My Location", TextColor = Color.White };
            myLocationButton.Clicked += (e, a) => map.MoveToRegion(MapSpan.FromCenterAndRadius(xamarin, Distance.FromMiles(0.1)));

            var stack = new StackLayout { Spacing = 0, BackgroundColor = Color.FromHex("A19887") };

            map.VerticalOptions = LayoutOptions.FillAndExpand;
            map.HeightRequest = 100;
            map.WidthRequest = 960;
            stack.Children.Add(searchAddress);
            stack.Children.Add(map);

            var spacing = 30;
            var padding = 20;
#if WINDOWS_PHONE
			spacing = 0;
			padding = 10;
#endif

            var buttonStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = spacing,
                Padding = new Thickness(padding, 0, padding, 0)
            };

            buttonStack.Children.Add(mapTypeButton);
#if !__ANDROID__ //already built into map
            buttonStack.Children.Add (buttonZoomIn);
            buttonStack.Children.Add (buttonZoomOut);
#endif
            buttonStack.Children.Add(myLocationButton);

            var height = 44;
#if WINDOWS_PHONE
			height = 80;
#endif
            // Wrap in a horizonal scroll view to handle small screens.
            stack.Children.Add(new ScrollView { Content = buttonStack, HeightRequest = height, Orientation = ScrollOrientation.Horizontal });

            Content = stack;
        }


        public Map MakeMap()
        {

            var m = new Map(MapSpan.FromCenterAndRadius(xamarin, Distance.FromMiles(0.1)));
            var pins = ViewModel.LoadPins();

            foreach (var p in pins)
            {
                m.Pins.Add(p);
            }

            return m;
        }
    }
}
