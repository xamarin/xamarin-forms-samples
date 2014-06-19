using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileCRM.Services;
using MobileCRM.Models;

[assembly:Dependency(typeof(ContactRepository))]

namespace MobileCRM.Services
{

    public class ContactRepository : InMemoryRepository<Contact> 
    {
        public ContactRepository()
        {
            Add(new Contact { FirstName = "Bob", LastName = "Harlan", Industry = "Software", Address = new Address { Latitude = 37.7993396, Longitude = -122.4017555 } });
            Add(new Contact { FirstName = "Dory", LastName = "Himenez", Industry = "Logistic", Address = new Address { Latitude = 37.79798, Longitude = -122.40247 } });
            Add(new Contact { FirstName = "Aria", LastName = "Patel", Industry = "Aerospace", Address = new Address { Latitude = 37.79632, Longitude = -122.40136 } });
        }
    }
}
