using System;
using AVFoundation;
using Xamarin.Forms;
using TodoLocalized;

[assembly: Dependency(typeof(TextToSpeech_iOS))]

namespace TodoLocalized
{
    public class TextToSpeech_iOS : ITextToSpeech
    {
        float volume = 0.5f;
        float pitch = 1.0f;

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 3,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = volume,
                PitchMultiplier = pitch
            };
            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}

