using System;
using Xamarin.Forms;

namespace Solitaire
{
	public class TweetButton : Button 
	{
		const string tweetText = "Tell me more about Xaml #Petzold at #Xamarin Evolve {0}";

		public TweetButton () {
			Code = "";
		}

		// encrypted code to tweet about
		public string Code { get; set; }

		// url to blog post/competition
		public string AttachedUrl = "http://bit.ly/WWExLo";

		// embed code in the tweet text
		public string FormattedText {
			get { 
				return String.Format (tweetText, Code);
			}
		}
	}
}

