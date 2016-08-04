using System;
using System.Globalization;

namespace UsingResxLocalization
{
	public interface ILocalize
	{
		CultureInfo GetCurrentCultureInfo ();

		void SetLocale ();
	}
}

