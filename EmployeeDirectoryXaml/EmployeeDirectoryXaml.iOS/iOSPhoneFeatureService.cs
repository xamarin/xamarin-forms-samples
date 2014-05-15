using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MessageUI;
using Xamarin.Forms;

namespace EmployeeDirectory.iOS
{
	public class iOSPhoneFeatureService : IPhoneFeatureService
	{
		public bool Call (string phoneNumber)
		{
			var url = NSUrl.FromString("tel:" + Uri.EscapeDataString(phoneNumber));

			if (UIApplication.SharedApplication.CanOpenUrl (url)) {
				UIApplication.SharedApplication.OpenUrl (url);
				return true;
			} else {
				return false;
			}
		}

		public bool Email (string emailAddress)
		{
			if (MFMailComposeViewController.CanSendMail) {
				var composer = new MFMailComposeViewController ();
				composer.SetToRecipients(new string[] { emailAddress });
				//TODO: open the Mail View Controller
//				composer.Finished += (sender, e) => DismissViewController (true, null);
//				PresentViewController (composer, true, null);

				return true;
			} else {
				return false;
			}
		}

		public bool Tweet (string twitterName)
		{
			var name = twitterName;
			if (name.StartsWith ("@")) {
				name = name.Substring (1);
			}
			//TODO: really should use TW or Social framework
			var scheme = "twitter://user?screen_name=" + name;
			var url = NSUrl.FromString (scheme);
			if (UIApplication.SharedApplication.CanOpenUrl (url)) {
				UIApplication.SharedApplication.OpenUrl (url);
			} else {
				url = NSUrl.FromString ("http://twitter.com/" + Uri.EscapeDataString (name));
				UIApplication.SharedApplication.OpenUrl (url);
			}

			return true;
		}

		public bool Browse (string websiteUrl)
		{
			UIApplication.SharedApplication.OpenUrl (NSUrl.FromString (websiteUrl));

			return true;
		}

		public bool Map (string address)
		{
			UIApplication.SharedApplication.OpenUrl (
				NSUrl.FromString ("http://maps.google.com/maps?q=" + Uri.EscapeDataString (address)));

			return true;
		}
	}
}

