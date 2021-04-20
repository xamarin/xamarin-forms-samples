using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin;
using MobileCRM.Shared.CustomViews;
using MobileCRM.Shared.Pages;
using Xamarin.Forms.Platform.iOS;

namespace MobileCRM.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
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

			LoadApplication (new App ());

			return base.FinishedLaunching (app,options);
        }
    }
}

