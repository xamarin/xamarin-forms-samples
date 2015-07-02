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
            AddRange(new List<Account>
                {
                    new Account
                    { 
                        Company = "InnoTech", 
                        Industry = "Software", 
                        Address = new Address
                        { 
                            Street = "700 Pacific Ave", 
                            City = "San Francisco", 
                            State = "CA", 
                            PostalCode = "94111", 
                            Latitude = 37.79832, 
                            Longitude = -122.44
                        }
                    },
                    new Account
                    { 
                        Company = "Umbrella Corp", 
                        Industry = "Medical", 
                        Address = new Address
                        { 
                            Street = "231 Broadway St", 
                            City = "San Francisco", 
                            State = "CA", 
                            PostalCode = "94111", 
                            Latitude = 37.79715, 
                            Longitude = -122.40358
                        }
                    },
                    new Account
                    { 
                        Company = "Soylent Corp", 
                        Industry = "People", 
                        Address = new Address
                        { 
                            Street = "43 Drumm St", 
                            City = "San Francisco", 
                            State = "CA", 
                            PostalCode = "94111", 
                            Latitude = 37.794279, 
                            Longitude = -122.396823
                        }
                    },
                    new Account
                    { 
                        Company = "Stark Industries", 
                        Industry = "Artificial Intelligence", 
                        Address = new Address
                        { 
                            Street = "600 Montgomery St", 
                            City = "San Francisco", 
                            State = "CA", 
                            PostalCode = "94111", 
                            Latitude = 37.795212, 
                            Longitude = -122.402836
                        }
                    },
                    new Account
                    { 
                        Company = "Tyrell Corp", 
                        Industry = "Biotech", 
                        Address = new Address
                        { 
                            Street = "600 Montgomery St", 
                            City = "San Francisco", 
                            State = "CA", 
                            PostalCode = "94111", 
                            Latitude = 37.766601, 
                            Longitude = -122.387786
                        }
                    },
                    new Account
                    { 
                        Company = "Encom", 
                        Industry = "Games", 
                        Address = new Address
                        { 
                            Street = "220 Sansome Street", 
                            City = "San Francisco", 
                            State = "CA", 
                            PostalCode = "94111", 
                            Latitude = 37.792235, 
                            Longitude = -122.400983
                        }
                    }
                });
        }
    }

}