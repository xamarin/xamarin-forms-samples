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
            var royGinsberg =
                new Lead
                { 
                    FirstName = "Roy", 
                    LastName = "Ginsberg", 
                    Industry = "Retail", 
                    Address = new Address
                    { 
                        Street = "394 Pacific Ave", 
                        City = "San Francisco", 
                        State = "CA", 
                        PostalCode = "94111", 
                        Latitude = 37.7970564, 
                        Longitude = -122.4034628
                    } 
                };

            var skipTaylor = 
                new Lead
                { 
                    FirstName = "Don", 
                    LastName = "Draper", 
                    Industry = "Advertising", 
                    Address = new Address
                    { 
                        Street = "120 Broadway", 
                        City = "San Francisco", 
                        State = "CA", 
                        PostalCode = "94111", 
                        Latitude = 37.798861, 
                        Longitude = -122.40039
                    }
                };

            var jimGeoffrey = 
                new Lead
                { 
                    FirstName = "Jim", 
                    LastName = "Geoffrey", 
                    Industry = "Entertainment", 
                    Address = new Address
                    { 
                        Street = "444 Battery St", 
                        City = "San Francisco", 
                        State = "CA", 
                        PostalCode = "94111", 
                        Latitude = 37.795626, 
                        Longitude = -122.400000
                    }
                };

            var turnerMcAvoy = 
                new Lead
                {
                    FirstName = "Turner", 
                    LastName = "McAvoy", 
                    Industry = "Finance", 
                    Address = new Address
                    { 
                        Street = "600 Montgomery St", 
                        City = "San Francisco", 
                        State = "CA", 
                        PostalCode = "94111", 
                        Latitude = 37.795212, 
                        Longitude = -122.402836
                    }
                };

            var maxRockatansky = 
                new Lead
                {
                    FirstName = "Max", 
                    LastName = "Rockatansky", 
                    Industry = "Motorsports", 
                    Address = new Address
                    { 
                        Street = "1 Embarcadero Center", 
                        City = "San Francisco", 
                        State = "CA", 
                        PostalCode = "94111", 
                        Latitude = 37.794997, 
                        Longitude = -122.399435
                    }
                };

            AddRange(
                new List<Lead>
                {
                    royGinsberg,
                    skipTaylor,
                    jimGeoffrey,
                    turnerMcAvoy,
                    maxRockatansky
                }
            );
            
        }
    }
}