using System;
using CoreLocation;
using Foundation;
using MobileCRM.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using AddressBook;
using System.Collections.Concurrent;
using Xamarin.Forms;
using MobileCRM.Services;
using System.Threading.Tasks;
using System.Linq;

[assembly:Dependency(typeof(GeoService))]

namespace MobileCRM.Services
{
    public class GeoService : IGeoService
    {
        //List<Address> results;
        ManualResetEvent reset = new ManualResetEvent(false);

        #region IGeoService implementation

        public IEnumerable<Address> ValidateAddress (string address)
        {
            var coder = new CLGeocoder();
            var results = new List<Address>();
            var task = Task.Factory.StartNew(async ()=>
                {
                    var r = await coder.GeocodeAddressAsync(address).ConfigureAwait(false);
                    Console.WriteLine("it ran!" + r.Length);
                    results.AddRange(OnCompletion(r));
                    reset.Set();
                });
            reset.WaitOne(TimeSpan.FromSeconds(10));
//            var task = await coder.GeocodeAddressAsync(address);
//            results = OnCompletion(task);
            return results;
        }

        IEnumerable<Address> OnCompletion(CLPlacemark[] placemarks)
        {
            var matches = new List<Address>();
            foreach(var placemark in placemarks)
            {
                matches.Add(new Address {
                    Description = placemark.Name,
                    Street = placemark.AddressDictionary.ValueForKey(ABPersonAddressKey.Street).ToString(),
                    City = placemark.AddressDictionary.ValueForKey(ABPersonAddressKey.City).ToString(),
                    State = placemark.AddressDictionary.ValueForKey(ABPersonAddressKey.State).ToString(),
                    PostalCode = placemark.AddressDictionary.ValueForKey(ABPersonAddressKey.Zip).ToString(),
                    Country = placemark.AddressDictionary.ValueForKey(ABPersonAddressKey.Country).ToString(),
                    Latitude = placemark.Location.Coordinate.Latitude,
                    Longitude = placemark.Location.Coordinate.Longitude,
                });
            }

            return matches;
        }

        #endregion

        public GeoService ()
        {
        }
    }
}

