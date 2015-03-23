using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCRM.Models;
using MobileCRM.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
/*

Xamarin.Forms uses the native MAP control on each platform.

Both Android and Windows Phone require additional configuration to make MAPs work.

See the document here for more information:
http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/maps/

If you see either of these errors in the console output when running on Android, you have not correctly configured your Google Maps API v2 Key.

[Google Maps Android API] Failed to contact Google servers. Another attempt will be made when connectivity is established.
[Google Maps Android API] Failed to load map. Error contacting Google servers. This is probably an authentication issue (but could be due to network errors).

Refer to the notes in the MainActivity.cs file in the Android project for how to add an API Key.

*/
namespace MobileCRM.Shared.Pages
{
    public class MapPage<T> : ContentPage where T: class, IContact, new()
    {
        private MapViewModel<T> ViewModel
        {
            get { return BindingContext as MapViewModel<T>; }
        }
        // TODO: Uncomment once Xamarin.Forms supports this, hopefully w/ version 1.1.
        //IDictionary<Pin,T> PinMap;

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

                var position = positions.First();
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

            List<Pin> pins = ViewModel.LoadPins();

            // TODO: Uncomment once Xamarin.Forms supports this, hopefully w/ version 1.1.
            //var dict = pins.Zip(ViewModel.Models, (p, m)=>new KeyValuePair<Pin,T>(p, m)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            //PinMap = dict;

			Map map = pins.Count == 0
				? new Map ()
				: new Map (MapSpan.FromCenterAndRadius (pins [0].Position, Distance.FromMiles (0.3)));
			map.IsShowingUser = true;

            foreach (var p in pins)
            {
                map.Pins.Add(p);
            }

            // TODO: Uncomment once Xamarin.Forms supports this, hopefully w/ version 1.1.
//            map.PinSelected += (sender, args)=>
//            {
//                var pin = args.SelectedItem as Pin;
//                var details = PinMap[pin];
//                var page = new DetailPage<T>(details);
//                Navigation.PushAsync(page);
//            };

            return map;
        }
    }
}
