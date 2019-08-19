using System;
using Foundation;
using UIKit;

namespace Notes.Controllers
{
    public class AppNavigationController : UINavigationController
    {
        public AppNavigationController() : base()
        {
        }

        public AppNavigationController(NSCoder coder) : base(coder)
        {
        }

        public AppNavigationController(UIViewController rootViewController) : base(rootViewController)
        {
        }

        public AppNavigationController(Type navigationBarType, Type toolbarType) : base(navigationBarType, toolbarType)
        {
        }

        public AppNavigationController(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        /// Xamarin.iOS does not automatically dispose of ViewControllers when a page is popped
        /// from the navigation stack. It's the responsibility of the developer to ensure that a
        /// ViewController is disposed when it is no longer in scope.
        public override UIViewController PopViewController(bool animated)
        {
            UIViewController topView = TopViewController;
            if (topView != null)
            {
                // Dispose of Viewcontroller on back navigation.
                topView.Dispose();
            }

            return base.PopViewController(animated);
        }
    }
}