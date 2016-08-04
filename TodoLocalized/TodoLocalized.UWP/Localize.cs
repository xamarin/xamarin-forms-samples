using TodoLocalized.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace TodoLocalized.UWP
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