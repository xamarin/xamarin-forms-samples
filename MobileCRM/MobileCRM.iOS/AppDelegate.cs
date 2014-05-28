using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin;
using MobileCRM.Shared.CustomViews;
using MobileCRM.Shared.Pages;

namespace MobileCRM.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            window = new UIWindow (UIScreen.MainScreen.Bounds);
            
            MobileCRMApp.Init(typeof(MobileCRMApp).Assembly);
            Forms.Init();
            FormsMaps.Init();


            UINavigationBar.Appearance.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
            UINavigationBar.Appearance.TintColor = MobileCRM.Shared.Helpers.Color.Blue.ToUIColor();
            UINavigationBar.Appearance.BarTintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.White
            });
   
            window.RootViewController = BuildView();
            window.MakeKeyAndVisible ();
            
            return true;
        }

        static UIViewController BuildView()
        {
            var root = new RootPage();
            var controller = root.CreateViewController();
            return controller;
        }
    }
}

