using System;
using Foundation;
using UIKit;

namespace OAuthNativeFlow.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
			global::Xamarin.Auth.Presenters.XamarinIOS.AuthenticationConfiguration.Init();

            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

		public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
		{
			// Convert NSUrl to Uri
			var uri = new Uri(url.AbsoluteString);

			// Load redirectUrl page
			AuthenticationState.Authenticator.OnPageLoading(uri);

			return true;
		}
    }
}
