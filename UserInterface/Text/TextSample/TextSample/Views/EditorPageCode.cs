using System;

using Xamarin.Forms;

namespace TextSample
{
	public class EditorPageCode : ContentPage
	{
		Editor styledEditor = new Editor();
		public EditorPageCode ()
		{
			var layout = new StackLayout { Padding = new Thickness (5, 10) };
			this.Title = "Editor Demo - Code";
			layout.Children.Add (new Label{ Text = "This page demonstrates the Editor View. The Editor is used for collecting text that is expected to take more than one line." });
			styledEditor = new Editor {
				Text = "Xamarin Blue",
				BackgroundColor = Color.FromHex ("#2c3e50"),
				HeightRequest = 100
			};

			layout.Children.Add (new Editor { Text = "Default starting text" });
			layout.Children.Add (new Editor { IsEnabled = false, Text = "This is a disabled editor" });
			this.Content = layout;
		}
	}
}


