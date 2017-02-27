using UIKit;
using Xamarin.Auth;

namespace TodoAWSSimpleDB.iOS
{
	public class OAuthLoginPresenter
	{
		UIViewController rootViewController;

		public void Login(Authenticator authenticator)
		{
			authenticator.Completed += AuthenticatorCompleted;

			rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
			rootViewController.PresentViewController(authenticator.GetUI(), true, null);
		}

		void AuthenticatorCompleted(object sender, AuthenticatorCompletedEventArgs e)
		{
			rootViewController.DismissViewController(true, null);
			((Authenticator)sender).Completed -= AuthenticatorCompleted;
		}
	}
}
