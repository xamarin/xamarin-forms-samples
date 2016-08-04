using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;

namespace TodoLocalized
{
    public class L10n
	{
        const string ResourceId = "TodoLocalized.Resx.AppResources";

        public static void SetLocale ()
        {
            DependencyService.Get<ILocale>().SetLocale();
		}

		/// <remarks>
		/// Maybe we can cache this info rather than querying every time
		/// </remarks>
		public static string Locale ()
		{
            return DependencyService.Get<ILocale>().GetCurrent();
        }
			
		public static string Localize(string key, string comment)
        {
            var netLanguage = Locale ();

            // Platform-specific
            ResourceManager temp = new ResourceManager(ResourceId, typeof(L10n).GetTypeInfo().Assembly);
            Debug.WriteLine("Localize " + key);
            string result = temp.GetString(key, new CultureInfo(netLanguage));

            if (result == null)
            {
                result = key; // HACK: return the key, which GETS displayed to the user
            }
            return result;
		}
	}
}
