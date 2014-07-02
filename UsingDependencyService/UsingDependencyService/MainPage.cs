using System;
using Xamarin.Forms;

namespace UsingDependencyService
{
	public class MainPage : ContentPage
	{
		public MainPage ()
		{
			var speak = new Button {
				Text = "Hello, Forms !",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			speak.Clicked += (sender, e) => {
				DependencyService.Get<ITextToSpeech>().Speak("Hello from Xamarin Forms");
			};
			Content = speak;
		}
	}
}

