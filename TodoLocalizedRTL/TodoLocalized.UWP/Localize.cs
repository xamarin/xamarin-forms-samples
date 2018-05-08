using System.Globalization;
using TodoLocalized.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace TodoLocalized.UWP
{
    public class Localize : ILocale
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentUICulture;
        }
    }
}