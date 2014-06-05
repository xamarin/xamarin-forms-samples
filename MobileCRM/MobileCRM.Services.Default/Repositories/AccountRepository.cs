using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileCRM.Services;
using MobileCRM.Models;

[assembly:Dependency(typeof(AccountRepository))]

namespace MobileCRM.Services
{

    public class AccountRepository : InMemoryRepository<Account> 
    {
        public AccountRepository()
        {
            Add(new Account { Company = "InnoTech", Industry = "Software", Address = new Address { Street = "700 Pacific Ave", City = "San Francisco", State = "CA", PostalCode = "94111", Latitude = 37.79832, Longitude = -122.44 }});
            Add(new Account { Company = "Umbrella Corp", Industry = "Medical" , Address = new Address { Street = "231 Broadway St", City = "San Francisco", State = "CA", PostalCode = "94111", Latitude = 37.79715, Longitude = -122.40358 }});
        }
    }
    
}
