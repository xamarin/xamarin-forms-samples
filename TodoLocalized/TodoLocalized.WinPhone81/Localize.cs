using TodoLocalized.WinPhone81;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace TodoLocalized.WinPhone81
{
    public class Localize : ILocale
    {
        public string GetCurrent()
        {
            return Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString();
        }

        public void SetLocale()
        {
            // Do nothing
        }
    }
}