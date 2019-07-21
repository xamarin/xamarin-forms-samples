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
                HeightRequest = 50,
				Source = new HtmlWebViewSource
				{
                    Html = @"<html><body><button onclick=""window.alert('Hello World from JavaScript');"">Click Me</button></body></html>"
                }
			};
			webView.On<Windows>().SetIsJavaScriptAlertEnabled(true);

            var toggleButton = new Button { Text = "Toggle JavaScript alert" };
            toggleButton.Clicked += (sender, e) => webView.On<Windows>().SetIsJavaScriptAlertEnabled(!webView.On<Windows>().IsJavaScriptAlertEnabled());

            Title = "WebView JavaScript Alert";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = { webView, toggleButton }
            };
		}
    }
}

