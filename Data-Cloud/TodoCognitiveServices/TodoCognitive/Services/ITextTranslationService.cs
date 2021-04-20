using System.Threading.Tasks;

namespace TodoCognitive
{
	public interface ITextTranslationService
	{
		Task<string> TranslateTextAsync(string text);
	}
}
