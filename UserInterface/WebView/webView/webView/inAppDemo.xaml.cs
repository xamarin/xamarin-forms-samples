using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace webView
{
	public partial class inAppDemo : ContentPage
	{
		public inAppDemo (string URL)
		{
			InitializeComponent ();
			this.webView.Source = URL;
		}


		void backClicked(object sender, EventArgs e)
		{
			if (this.webView.CanGoBack) {
				webView.GoBack ();
			} else {
				this.Navigation.PopAsync ();
			}
		}

		void forwardClicked(object sender, EventArgs e)
		{
			if (this.webView.CanGoForward) {
				this.webView.GoForward ();
			}
		}
	}
}

