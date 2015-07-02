using Xamarin.Forms;
using MobileCRM.Services;
using MobileCRM.Models;
using System.Collections.Generic;

[assembly:Dependency(typeof(OpportunityRepository))]

namespace MobileCRM.Services
{
    public class OpportunityRepository : InMemoryRepository<Opportunity>
    {
        public OpportunityRepository()
        {
            AddRange(
                new List<Opportunity>
                { 
                    new Opportunity(
                        new Contact
                        { 
                            FirstName = "Henry", 
                            LastName = "Hunan", 
                            Address = new Address
                            { 
                                Street = "518 Sansome St", 
                                City = "San Francisco", 
                                State = "CA", 
                                PostalCode = "94111", 
                                Latitude = 37.7980160, 
                                Longitude = -122.4019871
                            } 
                        })
                    { 
                        Company = "Capricorn Media", 
                        Industry = "Entertainment", 
                        EstimatedAmount = 15000.00M, 
                        Owner = new User(
                            new Contact
                            { 
                                FirstName = "Javier", 
                                LastName = "Vasquez"
                            })
                        { 
                            Username = "jvasquez" 
                        }
                    },

                    new Opportunity(
                        new Contact
                        { 
                            FirstName = "Mark", 
                            LastName = "Cheng", 
                            Address = new Address
                            { 
                                Street = "69 Green St", 
                                City = "San Francisco", 
                                State = "CA", 
                                PostalCode = "94111", 
                                Latitude = 37.800329, 
                                Longitude = -122.400731
                            } 
                        })
                    { 
                        Company = "Tuned In", 
                        Industry = "Audio Production", 
                        EstimatedAmount = 55000.00M, 
                        Owner = new User(
                            new Contact
                            { 
                                FirstName = "Jose", 
                                LastName = "Acosta"
                            })
                        { 
                            Username = "jacosta" 
                        }
                    },

                    new Opportunity(
                        new Contact
                        { 
                            FirstName = "Jaime", 
                            LastName = "Caruthers", 
                            Address = new Address
                            { 
                                Street = "450 Golden Gate Ave", 
                                City = "San Francisco", 
                                State = "CA", 
                                PostalCode = "94111", 
                                Latitude = 37.781957, 
                                Longitude = -122.418482
                            } 
                        })
                    { 
                        Company = "Oscorp", 
                        Industry = "Military Tech", 
                        EstimatedAmount = 75000.00M, 
                        Owner = new User(
                            new Contact
                            { 
                                FirstName = "Harry", 
                                LastName = "Osbourne"
                            })
                        { 
                            Username = "jvasquez" 
                        }
                    }
                });
        }
    }
}