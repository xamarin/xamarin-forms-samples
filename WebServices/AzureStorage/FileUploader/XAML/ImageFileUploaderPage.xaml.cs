using System;
using System.IO;
using Xamarin.Forms;

namespace FileUploader
{
	public partial class ImageFileUploaderPage : ContentPage
	{
		string uploadedFilename;
		byte[] byteData;

		public ImageFileUploaderPage()
		{
			InitializeComponent();

#if __IOS__
			byteData = Convert.ToByteArray("FileUploader.iOS.waterfront.jpg");
#endif
#if __ANDROID__
			byteData = Convert.ToByteArray("FileUploader.Droid.waterfront.jpg");
#endif
#if WINDOWS_UWP
			byteData = Convert.ToByteArray("FileUploader.UWP.waterfront.jpg");
#endif

			imageToUpload.Source = ImageSource.FromStream(() => new MemoryStream(byteData));
		}

		async void OnUploadImageButtonClicked(object sender, EventArgs e)
		{
			activityIndicator.IsRunning = true;

			uploadedFilename = await AzureStorage.UploadFileAsync(ContainerType.Image, new MemoryStream(byteData));

			uploadButton.IsEnabled = false;
			downloadButton.IsEnabled = true;
			activityIndicator.IsRunning = false;
		}

		async void OnDownloadImageButtonClicked(object sender, EventArgs e)
		{

			if (!string.IsNullOrWhiteSpace(uploadedFilename))
			{
				activityIndicator.IsRunning = true;

				var imageData = await AzureStorage.GetFileAsync(ContainerType.Image, uploadedFilename);
				downloadedImage.Source = ImageSource.FromStream(() => new MemoryStream(imageData));

				activityIndicator.IsRunning = false;
			}
		}
	}
}
