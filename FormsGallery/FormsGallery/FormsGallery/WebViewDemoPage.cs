using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class WebViewDemoPage : ContentPage
    {
        public WebViewDemoPage()
        {
            Label header = new Label
            {
                Text = "WebView",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "http://xamarin.com/",
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 0);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    webView
                }
            };
        }
    }
}
