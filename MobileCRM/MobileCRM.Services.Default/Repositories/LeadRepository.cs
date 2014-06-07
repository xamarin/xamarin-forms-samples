using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileCRM.Services;
using MobileCRM.Models;

[assembly:Dependency(typeof(LeadRepository))]

namespace MobileCRM.Services
{

    public class LeadRepository : InMemoryRepository<Lead>, IRepository<Lead> 
    {
        public LeadRepository()
        {
            Add(new Lead { FirstName = "Roy", LastName = "Ginsberg", Industry = "Retail", Address = new Address { Street = "394 Pacific Ave", City = "San Francisco", State = "CA", PostalCode = "94111", Latitude = 37.7970564, Longitude = -122.4034628 } });
        }
    }
    
}
