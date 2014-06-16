using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.WinPhone;
using Windows.Phone.Speech.Synthesis;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeech_WinPhone))]

namespace Todo.WinPhone
{
	public class TextToSpeech_WinPhone : ITextToSpeech
	{
		// http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj207057(v=vs.105).aspx
		public async void Speak(string text)
		{
			SpeechSynthesizer synth = new SpeechSynthesizer();

			await synth.SpeakTextAsync(text);
		}
	}
}
