using System;
using Xamarin.Forms;

namespace WebViewSample
{
	public class InAppBrowserCode : ContentPage
	{
		WebView webView;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewSample.InAppBrowserXaml"/> class.
        /// Takes a URL indicating the starting page for the browser control.
        /// </summary>
        /// <param name="URL">URL to display in the browser.</param>
        public InAppBrowserCode(string URL)
        {
            this.Title = "Browser";
            var layout = new StackLayout { Margin = new Thickness(20) };
			var controlBar = new StackLayout (){ Orientation = StackOrientation.Horizontal };
			var backButton = new Button{ Text = "Back", HorizontalOptions = LayoutOptions.StartAndExpand };
			backButton.Clicked += backButtonClicked;

            var reloadButton = new Button { Text = "Reload", HorizontalOptions = LayoutOptions.CenterAndExpand };
            reloadButton.Clicked += OnReloadButtonClicked;

			var forwardButton = new Button{ Text = "Forward", HorizontalOptions = LayoutOptions.EndAndExpand };
			forwardButton.Clicked += forwardButtonClicked;

			// WebView needs to be given a height and width request within layouts to render
			webView = new WebView () { WidthRequest = 1000, HeightRequest = 1000, Source = URL };

			controlBar.Children.Add(backButton);
            controlBar.Children.Add(reloadButton);
			controlBar.Children.Add(forwardButton);

			layout.Children.Add(controlBar);
			layout.Children.Add(webView);

			Content = layout;
		}

		/// <summary>
		/// fired when the back button is clicked. If the browser can go back, navigate back.
		/// If the browser can't go back, leave the in-app browser page.
		/// </summary>	
		async void backButtonClicked (object sender, EventArgs e)
		{
			if (webView.CanGoBack) 
            {
				webView.GoBack ();
			} 
            else 
            {
				await Navigation.PopAsync (); // closes the in-app browser view.
			}

		}

        void OnReloadButtonClicked(object sender, EventArgs e)
        {
            webView.Reload();
        }

        /// <summary>
        /// Navigates forward
        /// </summary>
        void forwardButtonClicked (object sender, EventArgs e)
		{
			if (webView.CanGoForward) 
            {
				webView.GoForward ();
			}
		}
	}
}


