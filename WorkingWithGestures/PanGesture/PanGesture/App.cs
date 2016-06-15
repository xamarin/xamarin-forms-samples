using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation (XamlCompilationOptions.Compile)]
namespace PanGesture
{
	public class App : Application
	{
		public static double ScreenWidth;
		public static double ScreenHeight;

		public App ()
		{
			MainPage = new HomePage ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
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

