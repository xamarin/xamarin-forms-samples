using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace EmployeeDirectory.Android
{
	public class AndroidPhoneFeatureService : IPhoneFeatureService
	{
		#region IPhoneFeatureService implementation

		public bool Email (string emailAddress)
		{
			var intent = new Intent (Intent.ActionSend);
			intent.SetType ("message/rfc822");
			intent.PutExtra (Intent.ExtraEmail, new [] { emailAddress });
			Forms.Context.StartActivity (Intent.CreateChooser (intent, "Send email"));

			return true;
		}

		public bool Browse (string websiteUrl)
		{
			var url = websiteUrl.ToUpperInvariant ().StartsWith ("HTTP") ?
				websiteUrl :
				"http://" + websiteUrl;

			var intent = new Intent (Intent.ActionView, 
				global::Android.Net.Uri.Parse (url));
			Forms.Context.StartActivity (intent);

			return true;
		}

		public bool Tweet (string twitterName)
		{
			var username = twitterName.Trim ();
			if (username.StartsWith ("@")) {
				username = username.Substring (1);
			}
			var url = "http://twitter.com/" + username;

			var intent = new Intent (Intent.ActionView, 
				global::Android.Net.Uri.Parse (url));
			Forms.Context.StartActivity (intent);

			return true;
		}

		public bool Call (string phoneNumber)
		{
			var intent = new Intent (Intent.ActionCall, global::Android.Net.Uri.Parse (
				"tel:" + Uri.EscapeDataString (phoneNumber)));
			Forms.Context.StartActivity (intent);

			return true;
		}

		public bool Map (string address)
		{
			throw new NotImplementedException ("This wasn't implemented in the original Android app...");
		}

		#endregion


	}
}

