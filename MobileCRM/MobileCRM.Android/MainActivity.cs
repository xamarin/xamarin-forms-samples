using Android.App;
using Android.OS;
using Xamarin.Forms;
using Xamarin;
using MobileCRM.Shared.Pages;
using MobileCRM;

namespace MobileCRMAndroid
{
    [Activity (Label = "MobileCRM", MainLauncher = true)]
    public class MainActivity : Xamarin.Forms.Platform.Android.AndroidActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            MobileCRMApp.Init(typeof(MobileCRMApp).Assembly);
            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);

            // Set our view from the "main" layout resource
            SetPage (BuildView());
        }

        static Page BuildView()
        {
            return new RootPage();
        }
    }
}


