using Android.Speech.Tts;

namespace TodoREST.Droid
{
    public class Speech : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech textToSpeech;
        string toSpeak;

        public void Speak(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                toSpeak = text;
                if (textToSpeech == null)
                {
                    textToSpeech = new TextToSpeech(MainActivity.Instance, this);
                }
                else
                {
                    textToSpeech.Speak(toSpeak, QueueMode.Flush, null, null);
                }
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                textToSpeech.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}
