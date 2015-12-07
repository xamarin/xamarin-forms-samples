using System;

using Xamarin.Forms;

namespace CustomRenderer
{
	public class HybridWebViewPageCS : ContentPage
	{
		public HybridWebViewPageCS ()
		{
			var hybridWebView = new HybridWebView {
				Uri = "index.html",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			hybridWebView.RegisterAction (data => DisplayAlert ("Alert", "Hello " + data, "OK"));

			Padding = new Thickness (0, 20, 0, 0);
			Content = hybridWebView;
		}
	}
}
