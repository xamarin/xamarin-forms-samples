using System.Collections.Generic;


namespace Meetup.Shared
{
    public class Contact : IContact
    {
        readonly IContact innerContact;

        public Contact (IContact contact = null)
        {
            innerContact = contact ?? new DefaultContact();
        }

        protected IContact InnerContact {  get { return innerContact; } }

        #region IContact implementation

        public string FirstName {
            get {
                return InnerContact.FirstName;
            }
            set {
                InnerContact.FirstName = value;
            }
        }

        public string LastName {
            get {
                return InnerContact.LastName ;
            }
            set {
                InnerContact.LastName = value ;
            }
        }

        public string Company {
            get {
                return InnerContact.Company ;
            }
            set {
                InnerContact.Company = value ;
            }
        }

        public string Title {
            get {
                return InnerContact.Title ;
            }
            set {
                InnerContact.Title = value ;
            }
        }

        public string Industry {
            get {
                return InnerContact.Industry ;
            }
            set {
                InnerContact.Industry = value ;
            }
        }

        public string Email {
            get {
                return InnerContact.Email ;
            }
            set {
                InnerContact.Email = value ;
            }
        }

        public string Website {
            get {
                return InnerContact.Website ;
            }
            set {
                InnerContact.Website = value ;
            }
        }

        public string Phone {
            get {
                return InnerContact.Phone ;
            }
            set {
                InnerContact.Phone = value ;
            }
        }

        public string Mobile {
            get {
                return InnerContact.Mobile ;
            }
            set {
                InnerContact.Mobile = value ;
            }
        }

        public string Fax {
            get {
                return InnerContact.Fax ;
            }
            set {
                InnerContact.Fax = value ;
            }
        }

        public Address Address {
            get {
                return InnerContact.Address ;
            }
            set {
                InnerContact.Address = value ;
            }
        }

        public Address BillingAddress {
            get {
                return InnerContact.BillingAddress ;
            }
            set {
                InnerContact.BillingAddress = value ;
            }
        }

        public Address ShippingAddress {
            get {
                return InnerContact.ShippingAddress ;
            }
            set {
                InnerContact.ShippingAddress = value ;
            }
        }

        public string Twitter {
            get {
                return InnerContact.Twitter ;
            }
            set {
                InnerContact.Twitter = value ;
            }
        }

        public string LinkedIn {
            get {
                return InnerContact.LinkedIn ;
            }
            set {
                InnerContact.LinkedIn = value ;
            }
        }

        public string Facebook {
            get {
                return InnerContact.Facebook ;
            }
            set {
                InnerContact.Facebook = value ;
            }
        }

        public string Skype {
            get {
                return InnerContact.Skype ;
            }
            set {
                InnerContact.Skype = value ;
            }
        }

        public int Owner {
            get {
                return InnerContact.Owner ;
            }
            set {
                InnerContact.Owner = value ;
            }
        }


        public IEnumerable<string> Tags {
            get {
                return InnerContact.Tags;
            }
        }
        #endregion
    }
}

