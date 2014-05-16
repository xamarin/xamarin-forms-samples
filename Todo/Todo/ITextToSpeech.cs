using System;
using Xamarin.Forms;

namespace Todo
{
	public interface ITextToSpeech
	{
		void Speak (string text);
	}
}

