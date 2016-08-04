using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Diagnostics;

namespace TodoLocalized
{
	// You exclude the 'Extension' suffix when using in Xaml markup
	[ContentProperty ("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		public string Text { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Text == null)
				return null;
			Debug.WriteLine ("Provide: " + Text);
			// Do your translation lookup here, using whatever method you require
			var translated = L10n.Localize (Text, Text); 

			return translated;
		}
	}
}

