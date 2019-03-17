using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using OfflineCurrencyConverter.iOS.Renderers;
using Xamarin.Forms;
using OfflineCurrencyConverter.Views.Views;
using Xamarin.Forms.Platform.iOS;
using Google.MobileAds;

[assembly: ExportRenderer(typeof(MyAdControl), typeof(AdControlCustomRenderer))]
namespace OfflineCurrencyConverter.iOS.Renderers
{
    public class AdControlCustomRenderer : ViewRenderer<MyAdControl, BannerView>
    {
        string bannerId = "ca-app-pub-8573393339218499/5112485485";
        BannerView adView;

        BannerView CreateNativeAdControl()
        {
            if (adView != null)
                return adView;

            adView = new BannerView(size: AdSizeCons.SmartBannerPortrait, origin:
                new CoreGraphics.CGPoint(0, UIScreen.MainScreen.Bounds.Size.Height - AdSizeCons.Banner.Size.Height))
            {
                AdUnitID = bannerId,
                RootViewController = GetVisibleViewController()
            };
            adView.AdReceived += (s, e) =>
            {
                ;
            };
            return adView;
        }

        Request GetRequest()
        {
            var request = Request.GetDefaultRequest();
            return request;
        }

        UIViewController GetVisibleViewController()
        {
            //var rootController = UIApplication.SharedApplication.Windows.First().RootViewController;

            //if (rootController.PresentedViewController == null)
            //    return rootController;

            foreach (UIWindow uiWindow in UIApplication.SharedApplication.Windows)
            {
                if (uiWindow.RootViewController != null)
                {
                    var v = uiWindow.RootViewController; ;
                    return v; 
                }
            }
            return new UIViewController();
            //if (rootController.PresentedViewController is UINavigationController)
            //{
            //    return ((UINavigationController)rootController.PresentedViewController).VisibleViewController;
            //}

            //if (rootController.PresentedViewController is UITabBarController)
            //{
            //    return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
            //}

            //return rootController.PresentedViewController;
            //return new UIViewController();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MyAdControl> e)
        {
            base.OnElementChanged(e);
            if(Control == null)
            {
                CreateNativeAdControl();
                var request = Request.GetDefaultRequest();
                adView.LoadRequest(request);
                SetNativeControl(adView);
            }
        }
    }
}