using System;
using System.Threading;
using System.Globalization;

using Foundation;
using Xamarin.Forms;

[assembly:Dependency(typeof(TodoLocalized.Locale_iOS))]

namespace TodoLocalized
{
	public class Locale_iOS : ILocale
	{
		public void SetLocale ()
		{
			var ci = new CultureInfo (GetCurrent ());
			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;
		}

		/// <remarks>
		/// Not sure if we can cache this info rather than querying every time
		/// </remarks>
		public string GetCurrent ()
		{
			var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;	// en_FR
			var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;		// en
			var netLocale = iosLocaleAuto.Replace ("_", "-");
			var netLanguage = iosLanguageAuto.Replace ("_", "-");

			#region Debugging Info

			Console.WriteLine ("nslocaleid: {0}", iosLocaleAuto);
			Console.WriteLine ("nslanguage: {0}", iosLanguageAuto);
			Console.WriteLine ("ios: {0} {1}", iosLanguageAuto, iosLocaleAuto);
			Console.WriteLine ("net: {0} {1}", netLanguage, netLocale);

			Console.WriteLine ("thread:   {0}", Thread.CurrentThread.CurrentCulture);
			Console.WriteLine ("threadui: {0}", Thread.CurrentThread.CurrentUICulture);

			#endregion

			const string defaultCulture = "en";

			if (NSLocale.PreferredLanguages.Length > 0) {
				var pref = NSLocale.PreferredLanguages [0];
				netLanguage = pref.Replace ("_", "-");
				try {
					var ci = CultureInfo.CreateSpecificCulture(netLanguage);
					netLanguage = ci.Name;
				} catch {
					netLanguage = defaultCulture;
				}
			} else {
				netLanguage = defaultCulture; // default, shouldn't really happen :)
			}

			Console.WriteLine (netLanguage);
			return netLanguage;
		}
	}
}