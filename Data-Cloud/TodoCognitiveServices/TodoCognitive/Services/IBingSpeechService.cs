using System.Threading.Tasks;

namespace TodoCognitive
{
	public interface IBingSpeechService
	{
		Task<SpeechResult> RecognizeSpeechAsync(string filename);
	}
}
