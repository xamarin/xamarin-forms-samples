using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Solitaire;
using Solitaire.iOS;
using UIKit;
using Twitter;

[assembly:ExportRenderer(typeof(TweetButton), typeof(TweetButtonRenderer))]


namespace Solitaire.iOS
{
	public class TweetButtonRenderer : ButtonRenderer
	{

		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);

			var tweetButton = e.NewElement as TweetButton;

			var button = Control as UIButton;

			button.TouchUpInside += (object sender, EventArgs ea) => {
				var tweetController = new TWTweetComposeViewController();
				// add message, attach URL
				tweetController.SetInitialText (tweetButton.FormattedText); 
				tweetController.AddUrl(new Foundation.NSUrl(tweetButton.AttachedUrl));
				tweetController.ModalInPopover = true;

				var parentview = button.Superview;
				parentview.Window.RootViewController.PresentViewController(tweetController, true, null);
			};
		}
	}
}

