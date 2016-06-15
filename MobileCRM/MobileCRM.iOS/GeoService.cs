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
        #region IGeoService implementation

		public IEnumerable<Address> ValidateAddress (string address)
        {
            var coder = new CLGeocoder();
            var results = new List<Address>();

			var task = Task.Factory.StartNew (() => {
				CLPlacemark[] r = coder.GeocodeAddressAsync (address).Result;
				Console.WriteLine (string.Format ("it ran! {0}", r.Length));
				results.AddRange (OnCompletion (r));
			});

			task.Wait (TimeSpan.FromSeconds (10));
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

