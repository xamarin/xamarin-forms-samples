using System.Threading.Tasks;

namespace Todo
{
	public interface ITextTranslationService
	{
		Task<string> TranslateTextAsync(string text);
	}
}
