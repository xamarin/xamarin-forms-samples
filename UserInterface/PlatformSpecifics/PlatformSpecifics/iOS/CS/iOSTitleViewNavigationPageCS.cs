using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSTitleViewNavigationPageCS : Xamarin.Forms.NavigationPage
    {
        public iOSTitleViewNavigationPageCS(Xamarin.Forms.Page page)
        {
            On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
            On<iOS>().SetHideNavigationBarSeparator(true);
            PushAsync(page);
        }
    }
}
