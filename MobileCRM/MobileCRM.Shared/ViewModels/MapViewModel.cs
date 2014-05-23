using MobileCRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms.Maps;

namespace MobileCRM.Shared.ViewModels
{
    public class MapViewModel : CustomersViewModel
    {
         
        public MapViewModel()
        {
            Title = "Map";
            Icon = "map.png";
        }

        public List<Pin> LoadPins()
        {
            this.ExecuteLoadCustomersCommand();
            var pins = this.Customers.Select(p =>
            {
                var pos = p.Location.Points[0];
                var poslist = pos.Poslist.Split(' ');
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(Convert.ToDouble(poslist[0]), Convert.ToDouble(poslist[1])),
                    Label = p.Labels[0].Value,
                    Address = (String)p.Location.Address ?? (String)p.Location.Value ?? (String)p.Location.Points[0].Value
                };
                return pin;
            }).ToList();

            return pins; ;
        }
    }
}
