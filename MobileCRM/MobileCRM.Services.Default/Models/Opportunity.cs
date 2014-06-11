using System;
using MobileCRM.Services;

namespace MobileCRM.Models
{
    public class Opportunity : Contact
    {
        public Opportunity () : base() { }
        public Opportunity (IContact contact) : base(contact) { }
        public Opportunity (ILead lead) : base ((IContact)lead) { }

        [Display("Qualified?")]
        public bool IsQualified { get; set; }

        [Display("Est. Amount"), Currency]
        public Decimal EstimatedAmount { get; set; }

        public override string ToString ()
        {
            return string.Format ("{0}{1}", Company, EstimatedAmount == Decimal.Zero 
                ? string.Empty 
                : string.Format (" - {0:C0}{1}", EstimatedAmount / 1000, EstimatedAmount > 1000 ? "K" : string.Empty)
            );
        }
    }
}

