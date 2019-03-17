using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverterService
{
    public class GlobalCurrencies
    {
        public string ID { get; set; }
        [JsonProperty("results")]
        public Dictionary<string, Currency> Results { get; set; }
    }
}
