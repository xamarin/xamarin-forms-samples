using System.Threading.Tasks;

namespace TodoCognitive
{
	public interface IAuthenticationService
	{
		Task InitializeAsync();
		string GetAccessToken();
	}
}
