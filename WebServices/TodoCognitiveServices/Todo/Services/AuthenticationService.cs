using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Todo
{
	public class AuthenticationService : IAuthenticationService
	{
		string subscriptionKey;
		string token;
		Timer accessTokenRenewer;
		const int RefreshTokenDuration = 9;

		public AuthenticationService(string apiKey)
		{
			subscriptionKey = apiKey;
		}

		public async Task InitializeAsync()
		{
			token = await FetchTokenAsync(Constants.AuthenticationTokenEndpoint, subscriptionKey);
			accessTokenRenewer = new Timer(new TimerCallback(OnTokenExpiredCallback), this, TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
		}

		public string GetAccessToken()
		{
			return token;
		}

		async Task RenewAccessToken()
		{
			token = await FetchTokenAsync(Constants.AuthenticationTokenEndpoint, subscriptionKey);
			Debug.WriteLine("Renewed token.");
		}

		async Task OnTokenExpiredCallback(object stateInfo)
		{
			try
			{
				await RenewAccessToken();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(string.Format("Failed to renew access token. Details: {0}", ex.Message));
			}
			finally
			{
				try
				{
					accessTokenRenewer.Change(TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
				}
				catch (Exception ex)
				{
					Debug.WriteLine(string.Format("Failed to reschedule the timer to renew access token. Details: {0}", ex.Message));
				}
			}
		}

		async Task<string> FetchTokenAsync(string fetchUri, string apiKey)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
				UriBuilder uriBuilder = new UriBuilder(fetchUri);
				uriBuilder.Path += "/issueToken";

				var result = await client.PostAsync(uriBuilder.Uri.AbsoluteUri, null);
				return await result.Content.ReadAsStringAsync();
			}
		}
	}
}
