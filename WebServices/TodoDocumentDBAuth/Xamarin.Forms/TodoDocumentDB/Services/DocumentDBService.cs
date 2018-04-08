using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace TodoDocumentDB
{
    public class DocumentDBService : IDocumentDBService
    {
        public List<TodoItem> Items { get; private set; }
        public string UserId { get; private set; }

        DocumentClient client;
        Uri collectionLink;

        public DocumentDBService()
        {
            collectionLink = UriFactory.CreateDocumentCollectionUri(Constants.DatabaseName, Constants.CollectionName);
        }

        public async Task<bool> LoginAsync(Xamarin.Forms.Page page)
        {
            string resourceToken = null;
            var tcs = new TaskCompletionSource<bool>();

#if __IOS__
            var controller = UIKit.UIApplication.SharedApplication.KeyWindow.RootViewController;
#endif
            try
            {
                var auth = new Xamarin.Auth.WebRedirectAuthenticator(
                    new Uri(Constants.ResourceTokenBrokerUrl + "/.auth/login/facebook"),
                    new Uri(Constants.ResourceTokenBrokerUrl + "/.auth/login/done"));

                auth.Completed += async (sender, e) =>
                {
                    if (e.IsAuthenticated && e.Account.Properties.ContainsKey("token"))
                    {
#if __IOS__
                        controller.DismissViewController(true, null);
#endif
                        var easyAuthResponseJson = JsonConvert.DeserializeObject<JObject>(e.Account.Properties["token"]);
                        var easyAuthToken = easyAuthResponseJson.GetValue("authenticationToken").ToString();

                        // Call the ResourceBroker to get the DocumentDB resource token
                        using (var httpClient = new HttpClient())
                        {
                            httpClient.DefaultRequestHeaders.Add("x-zumo-auth", easyAuthToken);
                            var response = await httpClient.GetAsync(Constants.ResourceTokenBrokerUrl + "/api/resourcetoken/");
                            var jsonString = await response.Content.ReadAsStringAsync();
                            var tokenJson = JsonConvert.DeserializeObject<JObject>(jsonString);
                            resourceToken = tokenJson.GetValue("token").ToString();
                            UserId = tokenJson.GetValue("userid").ToString();

                            if (!string.IsNullOrWhiteSpace(resourceToken))
                            {
                                client = new DocumentClient(new Uri(Constants.EndpointUri), resourceToken);
                                tcs.SetResult(true);
                            }
                            else
                            {
                                tcs.SetResult(false);
                            }
                        }
                    }
                };

#if __IOS__
                controller.PresentViewController(auth.GetUI(), true, null);
#elif __ANDROID__
                TodoDocumentDB.Droid.MainActivity.Instance.StartActivity(auth.GetUI(TodoDocumentDB.Droid.MainActivity.Instance));
#endif
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: ", ex.Message);
            }

            await tcs.Task;
            return tcs.Task.Result;
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            Items = new List<TodoItem>();

            try
            {
                var query = client.CreateDocumentQuery<TodoItem>(collectionLink,
                                                                new FeedOptions
                                                                {
                                                                    MaxItemCount = -1,
                                                                    PartitionKey = new PartitionKey(UserId)
                                                                })
                                  .Where(item => !item.Id.Contains("permission"))
                                  .AsDocumentQuery();
                while (query.HasMoreResults)
                {
                    Items.AddRange(await query.ExecuteNextAsync<TodoItem>());
                }
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Error: ", ex.Message);
            }

            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
        {
            try
            {
                if (isNewItem)
                {
                    item.UserId = UserId;
                    await client.CreateDocumentAsync(collectionLink, item);
                }
                else
                {
                    await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(Constants.DatabaseName, Constants.CollectionName, item.Id), item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: ", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            try
            {
                await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(Constants.DatabaseName, Constants.CollectionName, id),
                                                 new RequestOptions
                                                 {
                                                     PartitionKey = new PartitionKey(UserId)
                                                 });
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Error: ", ex.Message);
            }
        }
    }
}
