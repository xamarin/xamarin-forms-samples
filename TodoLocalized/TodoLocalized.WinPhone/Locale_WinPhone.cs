using System;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(TodoLocalized.Locale_WinPhone))]

namespace TodoLocalized
{
    public class Locale_WinPhone : TodoLocalized.ILocale
    {
        /// <remarks>
        /// Not sure if we can cache this info rather than querying every time
        /// </remarks>
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
		{
			return System.Threading.Thread.CurrentThread.CurrentUICulture;
		}


        public void SetLocale(System.Globalization.CultureInfo ci)
        {
            Console.WriteLine("culture: "+Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("ui:      " + Thread.CurrentThread.CurrentUICulture);            
        }
    }
}
