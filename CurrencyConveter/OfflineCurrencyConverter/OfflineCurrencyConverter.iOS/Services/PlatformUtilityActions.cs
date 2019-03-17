using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using OfflineCurrencyConverter.Services.PerPlatform;
using UIKit;
using OfflineCurrencyConverter.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformUtilityActions))]
namespace OfflineCurrencyConverter.iOS.Services
{
    class PlatformUtilityActions : IPerPlatformUtilities
    {
        public string GetStoreLink()
        {
            return "ios";
        }
    }
}