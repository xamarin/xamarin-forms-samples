using Android.App;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin;
using MobileCRM.Shared.Pages;
using MobileCRM;
using Android.Graphics.Drawables;

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
            ActionBar.Hide();
        }

        static Page BuildView()
        {
            return new RootPage();
        }
    }
}


