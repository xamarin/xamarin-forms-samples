using Xamarin.Forms;

namespace WorkingWithWebview
{
    public class WebPage : ContentPage
    {
        public WebPage()
        {
            var browser = new WebView();
            browser.Source = "https://dotnet.microsoft.com/apps/xamarin";
            Content = browser;
        }
    }
}

