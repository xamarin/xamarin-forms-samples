using System;
using System.Collections.Generic;
using Foundation;
using MessageUI;
using UIKit;
using Xamarin.Forms;
using Xamarin.Social;
using Xamarin.Social.Services;
using EmployeeDirectoryUI;

namespace EmployeeDirectory.iOS
{
	public class iOSPhoneFeatureService : IPhoneFeatureService
	{
		public UIViewController RootViewController { get; private set; }

		public  TwitterService Twitter {
			get {
				return new TwitterService {
					ConsumerKey = "onoOUsBbjVWc8msLyuRJQ",
					ConsumerSecret = "Vxh0zMFRAWp2LbkwfDNvUKU2dQhaVgFFv3M04gDKFE",
					CallbackUrl = new Uri ("http://xamarin.com")
				};
			}
		}

		public iOSPhoneFeatureService (UIViewController rootViewController)
		{
			RootViewController = rootViewController;
		}

		public bool Email (string emailAddress)
		{
			if (MFMailComposeViewController.CanSendMail) {
				var composer = new MFMailComposeViewController ();
				composer.SetToRecipients (new string[] { emailAddress });
				composer.SetSubject ("Hello from EmployeeDirectory!");

				composer.Finished += (sender, e) => RootViewController.DismissViewController (true, null);
				RootViewController.PresentViewController (composer, true, null);
				return true;
			} else {
				return false;
			}
		}

		public bool Browse (string websiteUrl)
		{
			UIApplication.SharedApplication.OpenUrl (NSUrl.FromString (websiteUrl));
			return true;
		}

		public bool Tweet (string twitterName)
		{
			string messageText = string.Format ("Let me introduce to you, " +
			                     "the one and only {0} using #xamarin EmployeeDirectory!", twitterName);

			var item = new Item {
				Text = messageText,
				Links = new List<Uri> { new Uri ("http://xamarin.com") }
			};

			var shareViewController = Twitter.GetShareUI (item, shareResult => {
				RootViewController.DismissViewController (true, null);
			});
			RootViewController.PresentViewController (shareViewController, true, null);
			return true;
		}

		public bool Call (string phoneNumber)
		{
			var url = NSUrl.FromString ("tel:" + Uri.EscapeDataString (phoneNumber));

			if (UIApplication.SharedApplication.CanOpenUrl (url)) {
				UIApplication.SharedApplication.OpenUrl (url);
				return true;
			} else {
				return false;
			}
		}

		public bool Map (string address)
		{
			UIApplication.SharedApplication.OpenUrl (
				NSUrl.FromString ("http://maps.google.com/maps?q=" + Uri.EscapeDataString (address)));

			return true;
		}
	}
}

