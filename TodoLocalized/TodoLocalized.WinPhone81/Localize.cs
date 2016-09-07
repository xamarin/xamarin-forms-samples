using TodoLocalized.WinPhone81;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace TodoLocalized.WinPhone81
{
    public class Localize : ILocale
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
			return new System.Globalization.CultureInfo(
				Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString());
        }

        public void SetLocale(System.Globalization.CultureInfo ci)
        {
            // Do nothing
        }
    }
}