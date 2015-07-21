using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace webViewDemo
{
	public partial class loadingDemo : ContentPage
	{
		public loadingDemo ()
		{
			InitializeComponent ();
			webView.Source = "http://www.xamarin.com";
		}

		void webOnNavigating (object sender, WebNavigatingEventArgs e)
		{
			this.loadingLabel.IsVisible = true;
		}

		void webOnEndNavigating (object sender, WebNavigatedEventArgs e)
		{
			this.loadingLabel.IsVisible = false;
		}
	}
}

