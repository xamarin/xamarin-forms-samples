using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class WindowsWebViewPage : ContentPage
    {
        public WindowsWebViewPage()
        {
            InitializeComponent();

			webView.Source = new HtmlWebViewSource
            {
                Html = @"<html><head><link rel=""stylesheet"" href=""default.css""></head><body><button onclick=""window.alert('Hello World');"">Click Me</button></body></html"
            };
        }
    }
}
