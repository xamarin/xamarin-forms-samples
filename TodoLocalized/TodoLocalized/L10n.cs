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

        public static void SetLocale (CultureInfo ci)
        {
            DependencyService.Get<ILocale>().SetLocale(ci);
		}

		/// <remarks>
		/// Maybe we can cache this info rather than querying every time
		/// </remarks>
		[Obsolete]
		public static string Locale ()
		{
			return DependencyService.Get<ILocale>().GetCurrentCultureInfo().ToString();
        }
			
		public static string Localize(string key, string comment)
        {
            //var netLanguage = Locale ();

            // Platform-specific
            ResourceManager temp = new ResourceManager(ResourceId, typeof(L10n).GetTypeInfo().Assembly);
            Debug.WriteLine("Localize " + key);
            string result = temp.GetString(key, DependencyService.Get<ILocale>().GetCurrentCultureInfo());

            if (result == null)
            {
                result = key; // HACK: return the key, which GETS displayed to the user
            }
            return result;
		}
	}
}
