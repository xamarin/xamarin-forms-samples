using System;
using CognitiveSpeechService.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CognitiveSpeechService.Droid.Services.AndroidAudioSessionService))]
namespace CognitiveSpeechService.Droid.Services
{
    public class AndroidAudioSessionService : IAudioSessionService
    {
        public void ActivateAudioPlaybackSession()
        {

        }

        public void ActivateAudioRecordingSession()
        {

        }
    }
}
