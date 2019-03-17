using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;

namespace OfflineCurrencyConverter.Shared
{
    /// <summary>
    /// This is an extension method to perform on strings automatically
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Translate the text automatically
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Translate(this string text)
        {
            if (text != null)
            {
                var assembly = typeof(StringExtensions).GetTypeInfo().Assembly;
                var assemblyName = assembly.GetName();
                ResourceManager resourceManager = new ResourceManager($"{assemblyName.Name}.Resources", assembly);
                var lg = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                return resourceManager.GetString(text, new CultureInfo(lg));
            }

            return null;
        }
    }
}
