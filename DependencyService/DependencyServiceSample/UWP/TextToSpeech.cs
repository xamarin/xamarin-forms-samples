using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DependencyServiceSample.UWP;
using Windows.Media.SpeechSynthesis;
using Xamarin.Forms;

[assembly:Dependency(typeof(TextToSpeechImplementation))]
namespace DependencyServiceSample.UWP
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public async void Speak(string text)
        {
            var mediaElement = new MediaElement();
            var synth = new SpeechSynthesizer();
            var stream = await synth.SynthesizeTextToStreamAsync(text);

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }
}

