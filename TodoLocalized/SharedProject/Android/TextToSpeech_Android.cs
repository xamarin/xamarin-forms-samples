using Android.Speech.Tts;
using Java.Lang;
using Xamarin.Forms;
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
            toSpeak = text;

            if (speaker == null)
            {
                speaker = new TextToSpeech(MainActivity.Instance, this);
            }
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
                System.Diagnostics.Debug.WriteLine("spoke");
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("was quiet");
            }
        }
        #endregion
    }
}

