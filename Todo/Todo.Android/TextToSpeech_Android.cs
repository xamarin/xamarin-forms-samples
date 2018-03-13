using Android.Speech.Tts;
using Xamarin.Forms;
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
                    speaker = new TextToSpeech(MainActivity.Instance, this);
                else
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null, null);
                }
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
        #endregion
    }
}