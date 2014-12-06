using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using WorkingWithWebview;
using WorkingWithWebview.iOS;

[assembly: ExportRenderer (typeof (BaseUrlWebView), typeof (BaseUrlWebViewRenderer))]

namespace WorkingWithWebview.iOS
{
	public class BaseUrlWebViewRenderer : WebViewRenderer 
	{
		public override void LoadHtmlString (string s, NSUrl baseUrl) 
		{
			if (baseUrl == null) {
				baseUrl = new NSUrl (NSBundle.MainBundle.BundlePath, true);
			}
			base.LoadHtmlString (s, baseUrl);
		}
	}
}

