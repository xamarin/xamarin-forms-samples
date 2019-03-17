using CurrencyConverterService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfflineCurrencyConverter.Models
{
    public class Conversion
    {
        public string CurrencyFromSymbol { get; set; }
        public string CurrencyToSymbol { get; set; }
        public string ToStringText { get; set; }
        public double FromAmount { get; set; }
        public double ToAmount { get; set; }
    }
}
