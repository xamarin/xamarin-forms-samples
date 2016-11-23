using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Gcm.Client;

namespace TodoAzure.Droid
{
	[Activity(Label = "TodoAzure.Droid",
		Icon = "@drawable/icon",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		Theme = "@android:style/Theme.Holo.Light")]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		public static MainActivity CurrentActivity { get; private set; }

		protected override void OnCreate(Bundle bundle)
		{
			CurrentActivity = this;
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			LoadApplication(new App());

			try
			{
				// Check to ensure everything's setup right
				GcmClient.CheckDevice(this);
				GcmClient.CheckManifest(this);

				// Register for push notifications
				System.Diagnostics.Debug.WriteLine("Registering...");
				GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
			}
			catch (Java.Net.MalformedURLException)
			{
				CreateAndShowDialog("There was an error creating the client. Verify the URL.", "Error");
			}
			catch (Exception e)
			{
				CreateAndShowDialog(e.Message, "Error");
			}
		}

		void CreateAndShowDialog(String message, String title)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder(this);

			builder.SetMessage(message);
			builder.SetTitle(title);
			builder.Create().Show();
		}
	}
}

