using System;
using MobileCRM.Services;

namespace MobileCRM.Models
{
    public class Address : ILocatable
	{
        public string Description { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        [Display("Postal Code")]
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        #region ILocatable implementation

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        #endregion

        public override string ToString ()
        {
            return string.Format ("{0}{1} {2} {3} {4}", Street, !string.IsNullOrWhiteSpace(Unit) ? Unit + "," : string.Empty, !string.IsNullOrWhiteSpace(City) ? City + "," : string.Empty, State, PostalCode);
        }
	}
}

