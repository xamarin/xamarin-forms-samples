using Xamarin.Forms;

namespace WorkingWithWebview
{
    public class LocalHtml : ContentPage
    {
        public LocalHtml()
        {
            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><body>
                                <h1>Xamarin.Forms</h1>
                                <p>Welcome to WebView.</p>
                                </body>
                                </html>";
            browser.Source = htmlSource;
            Content = browser;
        }
    }
}
