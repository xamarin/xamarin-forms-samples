using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OfflineCurrencyConverter.Droid.Services;
using OfflineCurrencyConverter.Services.Abstractions;
using OfflineCurrencyConverter.Shared;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDataStore))]
namespace OfflineCurrencyConverter.Droid.Services
{
    public class AndroidDataStore : IDataStore
    {
        public string GetDataStore()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), Constants.DATA_STORE_NAME);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            return path;
        }
    }
}