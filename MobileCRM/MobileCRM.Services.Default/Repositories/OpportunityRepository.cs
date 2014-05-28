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

    public class OpportunityRepository : InMemoryRepository<Opportunity> 
    {
        public OpportunityRepository()
        {
            Add(new Opportunity { Company = "Capricorn Media", Industry = "Entertainment", EstimatedAmount = "$15,000.00"});
        }
    }
    
}
