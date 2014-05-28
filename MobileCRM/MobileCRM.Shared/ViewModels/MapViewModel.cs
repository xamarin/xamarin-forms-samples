using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Maps;
using MobileCRM.Models;

namespace MobileCRM.Shared.ViewModels
{
    public class MapViewModel : ContactsViewModel
    {
        public static readonly Position NullPosition = new Position(0, 0);
         
        public MapViewModel()
        {
            Title = "Map";
            Icon = "map.png";
        }

        public List<Pin> LoadPins()
        {
            ExecuteLoadModelsCommand();

            var pins = Models.Select(p =>
            {
                var address = p.Address ?? p.ShippingAddress ?? p.BillingAddress;

                var position = address != null ? new Position(address.Latitude, address.Longitude) : NullPosition;
                var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = p.ToString(),
                        Address = address.ToString()
                    };
                return pin;
            }).ToList();

            return pins; ;
        }
    }
}
