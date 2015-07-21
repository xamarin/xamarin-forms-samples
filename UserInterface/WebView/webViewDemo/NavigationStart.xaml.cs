using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace webViewDemo
{
	public partial class NavigationStart : ContentPage
	{
		public NavigationStart ()
		{
			InitializeComponent ();
		}

		void onClick(object sender, EventArgs e)
		{
			this.Navigation.PushAsync (new inAppDemo ("http://www.xamarin.com"));
		}
	}
}

