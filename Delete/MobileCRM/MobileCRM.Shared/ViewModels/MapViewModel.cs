using System.Collections.Generic;
using System.Linq;
using MobileCRM.Models;
using Xamarin.Forms.Maps;

namespace MobileCRM.Shared.ViewModels
{
    public class MapViewModel<T> : MasterViewModel<T> where T: class, IContact, new()
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

            var pins = Models.Select(model =>
            {
                var item = (IContact)model;
                var address = item.Address ?? item.ShippingAddress ?? item.BillingAddress;

                var position = address != null ? new Position(address.Latitude, address.Longitude) : NullPosition;
                var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = item.ToString(),
                        Address = address.ToString()
                    };
                return pin;
            }).ToList();

            return pins; ;
        }
    }
}
