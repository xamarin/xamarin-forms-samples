using System;

namespace MobileCRM.Services
{
    public class DisplayAttribute : Attribute
    {
        public string Name { get; private set; }

        public DisplayAttribute (string name)
        {
            Name = name;
        }
    }
}

