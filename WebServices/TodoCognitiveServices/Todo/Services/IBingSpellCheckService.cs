using System.Threading.Tasks;

namespace Todo
{
	public interface IBingSpellCheckService
	{
		Task<SpellCheckResult> SpellCheckTextAsync(string text);
	}
}
