using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Phoneword.iOS.Views;

namespace Phoneword.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public static AppDelegate Instance;

        UIWindow _window;
        UINavigationController _navigation;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Forms.Init();

            Instance = this;
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.Black
            });

            var mainPage = new PhonewordPage().CreateViewController();
            mainPage.Title = "Phoneword";

            _navigation = new UINavigationController(mainPage);
            _window.RootViewController = _navigation;
            _window.MakeKeyAndVisible();

            return true;
        }

        public void NavigateToCallHistoryPage()
        {
            var callHistoryPage = new CallHistoryPage().CreateViewController();
            callHistoryPage.Title = "Call History";
            _navigation.PushViewController(callHistoryPage, true);
        }
    }
}
