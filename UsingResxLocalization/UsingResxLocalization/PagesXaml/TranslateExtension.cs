using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Resources;
using System.Globalization;
using System.Reflection;

namespace UsingResxLocalization
{
	// You exclude the 'Extension' suffix when using in Xaml markup
	[ContentProperty ("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		readonly CultureInfo ci;
		const string ResourceId = "UsingResxLocalization.Resx.AppResources";

		public TranslateExtension() {
			ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo ();
		}

		public string Text { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Text == null)
				return "";

			ResourceManager temp = new ResourceManager(ResourceId
								, typeof(TranslateExtension).GetTypeInfo().Assembly);

			var translation = temp.GetString (Text, ci);

			if (translation == null) {
				#if DEBUG
				throw new ArgumentException (
					String.Format ("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
					"Text");
				#else
				translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
				#endif
			}
			return translation;
		}
	}
}

