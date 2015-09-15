using AzureTodo;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using WinPhone81;

[assembly: Xamarin.Forms.Dependency(typeof(MobileClient))]

namespace WinPhone81
{
    public class MobileClient : IMobileClient
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            return await AzureTodo.App.Client.LoginAsync(provider);
        }

        public void Logout()
        {
           AzureTodo.App.Client.Logout();
        }
  
        public static void LoginComplete(WebAuthenticationBrokerContinuationEventArgs args)
        {
            AzureTodo.App.Client.LoginComplete(args);
        }
    }
}
