using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public partial class WindowsWebViewPage : ContentPage
    {
        public WindowsWebViewPage()
        {
            InitializeComponent();

			_webView.Source = new HtmlWebViewSource
            {
                Html = @"<html><head><link rel=""stylesheet"" href=""default.css""></head><body><button onclick=""window.alert('Hello World from JavaScript');"">Click Me</button></body></html"
            };
        }

        void OnToggleButtonClicked(object sender, EventArgs e)
        {
            _webView.On<Windows>().SetIsJavaScriptAlertEnabled(!_webView.On<Windows>().IsJavaScriptAlertEnabled());
        }
    }
}
