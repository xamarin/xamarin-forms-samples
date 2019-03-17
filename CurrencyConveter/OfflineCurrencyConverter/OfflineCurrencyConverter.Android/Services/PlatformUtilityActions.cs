using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OfflineCurrencyConverter.Droid.Services;
using OfflineCurrencyConverter.Services.PerPlatform;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformUtilityActions))]
namespace OfflineCurrencyConverter.Droid.Services
{
    class PlatformUtilityActions : IPerPlatformUtilities
    {
        public string GetStoreLink()
        {
            var url = $"https://play.google.com/store/apps/details?id=com.doumer.OfflineCurrencyConverter";
            return url;
        }
    }
}