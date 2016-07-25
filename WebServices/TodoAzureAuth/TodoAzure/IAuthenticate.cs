using System.Threading.Tasks;

namespace TodoAzure
{
	public interface IAuthenticate
	{
		Task<bool> AuthenticateAsync ();

		Task<bool> LogoutAsync ();
	}
}
