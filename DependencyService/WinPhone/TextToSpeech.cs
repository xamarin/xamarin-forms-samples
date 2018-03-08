using DependencyServiceSample.WinPhone;
using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace DependencyServiceSample.WinPhone
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public TextToSpeechImplementation() {}

        public async void Speak(string text)
        {
            MediaElement mediaElement = new MediaElement();

            var synth = new SpeechSynthesizer();

            var stream = await synth.SynthesizeTextToStreamAsync(text);

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }
}
