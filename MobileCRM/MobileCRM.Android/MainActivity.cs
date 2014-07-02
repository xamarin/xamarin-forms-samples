using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin;
using MobileCRM.Shared.Pages;
using MobileCRM;

namespace MobileCRMAndroid
{
    [Activity (Label = "MobileCRM", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.AndroidActivity
    {
        private RootPage root;
        
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            MobileCRMApp.Init(typeof(MobileCRMApp).Assembly);
            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);

            // Set our view from the "main" layout resource
            root = BuildView();
            SetPage (root);
        }
        
		public override bool OnKeyUp (Keycode keyCode, KeyEvent e)
		{
			if (keyCode == Keycode.Menu) {
				root.IsPresented = !root.IsPresented;
				return true;
			}

			return base.OnKeyUp (keyCode, e);
		}

        static RootPage BuildView()
        {
            return new RootPage();
        }
    }
}


