using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using OfflineCurrencyConverter.iOS.Services;
using OfflineCurrencyConverter.Services.Abstractions;
using OfflineCurrencyConverter.Shared;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(iOSDataStore))]
namespace OfflineCurrencyConverter.iOS.Services
{
    public class iOSDataStore : IDataStore
    {
        public string GetDataStore()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, Constants.DATA_STORE_NAME);
        }
    }
}