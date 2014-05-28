using MobileCRM.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using MobileCRM.Models;

namespace MobileCRM.Shared.Pages
{
    public class MapPage<T> : ContentPage where T: class, new()
    {
        private MapViewModel<T> ViewModel
        {
            get { return BindingContext as MapViewModel<T>; }
        }
        static readonly Position xamarin = new Position(37.797536, -122.401933);
        public MapPage(MapViewModel<T> viewModel)
        {
            BindingContext = viewModel;

            this.SetBinding(Page.TitleProperty, "Title");
            this.SetBinding(Page.IconProperty, "Icon");
            var map = MakeMap();
            var stack = new StackLayout { Spacing = 0 };

#if __ANDROID__ || __IOS__
            var searchAddress = new SearchBar { Placeholder = "Search Address", BackgroundColor = Color.White };

            searchAddress.SearchButtonPressed += async (e, a) =>
            {
                var addressQuery = searchAddress.Text;
                searchAddress.Text = "";
                searchAddress.Unfocus();

                var positions = (await (new Geocoder()).GetPositionsForAddressAsync(addressQuery)).ToList();
                if (!positions.Any())
                    return;

                var position = positions.Skip(1).First();
                map.MoveToRegion(MapSpan.FromCenterAndRadius(position,
                    Distance.FromMiles(0.1)));
                map.Pins.Add(new Pin
                {
                    Label = addressQuery,
                    Position = position,
                    Address = addressQuery
                });
            };

            stack.Children.Add(searchAddress);

            ToolbarItems.Add(new ToolbarItem("Filter", "filter.png", async () =>
            {
                var page = new ContentPage();
                var result = await page.DisplayAlert("Title", "Message", "Accept", "Cancel");
                Debug.WriteLine("success: {0}", result);
            }));



#elif WINDOWS_PHONE
           ToolbarItems.Add(new ToolbarItem("filter", "filter.png", async () =>
            {
                var page = new ContentPage();
                var result = await page.DisplayAlert("Title", "Message", "Accept", "Cancel");
                Debug.WriteLine("success: {0}", result);
            }));

          ToolbarItems.Add(new ToolbarItem("search", "search.png", () =>
            {
            }));
#endif




            map.VerticalOptions = LayoutOptions.FillAndExpand;
            map.HeightRequest = 100;
            map.WidthRequest = 960;

            stack.Children.Add(map);
            Content = stack;
        }


        public Map MakeMap()
        {

            var pins = ViewModel.LoadPins();

            // TODO: Compute a proper bounding box.
            var m = new Map(MapSpan.FromCenterAndRadius(pins[0].Position, Distance.FromMiles(1)));

            foreach (var p in pins)
            {
                m.Pins.Add(p);
            }

            return m;
        }
    }
}
