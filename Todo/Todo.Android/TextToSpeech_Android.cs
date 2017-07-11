using Android.Speech.Tts;
using Xamarin.Forms;
using System.Collections.Generic;
using Java.Lang;
using Todo;

[assembly: Dependency(typeof(TextToSpeech_Android))]
namespace Todo
{
	public class TextToSpeech_Android : Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speaker;
		string toSpeak;

		public void Speak(string text)
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				toSpeak = text;
				if (speaker == null)
					speaker = new TextToSpeech(Forms.Context, this);
				else
				{
					var p = new Dictionary<string, string>();
					speaker.Speak(toSpeak, QueueMode.Flush, p);
				}
			}
		}

		#region IOnInitListener implementation
		public void OnInit(OperationResult status)
		{
			if (status.Equals(OperationResult.Success))
			{
				var p = new Dictionary<string, string>();
				speaker.Speak(toSpeak, QueueMode.Flush, p);
			}
		}
		#endregion
	}
}