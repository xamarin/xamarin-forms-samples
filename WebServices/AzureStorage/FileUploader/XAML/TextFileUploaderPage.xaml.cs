using System;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace FileUploader
{
	public partial class TextFileUploaderPage : ContentPage
	{
		string uploadedFilename;

		public TextFileUploaderPage()
		{
			InitializeComponent();
		}

		async void OnUploadButtonClicked(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(uploadEditor.Text))
			{
				activityIndicator.IsRunning = true;

				var byteData = Encoding.UTF8.GetBytes(uploadEditor.Text);
				uploadedFilename = await AzureStorage.UploadFileAsync(ContainerType.Text, new MemoryStream(byteData));

				downloadButton.IsEnabled = true;
				activityIndicator.IsRunning = false;
			}
		}

		async void OnDownloadButtonClicked(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(uploadedFilename))
			{
				activityIndicator.IsRunning = true;

				var byteData = await AzureStorage.GetFileAsync(ContainerType.Text, uploadedFilename);
				var text = Encoding.UTF8.GetString(byteData);
				downloadEditor.Text = text;

				activityIndicator.IsRunning = false;
			}
		}
	}
}

