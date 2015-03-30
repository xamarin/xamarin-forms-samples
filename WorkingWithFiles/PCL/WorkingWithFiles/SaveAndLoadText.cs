using System;
using Xamarin.Forms;

namespace WorkingWithFiles
{
	/// <summary>
	/// This page includes input boxes and buttons that allow the text to be
	/// saved-to and loaded-from a file. The actual file operations are done 
	/// against an interface, which must be implemented in each of the app
	/// platform projects.
	/// </summary>
	public class SaveAndLoadText : ContentPage
	{
		Button loadButton, saveButton;

		public SaveAndLoadText ()
		{
			var input = new Entry { Text = "" };
			var output = new Label { Text = "" };
			saveButton = new Button {Text = "Save"};

			saveButton.Clicked += async (sender, e) => {
				loadButton.IsEnabled = saveButton.IsEnabled = false;
				// uses the Interface defined in this project, and the implementations that must
				// be written in the iOS, Android and WinPhone app projects to do the actual file manipulation
				await DependencyService.Get<ISaveAndLoad>().SaveTextAsync("temp.txt", input.Text);

				loadButton.IsEnabled = saveButton.IsEnabled = true;
			};

			loadButton = new Button {Text = "Load"};
			loadButton.Clicked += async (sender, e) => {
				loadButton.IsEnabled = saveButton.IsEnabled = false;

				// uses the Interface defined in this project, and the implementations that must
				// be written in the iOS, Android and WinPhone app projects to do the actual file manipulation
				output.Text = await DependencyService.Get<ISaveAndLoad>().LoadTextAsync("temp.txt");
				loadButton.IsEnabled = saveButton.IsEnabled = true;
			};

			var buttonLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { saveButton, loadButton }
			};

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label {
						Text = "Save and Load Text (PCL)",
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