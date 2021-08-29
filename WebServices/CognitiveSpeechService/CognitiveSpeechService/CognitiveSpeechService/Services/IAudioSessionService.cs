using System;

namespace CognitiveSpeechService.Services
{
    public interface IAudioSessionService
    {
        void ActivateAudioPlaybackSession();
        void ActivateAudioRecordingSession();
    }
}
