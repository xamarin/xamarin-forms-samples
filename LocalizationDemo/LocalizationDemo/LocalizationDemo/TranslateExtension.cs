using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalizationDemo
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        static readonly Lazy<ResourceManager> ResourceManager = new Lazy<ResourceManager>(() =>
        {
            return new ResourceManager("LocalizationDemo.Resx.AppResources",
                IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly);
        });

        public string Key { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            // EARLY OUT: null/empty string
            if (string.IsNullOrWhiteSpace(Key))
            {
                return string.Empty;
            }

            var culture = CultureInfo.CurrentUICulture;
            var translation = ResourceManager.Value.GetString(Key, culture);

            if (string.IsNullOrEmpty(translation))
            {
                string error = $"ERROR: {Key} not found for culture {culture.Name}";
                translation = error;

                // OPTIONAL: throw exception
                // throw new Exception(error);
            }

            return translation;
        }
    }
}
