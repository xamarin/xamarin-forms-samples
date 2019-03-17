using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using OfflineCurrencyConverter.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace OfflineCurrencyConverter
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            // Initialize Live Reload.
#if DEBUG
            LiveReload.Init();
#endif
            new AppLocator();
            MainPage = (new MainPage());
		}

		protected override void OnStart ()
		{
            AppCenter.Start("ios=" +
                "uwp=" +
                "android=", typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
