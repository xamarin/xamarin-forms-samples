using Android.App;
using Android.OS;

using Xamarin.Forms.Platform.Android;


namespace TodoLocalized
{
    [Activity(Label = "Todo.Android.Android", MainLauncher = true)]
    public class MainActivity : FormsApplicationActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Instance = this;
            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

