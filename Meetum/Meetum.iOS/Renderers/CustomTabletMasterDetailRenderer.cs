using System;
using Xamarin.QuickUI.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.QuickUI;
using Meetum.iOS;

[assembly: ExportRenderer (typeof (MasterDetailPage), typeof (CustomTabletMasterDetailRenderer), UIUserInterfaceIdiom.Pad)]
[assembly: ExportRenderer (typeof (NavigationPage), typeof (CustomNavigationRenderer))]

namespace Meetum.iOS
{
    public class CustomNavigationRenderer : NavigationRenderer
    {
        public override void ViewDidLayoutSubviews ()
        {
            base.ViewDidLayoutSubviews ();
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });
        }
    }
    public class CustomTabletMasterDetailRenderer : TabletMasterDetailRenderer
    {
        public override void ViewWillLayoutSubviews ()
        {
            base.ViewWillLayoutSubviews ();
            // Set the splitter to dark gray.
            ParentViewController.View.BackgroundColor = UIColor.FromRGB(100, 100, 100);
        }
    }
}

