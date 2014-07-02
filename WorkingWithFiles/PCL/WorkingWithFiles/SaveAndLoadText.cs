using System;
using Xamarin.Forms;

namespace WorkingWithFiles
{
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
				DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", input.Text);
			};
			var loadButton = new Button {Text = "Load"};
			loadButton.Clicked += (sender, e) => {
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

