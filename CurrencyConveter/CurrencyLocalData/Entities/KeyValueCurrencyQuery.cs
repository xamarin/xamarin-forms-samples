using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyLocalData.Entities
{
    public class KeyValueCurrencyQuery : BaseEntity
    {
        public Dictionary<string,double> KeyValue { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
