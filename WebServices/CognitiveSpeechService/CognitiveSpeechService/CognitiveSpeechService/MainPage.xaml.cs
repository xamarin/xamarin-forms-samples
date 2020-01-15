using CognitiveSpeechService.Services;
using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CognitiveSpeechService
{
    public partial class MainPage : ContentPage
    {
        SpeechRecognizer recognizer;
        IMicrophoneService micService;
        bool isTranscribing = false;

        public MainPage()
        {
            InitializeComponent();

            micService = DependencyService.Resolve<IMicrophoneService>();
        }

        async void TranscribeClicked(object sender, EventArgs e)
        {
            bool isMicEnabled = await micService.GetPermissionAsync();

            // Speech recognizer 
            if(recognizer == null)
            {
                var config = SpeechConfig.FromSubscription(Constants.CognitiveServicesApiKey, Constants.CognitiveServicesRegion);
                recognizer = new SpeechRecognizer(config);
                recognizer.Recognized += (obj, args) =>
                {
                    UpdateTranscription(args.Result.Text);
                };
            }

            // EARLY OUT: make sure mic is accessible
            if (!isMicEnabled)
            {
                UpdateTranscription("Please grant access to the microphone!");
                return;
            }

            // if already transcribing, stop speech recognizer
            if(isTranscribing)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    transcribingIndicator.IsRunning = false;
                });

                try
                {
                    await recognizer.StopContinuousRecognitionAsync();
                }
                catch(Exception ex)
                {
                    UpdateTranscription(ex.Message);
                }
                
                isTranscribing = false;
            }

            // if not transcribing, clear existing text and start speech recognizer
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    transcribingIndicator.IsRunning = true;
                    InsertDateTimeRecord();
                });

                try
                {
                    await recognizer.StartContinuousRecognitionAsync();
                }
                catch(Exception ex)
                {
                    UpdateTranscription(ex.Message);
                }
                
                isTranscribing = true;
            }

            UpdateButton();
        }

        void UpdateTranscription(string newText)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if(!string.IsNullOrWhiteSpace(newText))
                {
                    transcribedText.Text += $"{newText}\n";
                    scroll.ScrollToAsync(0, scroll.Height, true);
                }
            });
            
        }

        void InsertDateTimeRecord()
        {
            var msg = $"=================\n{DateTime.Now.ToString()}\n=================";
            UpdateTranscription(msg);
        }

        void UpdateButton()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if(isTranscribing)
                {
                    transcribeButton.Text = "Stop";
                    transcribeButton.BackgroundColor = Color.Red;
                }
                else
                {
                    transcribeButton.Text = "Transcribe";
                    transcribeButton.BackgroundColor = Color.Green;
                }
            });
        }
    }
}
