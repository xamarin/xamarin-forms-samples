using System;

namespace Meetup.Shared
{
    public class Account : Contact
    {
        public Account (IContact contact) : base (contact)
        {
        }
    }
}

