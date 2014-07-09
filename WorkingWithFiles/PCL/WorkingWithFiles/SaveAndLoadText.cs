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
		public SaveAndLoadText ()
		{
			var input = new Editor { Text = "" };
			if (Device.OS == TargetPlatform.iOS)
				input.HeightRequest = 40;
			var output = new Label { Text = "" };
			var saveButton = new Button {Text = "Save"};

			saveButton.Clicked += (sender, e) => {
				// uses the Interface defined in this project, and the implementations that must
				// be written in the iOS, Android and WinPhone app projects to do the actual file manipulation
				DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", input.Text);
			};

			var loadButton = new Button {Text = "Load"};
			loadButton.Clicked += (sender, e) => {
				// uses the Interface defined in this project, and the implementations that must
				// be written in the iOS, Android and WinPhone app projects to do the actual file manipulation
				output.Text = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");
			};

			var buttonLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { saveButton, loadButton }
			};

			Content = new StackLayout {
				Padding = new Thickness (0,20,0,0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Save and Load Text (PCL)", Font = Font.BoldSystemFontOfSize(NamedSize.Medium)},
					new Label { Text = "Type below and press Save, then Load" },
					input,
					buttonLayout,
					output
				} 
			};
		}
	}
}