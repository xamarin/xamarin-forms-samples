using System;
using Xamarin.Forms;

namespace WebViewSample
{
    public partial class InAppBrowserXaml : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewSample.InAppBrowserXaml"/> class.
        /// Takes a URL indicating the starting page for the browser control.
        /// </summary>
        /// <param name="URL">URL to display in the browser.</param>
        public InAppBrowserXaml(string URL)
        {
            InitializeComponent();
            webView.Source = URL;
        }

        /// <summary>
        /// fired when the back button is clicked. If the browser can go back, navigate back.
        /// If the browser can't go back, leave the in-app browser page.
        /// </summary>
        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            {
                await Navigation.PopAsync(); // closes the in-app browser view.
            }
        }

        void OnReloadButtonClicked(object sender, EventArgs e)
        {
            webView.Reload();
        }

        /// <summary>
        /// Navigates forward
        /// </summary>
        void OnForwardButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }
    }
}

