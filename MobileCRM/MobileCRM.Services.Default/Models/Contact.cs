using System.Collections.Generic;


namespace MobileCRM.Models
{
    public class Contact : IContact
    {
        readonly IContact innerContact;

        public Contact () : this(null) { }

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
    
        public override string ToString ()
        {
            return string.Format ("{0} {1}", FirstName, LastName);
        }
    }

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

