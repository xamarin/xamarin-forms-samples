using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace TodoAzure
{
	public interface IAuthenticate
	{
		void Initialize(IPlatformParameters parameters);

		Task<bool> LoginAsync(bool useSilent = false);

		Task<bool> LogoutAsync();
	}
}
