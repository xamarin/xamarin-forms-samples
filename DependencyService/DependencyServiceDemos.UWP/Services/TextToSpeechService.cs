using System;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.SpeechSynthesis;

namespace DependencyServiceDemos.UWP
{
    public class TextToSpeechService : ITextToSpeechService, IDisposable
    {
        MediaPlayer mediaPlayer;
        SpeechSynthesizer synthesizer;
        SpeechSynthesisStream stream;
        TaskCompletionSource<bool> tcsUtterance;

        public TextToSpeechService()
        {
            mediaPlayer = new MediaPlayer();
            synthesizer = new SpeechSynthesizer();
        }

        public async Task SpeakAsync(string text)
        {
            tcsUtterance = new TaskCompletionSource<bool>();

            try
            {
                stream = await synthesizer.SynthesizeTextToStreamAsync(text);

                mediaPlayer.MediaEnded += OnMediaPlayerEnded;
                mediaPlayer.Source = MediaSource.CreateFromStream(stream, stream.ContentType);
                mediaPlayer.Play();

                await tcsUtterance.Task;
            }
            catch (Exception ex)
            {
                tcsUtterance.TrySetException(ex);
            }
        }

        void OnMediaPlayerEnded(MediaPlayer sender, object args)
        {
            tcsUtterance.TrySetResult(true);
        }

        public void Dispose()
        {
            stream.Dispose();
            stream = null;
            synthesizer.Dispose();
            synthesizer = null;
            mediaPlayer.MediaEnded -= OnMediaPlayerEnded;
            mediaPlayer.Dispose();
            mediaPlayer = null;
        }
    }
}
