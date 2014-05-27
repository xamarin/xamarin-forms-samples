using System;

namespace Meetup.Shared
{
    public class Lead : Contact
    {
        public Lead (IContact contact) : base (contact)
        {
        }
    }
}

