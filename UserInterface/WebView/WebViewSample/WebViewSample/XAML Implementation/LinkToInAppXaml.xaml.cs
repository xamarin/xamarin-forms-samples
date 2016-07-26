using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WebViewSample
{
	public partial class LinkToInAppXaml : ContentPage
	{
		public LinkToInAppXaml ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Demonstrates how to load a view for web browsing within an app.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void navButtonClicked(object sender, EventArgs e)
		{
			this.Navigation.PushAsync (new InAppBrowserXaml ("http://www.xamarin.com/"));
		}
	}
}

