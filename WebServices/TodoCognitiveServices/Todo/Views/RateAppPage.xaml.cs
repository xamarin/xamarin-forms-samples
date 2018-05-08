using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Todo.Exceptions;
using Todo.Models;
using Todo.Services;

namespace Todo
{
    public partial class RateAppPage : ContentPage
    {
		IFaceRecognitionService _faceRecognitionService;
        MediaFile photo;

        public RateAppPage()
        {
            InitializeComponent();

			_faceRecognitionService = new FaceRecognitionService();
        }

        async void OnTakePhotoButtonClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            // Take photo
            if (CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakePhotoSupported)
            {
                photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Name = "emotion.jpg",
                    PhotoSize = PhotoSize.Small
                });

                if (photo != null)
                {
                    image.Source = ImageSource.FromStream(photo.GetStream);
                }
            }
            else
            {
                await DisplayAlert("No Camera", "Camera unavailable.", "OK");
            }

            ((Button)sender).IsEnabled = false;
            activityIndicator.IsRunning = true;

            // Recognize emotion
            try
            {
                if (photo != null)
                {
                    var faceAttributes = new FaceAttributeType[] { FaceAttributeType.Emotion };
                    using (var photoStream = photo.GetStream())
                    {
						Face[] faces = await _faceRecognitionService.DetectAsync(photoStream, true, false, faceAttributes);
                        if (faces.Any())
                        {
                            // Emotions detected are happiness, sadness, surprise, anger, fear, contempt, disgust, or neutral.
                            emotionResultLabel.Text = faces.FirstOrDefault().FaceAttributes.Emotion.ToRankedList().FirstOrDefault().Key;
                        }
                        photo.Dispose();
                    }
                }
            }
            catch (FaceAPIException fx)
            {
                Debug.WriteLine(fx.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            activityIndicator.IsRunning = false;
            ((Button)sender).IsEnabled = true;
        }
    }
}
