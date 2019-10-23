using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public partial class PinPage : ContentPage
    {
        public PinPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Pin boardwalkPin = new Pin
            {
                Position = new Position(36.9641949, -122.0177232),
                Label = "Boardwalk",
                Address = "Santa Cruz",
                Type = PinType.Place
            };
            boardwalkPin.MarkerClicked += OnMarkerClickedAsync;
            
            Pin wharfPin = new Pin
            {
                Position = new Position(36.9571571, -122.0173544),
                Label = "Wharf",
                Address = "Santa Cruz",
                Type = PinType.Place
            };
            wharfPin.InfoWindowClicked += OnInfoWindowClickedAsync;

            map.Pins.Add(boardwalkPin);
            map.Pins.Add(wharfPin);
        }

        async void OnMarkerClickedAsync(object sender, PinClickedEventArgs e)
        {
            e.HideInfoWindow = true;
            string pinName = ((Pin)sender).Label;
            await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
        }

        async void OnInfoWindowClickedAsync(object sender, PinClickedEventArgs e)
        {
            string pinName = ((Pin)sender).Label;
            await DisplayAlert("Info Window Clicked", $"The info window was clicked for {pinName}.", "Ok");
        }
    }
}
