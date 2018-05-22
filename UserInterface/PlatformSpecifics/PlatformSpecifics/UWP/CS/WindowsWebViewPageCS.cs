using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public class WindowsWebViewPageCS : ContentPage
    {
		public WindowsWebViewPageCS()
		{
			var webView = new Xamarin.Forms.WebView
			{
				Source = new HtmlWebViewSource
				{
					Html = @"<html><head><link rel=""stylesheet"" href=""default.css""></head><body><button onclick=""window.alert('Hello World');"">Click Me</button></body></html"
				}
			};
			webView.On<Windows>().SetIsJavaScriptAlertEnabled(true);

			Content = webView;
		}
    }
}

