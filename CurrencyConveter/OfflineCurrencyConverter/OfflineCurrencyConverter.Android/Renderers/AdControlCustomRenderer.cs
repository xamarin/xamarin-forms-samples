using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OfflineCurrencyConverter.Droid.Renderers;
using OfflineCurrencyConverter.Views.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyAdControl), typeof(AdControlCustomRenderer))]
namespace OfflineCurrencyConverter.Droid.Renderers
{
    class AdControlCustomRenderer : ViewRenderer<MyAdControl, AdView>
    {
        string adUnitID = "";
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;

        AdView CreateAdView()
        {
            if (adView != null)
                return adView;

            adView = new AdView(Context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnitID;
            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            adView.LayoutParameters = adParams;
            adView.LoadAd(new AdRequest.Builder().Build());

            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MyAdControl> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                CreateAdView();
                SetNativeControl(adView);
            }
        }

        public AdControlCustomRenderer(Context context) : base(context)
        {

        }
    }
}