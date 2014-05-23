using MobileCRM.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using System.Diagnostics;

namespace MobileCRM.Shared.Pages
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

        
            var stack = new StackLayout { Spacing = 0 };

            map.VerticalOptions = LayoutOptions.FillAndExpand;
            map.HeightRequest = 100;
            map.WidthRequest = 960;
            stack.Children.Add(searchAddress);
            stack.Children.Add(map);
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
