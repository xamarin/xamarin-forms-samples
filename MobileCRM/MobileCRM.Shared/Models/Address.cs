using System;

namespace MobileCRM.Models
{
    public class Address : ILocatable
	{
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        #region ILocatable implementation

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        #endregion
	}
}

