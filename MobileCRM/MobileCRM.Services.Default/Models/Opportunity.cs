using System;

namespace MobileCRM.Models
{
    public class Opportunity : Contact
    {
        public Opportunity () : base() { }
        public Opportunity (IContact contact) : base(contact) { }
        public Opportunity (ILead lead) : base ((IContact)lead) { }

        public bool IsQualified { get; set; }
        public double EstimatedAmount { get; set; }
        public override string ToString ()
        {
            return string.Format ("{0}{1}", Company, Math.Abs (EstimatedAmount) < Double.Epsilon 
                ? string.Empty 
                : string.Format (" - {0:C0}{1}", EstimatedAmount / 1000, EstimatedAmount > 1000 ? "K" : string.Empty)
            );
        }
    }
}

