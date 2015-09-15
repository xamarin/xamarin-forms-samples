using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace AzureTodo
{
	public interface IMobileClient
	{
		Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider);
		void Logout();
	}
}
