using System;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Xamarin.Forms;
using Solitaire.Android;
using Solitaire;

[assembly: ExportRenderer(typeof(TweetButton), typeof(TweetButtonRenderer))]
namespace Solitaire.Android
{
    public class TweetButtonRenderer : ButtonRenderer
    {
        public TweetButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            var tweetButton = e.NewElement as TweetButton;

            var button = Control as global::Android.Widget.Button;

            button.Click += (sender, e1) =>
            {
                // combine message with URL
                var message = tweetButton.FormattedText + " " + tweetButton.AttachedUrl;
                try
                {
                    var intent = new Intent(Intent.ActionSend);
                    intent.PutExtra(Intent.ExtraText, message);
                    intent.SetType("text/plain");
                    MainActivity.Instance.StartActivity(Intent.CreateChooser(intent, "Tweet the Code"));

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Android TweetButtonRenderer Exception: " + ex);
                }
            };
        }
    }
}

