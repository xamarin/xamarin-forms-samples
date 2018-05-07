using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoLocalized
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo _ci = null;
        const string ResourceId = "TodoLocalized.Resx.AppResources";
        static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

        public string Text { get; set; }

        public TranslateExtension()
            : this(DependencyService.Get<ILocale>())
        {
        }

        public TranslateExtension(ILocale locale)
        {
            _ci = locale.GetCurrentCultureInfo();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            string translation = ResMgr.Value.GetString(Text, _ci);
            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, _ci.Name),
                    "Text");
#else
				translation = Text;
#endif
            }
            return translation;
        }
    }
}
