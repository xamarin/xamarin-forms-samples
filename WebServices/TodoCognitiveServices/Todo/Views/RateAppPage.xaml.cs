using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace Todo
{
	public partial class RateAppPage : ContentPage
	{
		EmotionServiceClient emotionClient;
		MediaFile photo;

		public RateAppPage()
		{
			InitializeComponent();
			emotionClient = new EmotionServiceClient(Constants.EmotionApiKey);
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
					using (var photoStream = photo.GetStream())
					{
						Emotion[] emotionResult = await emotionClient.RecognizeAsync(photoStream);
						if (emotionResult.Any())
						{
							// Emotions detected are happiness, sadness, surprise, anger, fear, contempt, disgust, or neutral.
							emotionResultLabel.Text = emotionResult.FirstOrDefault().Scores.ToRankedList().FirstOrDefault().Key;
						}
						photo.Dispose();
					}
				}
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
