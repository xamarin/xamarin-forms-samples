using System;
using MobileCRM.Models;

namespace MobileCRM.Services
{
    public class User : Contact, IUser
    {
        public User():base()
        {
            Id = InnerContact.GetHashCode();
        }

        public User(IContact contact) : base(contact)
        {
            Id = InnerContact.GetHashCode();
        }

        #region IUser implementation

        public object Id {
            get; private set;
        }

        public string Username {
            get; set;
        }

        #endregion
    }
}

