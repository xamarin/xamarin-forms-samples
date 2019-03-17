using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterService
{
    public interface ICurrencyConverter
    {
        Task<GlobalCurrencies> GetAllCurrenciesAsync();
        Task<double> ConvertCurrencyAsync(string currencyFromID, string currencyToID, double value);
        Task<KeyValuePair<string, double>> GetConvertQuerryAsync(string currencyFromID, string currencyToID);
    }
}
