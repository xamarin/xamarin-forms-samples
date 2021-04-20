using System;

namespace MobileCRM.Services
{
    public class GeoService : IGeoService
    {
        #region IGeoService implementation

        public System.Collections.Generic.IEnumerable<MobileCRM.Models.Address> ValidateAddress (string address)
        {
          return null;
        }

        #endregion

        public GeoService ()
        {
        }
    }
}

