using System.Threading.Tasks;

namespace DependencyServiceDemos
{
    public interface ITextToSpeechService
    {
        Task SpeakAsync(string text);
    }
}
