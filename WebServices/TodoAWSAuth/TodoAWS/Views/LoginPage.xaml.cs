using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Auth;
using Newtonsoft.Json;

namespace TodoAWSSimpleDB
{
	public partial class LoginPage : ContentPage
	{
		Account account;
		AccountStore store;

		public LoginPage()
		{
			InitializeComponent();

			store = AccountStore.Create();
			account = store.FindAccountsForService(Constants.AppName).FirstOrDefault();
		}

		void OnLoginClicked(object sender, EventArgs e)
		{
			var authenticator = new OAuth2Authenticator(
				Constants.ClientId,
				Constants.ClientSecret,
				Constants.Scope,
				new Uri(Constants.AuthorizeUrl),
				new Uri(Constants.RedirectUrl),
				new Uri(Constants.AccessTokenUrl));

			authenticator.Completed += OnAuthCompleted;
			authenticator.Error += OnAuthError;

			var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
			presenter.Login(authenticator);
		}

		async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
		{
			var authenticator = sender as OAuth2Authenticator;

			if (authenticator != null)
			{
				authenticator.Completed -= OnAuthCompleted;
				authenticator.Error -= OnAuthError;
			}

			if (e.IsAuthenticated)
			{
				// If the user is authenticated, request their basic user data from Google
				// UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
				var request = new OAuth2Request("GET", new Uri(Constants.UserInfoUrl), null, e.Account);
				var response = await request.GetResponseAsync();
				if (response != null)
				{
					// Deserialize the data and store it in the account store
					// The users email address will be used to identify data in SimpleDB
					string userJson = await response.GetResponseTextAsync();
					App.User = JsonConvert.DeserializeObject<User>(userJson);
				}

				if (account != null)
				{
					store.Delete(account, Constants.AppName);
				}

				store.Save(account = e.Account, Constants.AppName);
				Navigation.InsertPageBefore(new TodoListPage(), this);
				await Navigation.PopToRootAsync();
			}
		}

		void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
		{
			var authenticator = sender as OAuth2Authenticator;

			if (authenticator != null)
			{
				authenticator.Completed -= OnAuthCompleted;
				authenticator.Error -= OnAuthError;
			}

			Debug.WriteLine("Authentication error: " + e.Message);
		}
	}
}
