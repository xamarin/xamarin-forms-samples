using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyServiceSample;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using DependencyServiceSample.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace DependencyServiceSample.WinPhone
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public TextToSpeechImplementation() {}

        public async void Speak(string text)
        {
            MediaElement mediaElement = new MediaElement();

            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();

            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Hello World");

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
            await synth.SynthesizeTextToStreamAsync(text);
        }
    }
}
