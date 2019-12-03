using Xamarin.Forms;

namespace CustomRenderer
{
    public class HybridWebViewPageCS : ContentPage
    {
        public HybridWebViewPageCS()
        {
            var hybridWebView = new HybridWebView
            {
                Uri = "index.html"
            };

            hybridWebView.RegisterAction(data => DisplayAlert("Alert", "Hello " + data, "OK"));

            Padding = new Thickness(0, 40, 0, 0);
            Content = hybridWebView;
        }
    }
}
