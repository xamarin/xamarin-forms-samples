using Android.App;
using Android.OS;
using Xamarin.QuickUI;
using Xamarin;
using Meetum.Views;

namespace Meetum.Android
{
    [Activity (Label = "Meetum", MainLauncher = true)]
    public class MainActivity : Xamarin.QuickUI.Platform.Android.AndroidActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            QuickUI.Init(this, bundle);
            QuickUIMaps.Init(this, bundle);

            // Set our view from the "main" layout resource
            SetPage (BuildView());
        }

        static Page BuildView()
        {
            return new SearchPage();
        }
    }
}


