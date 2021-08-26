using CognitiveSpeechService.Services;
using Microsoft.CognitiveServices.Speech;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

            // EARLY OUT: make sure mic is accessible
            if (!isMicEnabled)
            {
                UpdateTranscription("Please grant access to the microphone!");
                return;
            }

            // initialize speech recognizer 
            await StartSpeechRecognition();
        }

        private async Task StartSpeechRecognition()
        {

            if (recognizer == null)
            {
                var config = SpeechConfig.FromSubscription(Constants.CognitiveServicesApiKey, Constants.CognitiveServicesRegion);
                recognizer = new SpeechRecognizer(config);
                recognizer.Recognized += (obj, args) =>
                {
                    UpdateTranscription(args.Result.Text);
                };
            }

            // if already transcribing, stop speech recognizer
            if (isTranscribing)
            {
                await StopSpeechRecognition();
            }

            // if not transcribing, start speech recognizer
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    InsertDateTimeRecord();
                });
                try
                {
                    await recognizer.StartContinuousRecognitionAsync();
                }
                catch (Exception ex)
                {
                    UpdateTranscription(ex.Message);
                }
                isTranscribing = true;
            }
            UpdateDisplayState();
        }

        private async Task StopSpeechRecognition()
        {
            if (recognizer != null)
            {
                try
                {
                    await recognizer.StopContinuousRecognitionAsync();
                }
                catch (Exception ex)
                {
                    UpdateTranscription(ex.Message);
                }
                isTranscribing = false;
                UpdateDisplayState();
            }
        }

        private void UpdateTranscription(string newText)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (!string.IsNullOrWhiteSpace(newText))
                {
                    if (newText.ToLower().Contains("secret phrase"))
                    {
                        Console.WriteLine("secret phrase detected");

                        // stop speech recognition
                        await StopSpeechRecognition();

                        // Speak secret phrase 
                        string TextForTextToSpeechAfterSpeechToText = "Foo Bar Baz et al.";
                        var settings = new SpeechOptions()
                        {
                            Volume = 1.0f,
                        };
                        await TextToSpeech.SpeakAsync(TextForTextToSpeechAfterSpeechToText, settings);

                        // continue recording 
                        await StartSpeechRecognition();

                    }
                    else
                    {
                        transcribedText.Text += $"{newText}\n";
                    }
                }
            });
        }

        void InsertDateTimeRecord()
        {
            var msg = $"=================\n{DateTime.Now.ToString()}\n=================";
            UpdateTranscription(msg);
        }

        void UpdateDisplayState()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (isTranscribing)
                {
                    transcribeButton.Text = "Stop";
                    transcribeButton.BackgroundColor = Color.Red;
                    transcribingIndicator.IsRunning = true;
                }
                else
                {
                    transcribeButton.Text = "Transcribe";
                    transcribeButton.BackgroundColor = Color.Green;
                    transcribingIndicator.IsRunning = false;
                }
            });
        }

        private async void TextToSpeechWithoutSpeechToText_Clicked(System.Object sender, System.EventArgs e)
        {
            // Speak secret phrase 
            string testString = "Foo Bar Baz et al.";
            var settings = new SpeechOptions()
            {
                Volume = 1.0f,
            };
            await TextToSpeech.SpeakAsync(testString, settings);
        }
    }
}
