using System;

namespace MobileCRM.Models
{
    public class Account : Contact
    {
        public Account() : base (null) { }
        public Account (IContact contact) : base (contact) { }

        public override string ToString ()
        {
            return string.IsNullOrEmpty(Company) ? string.Format("{0} {1}", FirstName, LastName) : Company;
        }
    }
}

