using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace TodoAzure
{
    public class AuthenticationProvider : IAuthenticate
    {
        public static PublicClientApplication ADB2CClient { get; private set; }

        public static MobileServiceUser User { get; private set; }

        public AuthenticationProvider()
        {
            ADB2CClient = new PublicClientApplication(Constants.ClientId, Constants.AuthoritySignin);
        }

        public async Task<bool> LoginAsync(bool useSilent = false)
        {
            bool success = false;
            try
            {
                AuthenticationResult authenticationResult;
                IEnumerable<IAccount> accounts = await ADB2CClient.GetAccountsAsync();

                if (useSilent)
                {
                    authenticationResult = await ADB2CClient.AcquireTokenSilentAsync(
                        Constants.Scopes,
                        accounts.FirstOrDefault());
                }
                else
                {
                    authenticationResult = await ADB2CClient.AcquireTokenAsync(
                        Constants.Scopes,
                        string.Empty,
                        UIBehavior.SelectAccount,
                        string.Empty,
                        App.UiParent);
                }

                if (User == null)
                {
                    var payload = new JObject();
                    if (authenticationResult != null && !string.IsNullOrWhiteSpace(authenticationResult.IdToken))
                    {
                        payload["access_token"] = authenticationResult.IdToken;
                    }

                    User = await TodoItemManager.DefaultManager.CurrentClient.LoginAsync(
                        MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory,
                        payload);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }

        public async Task<bool> LogoutAsync()
        {
            bool success = false;
            try
            {
                IEnumerable<IAccount> accounts = await ADB2CClient.GetAccountsAsync();

                while(accounts.Any())
                {
                    await ADB2CClient.RemoveAsync(accounts.First());
                    accounts = await ADB2CClient.GetAccountsAsync();
                }

                User = null;

                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
    }
}

