

using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin;


namespace HoustonForms.Android
{
    [Activity(Label = "XamarinInsights", 
		MainLauncher = true, 
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			Insights.Initialize(Constants.InsightsApiKey, this);
            
			Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}

