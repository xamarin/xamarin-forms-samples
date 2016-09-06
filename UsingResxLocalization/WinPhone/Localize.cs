using System;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: Xamarin.Forms.Dependency(typeof(UsingResxLocalization.WinPhone.Localize))]

namespace UsingResxLocalization.WinPhone
{
    public class Localize : UsingResxLocalization.ILocalize
    {
        public void SetLocale(CultureInfo ci)
        {
            // not required - the resources framework should already have set the culture correctly
        }

        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture;
        }
    }
}

