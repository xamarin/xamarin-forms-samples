using Android.Speech.Tts;
using Xamarin.Forms;
using System.Diagnostics;
using Java.Lang;
using TodoLocalized;

[assembly: Dependency(typeof(TextToSpeech_Android))]

namespace TodoLocalized
{
    public class TextToSpeech_Android : Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;

        public void Speak(string text)
        {
            var c = MainActivity.Instance;
            toSpeak = text;
            if (speaker == null)
                speaker = new TextToSpeech(c, this);
            else
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                Debug.WriteLine("spoke");
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
            else
                Debug.WriteLine("was quiet");
        }
        #endregion
    }
}