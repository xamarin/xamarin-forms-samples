using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using System;

namespace TodoLocalized
{
    public class L10n
    {
        const string ResourceId = "TodoLocalized.Resx.AppResources";
        static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

        public static string Localize(string key, CultureInfo ci)
        {
            Debug.WriteLine("Localize " + key);
            string result = ResMgr.Value.GetString(key, ci);
            if (result == null)
            {
                result = key;
            }
            return result;
        }
    }
}
