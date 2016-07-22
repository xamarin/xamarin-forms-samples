using System;
using Android.Speech.Tts;
using System.Collections.Generic;
using Xamarin.Forms;
using DependencyServiceSample.Droid;

[assembly: Xamarin.Forms.Dependency (typeof (TextToSpeechImplementation))]
namespace DependencyServiceSample.Droid
{
	
	public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speaker;
		string toSpeak;

		public TextToSpeechImplementation () {}

		public void Speak (string text)
		{
			var ctx = Forms.Context; // useful for many Android SDK features
			toSpeak = text;
			if (speaker == null) {
				speaker = new TextToSpeech (ctx, this);
			} else {
				var p = new Dictionary<string,string> ();
				speaker.Speak (toSpeak, QueueMode.Flush, p);
			}
		}

		#region IOnInitListener implementation
		public void OnInit (OperationResult status)
		{
			if (status.Equals (OperationResult.Success)) {
				var p = new Dictionary<string,string> ();
				speaker.Speak (toSpeak, QueueMode.Flush, p);
			}
		}
		#endregion
	}
}

