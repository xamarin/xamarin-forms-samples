using System;

namespace MobileCRM.Models
{
    public class Opportunity : Contact
    {
        public Opportunity () : base() { }
        public Opportunity (IContact contact) : base(contact) { }
        public Opportunity (ILead lead) : base ((IContact)lead) { }

        public bool IsQualified { get; set; }
    }
}

