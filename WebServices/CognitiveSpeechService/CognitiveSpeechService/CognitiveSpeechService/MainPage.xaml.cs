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

        IAudioSessionService audioService;

        public MainPage()
        {
            InitializeComponent();

            micService = DependencyService.Resolve<IMicrophoneService>();

            // not needed on Android API 26, only IOS
            // https://stackoverflow.com/questions/49979619/xamarin-forms-dependencyservice-not-for-all-platforms
            if (Device.RuntimePlatform == Device.iOS)
            {
                audioService = DependencyService.Resolve<IAudioSessionService>();
            }
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
                    audioService?.ActivateAudioRecordingSession();
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

                        try
                        {
                            isSpeaking = true;

                            // https://social.msdn.microsoft.com/Forums/en-US/e2a927ab-4633-48db-bab6-8a3e3640e198/avaudiosessionnotificationsobserveinterruption-does-not-work-with-google-maps?forum=xamarinforms
                            // let the OS know that you're playing speech so TTS interrupts instead of ducking
                            audioService?.ActivateAudioPlaybackSession();

                            await TextToSpeech.SpeakAsync(TextForTextToSpeechAfterSpeechToText, settings);

                            // set audio session back to recording mode
                            audioService?.ActivateAudioRecordingSession();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error with TTS: {ex.Message}");
                        }
                        finally
                        {
                            isSpeaking = false;
                        }

                        // continue recording
                        await StartSpeechRecognition();
                    }
                    else if (newText.ToLower().Contains("stop"))
                    {
                        Console.WriteLine("Stop voice command detected");
                        await StopSpeechRecognition();
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

        bool isSpeaking;
        async void TextToSpeechWithoutSpeechToText_Clicked_1(System.Object sender, System.EventArgs e)
        {

            if (isSpeaking != true)
            {

                isSpeaking = true;

                // Speak secret phrase 
                string testString = "Foo Bar Baz et al.";
                var settings = new SpeechOptions()
                {
                    Volume = 1.0f,
                };

                try
                {
                    audioService?.ActivateAudioPlaybackSession();
                    await TextToSpeech.SpeakAsync(testString, settings);
                    audioService?.ActivateAudioRecordingSession();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    isSpeaking = false;
                }
            }
        }
    }
}


// when voice command is recognised, need to change from audio 