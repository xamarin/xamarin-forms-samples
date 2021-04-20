using Xamarin.Forms;

namespace WebViewSample
{
    public partial class LoadingLabelXaml : ContentPage
    {
        public LoadingLabelXaml()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the webview starts navigating. Displays the loading label.
        /// </summary>
        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
            this.labelLoading.IsVisible = true; //display the label when navigating starts
        }

        /// <summary>
        /// Called when the webview finished navigating. Hides the loading label.
        /// </summary>
        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
            this.labelLoading.IsVisible = false; //remove the loading indicator when navigating is finished
        }
    }
}

