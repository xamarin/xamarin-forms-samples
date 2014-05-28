using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileCRM.Services;
using MobileCRM.Models;

[assembly:Dependency(typeof(LeadRepository))]
[assembly:Dependency(typeof(ContactRepository))]
[assembly:Dependency(typeof(AccountRepository))]
[assembly:Dependency(typeof(OpportunityRepository))]

namespace MobileCRM.Services
{

    public class ContactRepository : InMemoryRepository<Contact> 
    {
        public ContactRepository()
        {
            Add(new Contact { FirstName = "Bob", LastName = "Harlan", Industry = "Software", Address = new Address { Latitude = 37.7993396, Longitude = -122.4017555 } });
        }
    }
}
