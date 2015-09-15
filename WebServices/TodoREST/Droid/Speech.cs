using System;
using System.Collections.Generic;
using Android.Speech.Tts;
using Xamarin.Forms;

namespace TodoREST.Droid
{
	public class Speech : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech textToSpeech;
		string toSpeak;

		public void Speak (string text)
		{
			if (!string.IsNullOrWhiteSpace (text)) {
				toSpeak = text;
				if (textToSpeech == null) {
					textToSpeech = new TextToSpeech (Forms.Context, this);
				} else {
					var p = new Dictionary<string, string> ();
					textToSpeech.Speak (toSpeak, QueueMode.Flush, p);
				}
			}
		}

		public void OnInit (OperationResult status)
		{
			if (status.Equals (OperationResult.Success)) {
				var p = new Dictionary<string, string> ();
				textToSpeech.Speak (toSpeak, QueueMode.Flush, p);
			}
		}
	}
}
