using OfflineCurrencyConverter.Services.PerPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfflineCurrencyConverter.UWP.Services;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformUtilityActions))]
namespace OfflineCurrencyConverter.UWP.Services
{
    class PlatformUtilityActions : IPerPlatformUtilities
    {
        public string GetStoreLink()
        {
            return "https://www.microsoft.com/store/apps/9N9205DB10T1";
        }
    }
}
