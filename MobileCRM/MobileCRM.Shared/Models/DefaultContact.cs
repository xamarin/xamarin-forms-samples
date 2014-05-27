using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Meetup.Shared
{
    public class DefaultContact : IContact
	{
        public DefaultContact()
        {
            Tags = new List<string>();
            Address = new Address();
        }

        #region IContact implementation
        public string FirstName {
            get;
            set;
        }
        public string LastName {
            get;
            set;
        }
        public string Company {
            get;
            set;
        }
        public string Title {
            get;
            set;
        }
        public string Industry {
            get;
            set;
        }
        public string Email {
            get;
            set;
        }
        public string Website {
            get;
            set;
        }
        public string Phone {
            get;
            set;
        }
        public string Mobile {
            get;
            set;
        }
        public string Fax {
            get;
            set;
        }
        public Address Address {
            get;
            set;
        }
        public Address BillingAddress {
            get;
            set;
        }
        public Address ShippingAddress {
            get;
            set;
        }
        public string Twitter {
            get;
            set;
        }
        public string LinkedIn {
            get;
            set;
        }
        public string Facebook {
            get;
            set;
        }
        public string Skype {
            get;
            set;
        }

        public IEnumerable<string> Tags {
            get;
            private set;
        }
        public int Owner {
            get;
            set;
        }
        #endregion
	}
}

