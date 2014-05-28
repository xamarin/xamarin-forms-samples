using System;

namespace MobileCRM.Models
{
    public class Lead : Contact, ILead
    {
        public Lead () : base () { }
        public Lead (IContact contact) : base (contact) { }
    }
}

