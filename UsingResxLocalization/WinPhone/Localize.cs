using System;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: Xamarin.Forms.Dependency(typeof(UsingResxLocalization.WinPhone.Localize))]

namespace UsingResxLocalization.WinPhone
{
    public class Localize : UsingResxLocalization.ILocalize
    {
        public void SetLocale()
        {
            //
        }

        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture;
        }
    }
}

