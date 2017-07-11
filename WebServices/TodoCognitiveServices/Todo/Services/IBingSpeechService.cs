using System.Threading.Tasks;

namespace Todo
{
	public interface IBingSpeechService
	{
		Task<SpeechResult> RecognizeSpeechAsync(string filename);
	}
}
