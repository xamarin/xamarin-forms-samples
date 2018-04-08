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

        static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, IntrospectionExtensions.GetTypeInfo(typeof(L10n)).Assembly));

        public static void SetLocale(CultureInfo ci)
        {
            DependencyService.Get<ILocale>().SetLocale(ci);
        }

        /// <remarks>
        /// Maybe we can cache this info rather than querying every time
        /// </remarks>
        [Obsolete]
        public static string Locale()
        {
            return DependencyService.Get<ILocale>().GetCurrentCultureInfo().ToString();
        }

        public static string Localize(string key, string comment)
        {
            //var netLanguage = Locale ();

            // Platform-specific
            Debug.WriteLine("Localize " + key);
            string result = ResMgr.Value.GetString(key, DependencyService.Get<ILocale>().GetCurrentCultureInfo());

            if (result == null)
            {
                result = key; // HACK: return the key, which GETS displayed to the user
            }
            return result;
        }
    }
}
