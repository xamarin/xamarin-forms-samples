using System;

using Xamarin.Forms;

namespace WebViewSample
{
	public class LinkToInAppCode : ContentPage
	{
		public LinkToInAppCode ()
		{
			this.Title = "In-App Browser Demo";
            var layout = new StackLayout { Margin = new Thickness(20) };

			var label = new Label () {
				Text = "This demonstrates how you would open a link without leaving your app, while giving users a good experience."
			};

			var button = new Button (){ Text = "Navigate to Xamarin" };
			button.Clicked += navButtonClicked;

			layout.Children.Add (label);
			layout.Children.Add (button);
			Content = layout;
		}

		/// <summary>
		/// launches the browser window
		/// </summary>
		void navButtonClicked (object sender, EventArgs e)
		{
			this.Navigation.PushAsync (new InAppBrowserCode ("http://www.xamarin.com/"));
		}
	}
}


