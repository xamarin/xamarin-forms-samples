using System;

using Xamarin.Forms;

namespace WebViewSample
{
	public class InAppBrowserCode : ContentPage
	{
		//this needs to be defined at class level for use within methods.
		private WebView webView;

		/// <summary>
		/// Initializes a new instance of the <see cref="WebViewSample.InAppBrowserXaml"/> class.
		/// Takes a URL indicating the starting page for the browser control.
		/// </summary>
		/// <param name="URL">URL to display in the browser.</param>
		public InAppBrowserCode (string URL)
		{
			this.Title = "Browser";
			var layout = new StackLayout ();
			var controlBar = new StackLayout (){ Orientation = StackOrientation.Horizontal };
			var backButton = new Button{ Text = "Back", HorizontalOptions = LayoutOptions.Start };
			backButton.Clicked += backButtonClicked;

			var forwardButton = new Button{ Text = "Forward", HorizontalOptions = LayoutOptions.EndAndExpand };
			forwardButton.Clicked += forwardButtonClicked;

			//WebView needs to be given a height and width request within layouts to render
			webView = new WebView () { WidthRequest = 1000, HeightRequest = 1000, Source = URL };

			controlBar.Children.Add (backButton);
			controlBar.Children.Add (forwardButton);

			layout.Children.Add (controlBar);
			layout.Children.Add (webView);


			Content = layout;
		}

		/// <summary>
		/// fired when the back button is clicked. If the browser can go back, navigate back.
		/// If the browser can't go back, leave the in-app browser page.
		/// </summary>	
		void backButtonClicked (object sender, EventArgs e)
		{
			if (webView.CanGoBack) {
				webView.GoBack ();
			} else {
				this.Navigation.PopAsync (); // closes the in-app browser view.
			}

		}


		/// <summary>
		/// Navigates forward
		/// </summary>
		void forwardButtonClicked (object sender, EventArgs e)
		{
			if (webView.CanGoForward) {
				webView.GoForward ();
			}
		}
	}
}


