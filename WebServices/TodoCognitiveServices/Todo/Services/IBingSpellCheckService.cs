using System.Threading.Tasks;

namespace TodoCognitive
{
	public interface IBingSpellCheckService
	{
		Task<SpellCheckResult> SpellCheckTextAsync(string text);
	}
}
