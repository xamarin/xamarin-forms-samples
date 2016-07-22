using System;
using UsingDependencyService.UWP;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace UsingDependencyService.UWP
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
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
