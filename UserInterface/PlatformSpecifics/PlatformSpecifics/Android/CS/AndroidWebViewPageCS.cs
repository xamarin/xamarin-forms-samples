using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public class AndroidWebViewPageCS : ContentPage
    {
        public AndroidWebViewPageCS()
        {
			var webView = new Xamarin.Forms.WebView { Source = "https://htmlpreview.github.io/?https://github.com/xamarin/xamarin-forms-samples/blob/master/UserInterface/PlatformSpecifics/HTML/mixed_content.html" };
			webView.On<Android>().SetMixedContentMode(MixedContentHandling.AlwaysAllow);
			Content = webView;
        }
    }
}
