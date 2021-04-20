using System;
using System.IO;
using Xamarin.Forms;

namespace WorkingWithFiles
{
	/// <summary>
	/// This page includes input boxes and buttons that allow the text to be
	/// saved-to and loaded-from a file.
	/// </summary>
	public class SaveAndLoadText : ContentPage
	{
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
		Button loadButton, saveButton;

		public SaveAndLoadText ()
		{
			var input = new Entry { Text = "" };
			var output = new Label { Text = "" };
			saveButton = new Button {Text = "Save"};

			saveButton.Clicked += (sender, e) => 
            {
				loadButton.IsEnabled = saveButton.IsEnabled = false;
                File.WriteAllText(fileName, input.Text);
				loadButton.IsEnabled = saveButton.IsEnabled = true;
			};

			loadButton = new Button {Text = "Load"};
			loadButton.Clicked += (sender, e) => 
            {
				loadButton.IsEnabled = saveButton.IsEnabled = false;
                output.Text = File.ReadAllText(fileName);
				loadButton.IsEnabled = saveButton.IsEnabled = true;
			};
            loadButton.IsEnabled = File.Exists(fileName);

			var buttonLayout = new StackLayout 
            {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { saveButton, loadButton }
			};

			Content = new StackLayout 
            {
                Margin = new Thickness(20),
				Children = 
                {
					new Label 
                    {
						Text = "Save and Load Text",
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold
					},
					new Label { Text = "Type below and press Save, then Load" },
					input,
					buttonLayout,
					output
				}
			};
		}
	}
}