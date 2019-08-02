using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Notes.Controllers
{
    public class OverrideNavigationController : UINavigationController
    {
        public OverrideNavigationController() : base()
        {
        }

        public OverrideNavigationController(NSCoder coder) : base(coder)
        {
        }

        public OverrideNavigationController(UIViewController rootViewController) : base(rootViewController)
        {
        }

        public OverrideNavigationController(Type navigationBarType, Type toolbarType) : base(navigationBarType, toolbarType)
        {
        }

        public OverrideNavigationController(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        /// Xamarin.iOS does not automatically dispose of ViewControllers on NavigationStack Pop.
        /// It is the responsibility of the developer to ensure that a ViewController is Disposed when it
        /// is no longer in Scope
        /// This is an example of how we can do this.
        public override UIViewController PopViewController(bool animated)
        {
            var topView = this.TopViewController;
            if (topView != null)
            {
                // Dispose of Viewcontroller on Navigation back if you no longer require it.
                topView.Dispose();
            }

            return base.PopViewController(animated);
        }
    }
}