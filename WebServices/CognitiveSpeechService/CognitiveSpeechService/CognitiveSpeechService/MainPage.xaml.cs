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
        IMicrophoneService microphoneService;

        public MainPage()
        {
            InitializeComponent();

            microphoneService = DependencyService.Resolve<IMicrophoneService>();
        }

        async void EnableMicClicked(object sender, EventArgs e)
        {
            bool isMicEnabled = await microphoneService.GetPermissionAsync();
            if(!isMicEnabled)
            {
                UpdateTranscription("Please grant access to the microphone!", true);
            }
        }

        void StartTranscribingClicked(object sender, EventArgs e)
        {
            var config = SpeechConfig.FromSubscription(Constants.CognitiveServicesApiKey, Constants.CognitiveServicesRegion);

            UpdateTranscription("", true);

            recognizer = new SpeechRecognizer(config);
            recognizer.StartContinuousRecognitionAsync();
            recognizer.Recognized += (obj, args) =>
            {
                UpdateTranscription(args.Result.Text);
            };
        }

        void UpdateTranscription(string newText, bool clearText = false)
        {
            // Force on main thread since this is likely called
            // from a background event
            Device.BeginInvokeOnMainThread(() =>
            {
                if(clearText)
                {
                    transcribedText.Text = "";
                }

                transcribedText.Text += newText;
            });
            
        }
    }
}
