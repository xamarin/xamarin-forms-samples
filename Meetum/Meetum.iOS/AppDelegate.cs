using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.QuickUI;
using Xamarin;
using Meetum.Views;

namespace Meetum.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            window = new UIWindow (UIScreen.MainScreen.Bounds);
            
            QuickUI.Init();
            QuickUIMaps.Init();

            window.RootViewController = BuildView();
            window.MakeKeyAndVisible ();
            
            return true;
        }

        static UIViewController BuildView()
        {
            var root = new SearchPage();
            var controller = root.CreateViewController();
            return controller;
        }
    }
}

