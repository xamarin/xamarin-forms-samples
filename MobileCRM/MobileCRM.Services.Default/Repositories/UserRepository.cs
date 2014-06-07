using System;
using MobileCRM.Models;
using Xamarin.Forms;
using MobileCRM.Services;

[assembly:Dependency(typeof(UserRepository))]

namespace MobileCRM.Services
{
    public class UserRepository : InMemoryRepository<User>, IRepository<User> 
    {
        public UserRepository ()
        {
            Add(new User(new Contact { FirstName = "Javier", LastName = "Vasquez" }) { Username = "jvasquez" });
            Add(new User(new Contact { FirstName = "Davon", LastName = "Smith" }) { Username = "dsmith" });
        }
    }
}

