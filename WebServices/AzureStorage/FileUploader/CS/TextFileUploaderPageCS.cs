using System.IO;
using System.Text;
using Xamarin.Forms;

namespace FileUploader
{
	public class TextFileUploaderPageCS : ContentPage
	{
		string uploadedFilename;

		public TextFileUploaderPageCS()
		{
			var uploadEditor = new Editor { HeightRequest = 100 };
			var downloadEditor = new Editor { HeightRequest = 100, IsEnabled = false };
			var activityIndicator = new ActivityIndicator();

			var downloadButton = new Button { Text = "Download", IsEnabled = false };
			downloadButton.Clicked += async (sender, e) =>
			{
				if (!string.IsNullOrWhiteSpace(uploadedFilename))
				{
					activityIndicator.IsRunning = true;

					var byteData = await AzureStorage.GetFileAsync(ContainerType.Text, uploadedFilename);
					var text = Encoding.UTF8.GetString(byteData);
					downloadEditor.Text = text;

					activityIndicator.IsRunning = false;
				}
			};

			var uploadButton = new Button { Text = "Upload" };
			uploadButton.Clicked += async (sender, e) =>
			{
				if (!string.IsNullOrWhiteSpace(uploadEditor.Text))
				{
					activityIndicator.IsRunning = true;

					var byteData = Encoding.UTF8.GetBytes(uploadEditor.Text);
					uploadedFilename = await AzureStorage.UploadFileAsync(ContainerType.Text, new MemoryStream(byteData));

					downloadButton.IsEnabled = true;
					activityIndicator.IsRunning = false;
				}
			};

			Title = "Upload Text";
			Icon = "csharp.png";

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
					new Label { Text = "Text Upload and Download", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
					new Label { Text = "Enter text:" },
					uploadEditor,
					uploadButton,
					activityIndicator,
					downloadButton,
					downloadEditor
				}
			};
		}
	}
}
