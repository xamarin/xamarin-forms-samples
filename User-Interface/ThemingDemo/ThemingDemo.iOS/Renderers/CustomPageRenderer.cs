using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace ThemingDemo.iOS
{
    public class CustomPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (Element is IModalPage modalPage)
            {
                NavigationController.TopViewController.NavigationItem.LeftBarButtonItem =
                    new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Plain, (s, e) => modalPage.Dismiss());
            }
        }
    }
}
