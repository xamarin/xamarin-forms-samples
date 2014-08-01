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

            // sadly I don't know an easy way to trigger a Tweet in Windows Phone 8 :-(
            Control.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
