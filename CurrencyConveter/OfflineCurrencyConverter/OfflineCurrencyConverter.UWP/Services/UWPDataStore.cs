using OfflineCurrencyConverter.Services.Abstractions;
using OfflineCurrencyConverter.Shared;
using OfflineCurrencyConverter.UWP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(UWPDataStore))]
namespace OfflineCurrencyConverter.UWP.Services
{
    public class UWPDataStore : IDataStore
    {
        public string GetDataStore()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, Constants.DATA_STORE_NAME);
        }
    }
}
