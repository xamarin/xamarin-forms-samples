using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TodoAWSSimpleDB.Droid
{
	[Activity(Label = "TodoAWS-SimpleDB.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			Xamarin.Auth.Presenters.OAuthLoginPresenter.PlatformLogin = (authenticator) =>
			{
				var oAuthLogin = new OAuthLoginPresenter();
				oAuthLogin.Login(authenticator);
			};

			App.Speech = new Speech();
			LoadApplication(new App());
		}
	}
}

