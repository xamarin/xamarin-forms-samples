using Microsoft.Phone.Tasks;
using Solitaire;
using Solitaire.WinPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(TweetButton), typeof(TweetButtonRenderer))]

namespace Solitaire.WinPhone
{
    public class TweetButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            var tweetButton = e.NewElement as TweetButton;

            Control.Click += async (object sender, System.Windows.RoutedEventArgs ea) =>
            {
                // not sure which of these two methods is preferable for tweeting

                var message = tweetButton.FormattedText + " " + tweetButton.AttachedUrl;
                // http://developer.nokia.com/community/wiki/URI_Association_Schemes_List
                var success = await Windows.System.Launcher.LaunchUriAsync(
                    new Uri("twitter:tweet?text=" + message + "")
                );

                //ShareLinkTask twitter = new ShareLinkTask();
                //twitter.Title = "Tweet the Code";
                //twitter.LinkUri = new Uri(tweetButton.AttachedUrl, UriKind.Absolute);
                //twitter.Message = tweetButton.FormattedText;
                //twitter.Show();

            };
        }
    }
}
