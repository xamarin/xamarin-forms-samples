using Xamarin.Forms;
using MobileCRM.Services;
using MobileCRM.Models;

[assembly:Dependency(typeof(OpportunityRepository))]

namespace MobileCRM.Services
{

    public class OpportunityRepository : InMemoryRepository<Opportunity> 
    {
        public OpportunityRepository()
        {
            var contact = new Contact { FirstName = "Henry", LastName = "Hunan", Address = new Address { Street = "518 Sansome St", City = "San Francisco", State = "CA", PostalCode = "94111", Latitude = 37.7980160, Longitude = -122.4019871 } };
            var service = DependencyService.Get<UserRepository>();
            var id = new User(new Contact { FirstName = "Javier", LastName = "Vasquez" }) { Username = "jvasquez" };
            Add(new Opportunity(contact) { Company = "Capricorn Media", Industry = "Entertainment", EstimatedAmount = 15000.00M, Owner = id });
        }
    }
    
}
