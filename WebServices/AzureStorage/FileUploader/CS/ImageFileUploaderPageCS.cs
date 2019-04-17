using System.IO;
using Xamarin.Forms;

namespace FileUploader.CS
{
    public class ImageFileUploaderPageCS : ContentPage
    {
        string uploadedFilename;
        byte[] byteData = null;

        public ImageFileUploaderPageCS()
        {
            var imageToUpload = new Image();
            var downloadedImage = new Image();
            var activityIndicator = new ActivityIndicator();

            var downloadButton = new Button { Text = "Download Image", IsEnabled = false };
            downloadButton.Clicked += async (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(uploadedFilename))
                {
                    activityIndicator.IsRunning = true;

                    var imageData = await AzureStorage.GetFileAsync(ContainerType.Image, uploadedFilename);
                    downloadedImage.Source = ImageSource.FromStream(() => new MemoryStream(imageData));

                    activityIndicator.IsRunning = false;
                }
            };

            var uploadButton = new Button { Text = "Upload Image" };
            uploadButton.Clicked += async (sender, e) =>
            {
                activityIndicator.IsRunning = true;

                uploadedFilename = await AzureStorage.UploadFileAsync(ContainerType.Image, new MemoryStream(byteData));

                uploadButton.IsEnabled = false;
                downloadButton.IsEnabled = true;
                activityIndicator.IsRunning = false;
            };

            byteData = Convert.ToByteArray("FileUploader.waterfront.jpg");
            imageToUpload.Source = ImageSource.FromStream(() => new MemoryStream(byteData));

            Title = "Upload Image";
            Icon = "csharp.png";

            Content = new ScrollView
            {
                Margin = new Thickness(20,35,20,20),
                Content = new StackLayout
                {
                    Children = {
                        new Label { Text = "Image Upload and Download", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                        imageToUpload,
                        uploadButton,
                        activityIndicator,
                        downloadButton,
                        downloadedImage
                    }
                }
            };
        }
    }
}

