using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using WebView = Xamarin.Forms.WebView;

namespace PlatformSpecifics
{
    public class AndroidWebViewZoomPageCS : ContentPage
    {
        public AndroidWebViewZoomPageCS()
        {
            WebView webView = new WebView
            {
                Source = "https://www.xamarin.com"
            };

            webView.On<Android>()
                .SetEnableZoomControls(true)
                .SetDisplayZoomControls(true);

            Title = "WebView Zoom Controls";
            Content = webView;
        }
    }
}
