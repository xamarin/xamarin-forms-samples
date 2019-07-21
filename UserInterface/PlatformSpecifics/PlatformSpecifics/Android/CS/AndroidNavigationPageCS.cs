using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace PlatformSpecifics
{
    public class AndroidNavigationPageCS : Xamarin.Forms.NavigationPage
    {
        public AndroidNavigationPageCS(Page page)
        {
            On<Android>().SetBarHeight(450);
            PushAsync(page);
        }
    }
}
