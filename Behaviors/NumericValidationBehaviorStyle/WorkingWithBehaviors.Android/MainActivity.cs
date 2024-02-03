using Android.App;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using WorkingWithBehaviors;

namespace NumericValidationBehaviorStyle.Droid
{
    [Activity(Label = "Behaviors",
        Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize
    )]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}
