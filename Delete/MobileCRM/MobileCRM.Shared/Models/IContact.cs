using System;
using System.Collections;
using System.Collections.Generic;

namespace MobileCRM.Models
{
	public interface IContact
	{
        string FirstName { get; set; }
        string LastName { get; set; }

        string Company { get; set; }
        string Title { get; set; }
        string Industry { get; set; }

        string Email { get; set; }
        string Website { get; set; }

        string Phone { get; set; }
        string Mobile { get; set; }
        string Fax { get; set; }

        Address Address { get; set; }
        Address BillingAddress { get; set; }
        Address ShippingAddress { get; set; }

        string Twitter { get; set; }
        string LinkedIn { get; set; }
        string Facebook { get; set; }
        string Skype { get; set; }

        IEnumerable<string> Tags { get; }

        int Owner { get; set; }
	}
}

