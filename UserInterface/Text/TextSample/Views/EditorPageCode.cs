using Xamarin.Forms;

namespace TextSample
{
	public class EditorPageCode : ContentPage
	{
		public EditorPageCode ()
		{
			var layout = new StackLayout { Padding = new Thickness (5, 10) };
			this.Title = "Editor Demo - Code";
			layout.Children.Add (new Label{ Text = "This page demonstrates an auto-sizing Editor View. The Editor is used for collecting text that is expected to take more than one line." });
			var editor = new Editor {
				Text = "Xamarin Blue",
                AutoSize = EditorAutoSizeOption.TextChanges,
				BackgroundColor = Color.FromHex ("#2c3e50"),
			};
            editor.Keyboard = Keyboard.Create(KeyboardFlags.Suggestions | KeyboardFlags.CapitalizeCharacter);

            layout.Children.Add (editor);
			layout.Children.Add (new Editor { IsEnabled = false, Text = "This is a disabled editor" });
			this.Content = layout;
		}
	}
}
