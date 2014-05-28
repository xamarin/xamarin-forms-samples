using System;

namespace MobileCRM.Models
{
    public class Account : Contact
    {
        public Account() : base (null) { }
        public Account (IContact contact) : base (contact)
        {
        }
    }
}

