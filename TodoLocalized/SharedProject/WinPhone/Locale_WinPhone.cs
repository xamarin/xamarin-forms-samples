using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(TodoLocalized.WinPhone.Locale_WinPhone))]

namespace TodoLocalized
{
    public class Locale_WinPhone : TodoLocalized.ILocale
    {
        /// <remarks>
        /// Not sure if we can cache this info rather than querying every time
        /// </remarks>
        public string GetCurrent()
        {
            var lang = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            return lang;
        }


        public void SetLocale()
        {
           
            //System.Globalization.CultureInfo ci;
            //try
            //{
            //    ci = new System.Globalization.CultureInfo(netLocale);
            //}
            //catch
            //{
            //    ci = new System.Globalization.CultureInfo(GetCurrent());
            //}
            Console.WriteLine("culture: "+Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("ui:      " + Thread.CurrentThread.CurrentUICulture);
            //Thread.CurrentThread.CurrentCulture = ci;
            //Thread.CurrentThread.CurrentUICulture = ci;
            
        }
    }
}
