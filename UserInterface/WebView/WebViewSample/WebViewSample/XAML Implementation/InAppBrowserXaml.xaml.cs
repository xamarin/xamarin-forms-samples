using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WebViewSample
{
	public partial class InAppBrowserXaml : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="WebViewSample.InAppBrowserXaml"/> class.
		/// Takes a URL indicating the starting page for the browser control.
		/// </summary>
		/// <param name="URL">URL to display in the browser.</param>
		public InAppBrowserXaml (string URL)
		{
			InitializeComponent ();
			webView.Source = URL;
		}

		/// <summary>
		/// fired when the back button is clicked. If the browser can go back, navigate back.
		/// If the browser can't go back, leave the in-app browser page.
		/// </summary>
		void backButtonClicked (object sender, EventArgs e)
		{
			if (webView.CanGoBack) {
				webView.GoBack ();
			} else {
				this.Navigation.PopAsync (); // closes the in-app browser view.
			}
		}

		/// <summary>
		/// Navigates forward
		/// </summary>
		void forwardButtonClicked(object sender, EventArgs e)
		{
			if (webView.CanGoForward) {
				webView.GoForward ();
			}
		}
	}
}

