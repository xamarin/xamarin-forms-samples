using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ResourceTokenBroker.Controllers
{
	public class ResourceTokenController : ApiController
	{
		private static DocumentClient _client = null;
		private string databaseId = ConfigurationManager.AppSettings["databaseId"];
		private string collectionId = ConfigurationManager.AppSettings["collectionId"];
		private string permissionId = ConfigurationManager.AppSettings["collectionId"] + "PK"; // needs to be unique per user
		private string hostURL = ConfigurationManager.AppSettings["hostURL"];

		private static DateTime BeginningOfTime = new DateTime(2017, 1, 1);

		public static DocumentClient Client
		{
			get
			{
				if (_client == null)
				{
					_client = new DocumentClient(new System.Uri(ConfigurationManager.AppSettings["accountUrl"]), ConfigurationManager.AppSettings["accountKey"]);
				}
				return _client;
			}
		}

		public ResourceTokenController()
		{
		}

		public async Task<IHttpActionResult> Get()
		{
			string userId = null;

			var token = this.Request.Headers.GetValues("x-zumo-auth").First<string>();
			userId = await GetUserId(token);

			if (userId == null) return this.BadRequest("Request was authorized, but unable to fetch the user ID");

			return await Get(userId);
		}

		private async Task<string> GetUserId(string appserviceToken)
		{
			try
			{
				using (var http = new HttpClient())
				{
					http.DefaultRequestHeaders.Add("x-zumo-auth", appserviceToken);
					var response = await http.GetAsync(hostURL + "/.auth/me");
					string rs = await response.Content.ReadAsStringAsync();
					var rj = JsonConvert.DeserializeObject<JArray>(rs);
					return rj.Children().FirstOrDefault().Children<JProperty>().FirstOrDefault(x => x.Name == "user_id").Value.ToString();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: {0}", ex.ToString());
				return null;
			}
		}

		public async Task<IHttpActionResult> Get(string userId)
		{
			try
			{
				var permissionToken = await GetPermission(userId);
				Console.WriteLine(" returned token " + permissionToken.Token + " with expires " + permissionToken.Expires);
				return Ok(permissionToken);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		private async Task<PermissionToken> GetPermission(string userId)
		{
			PermissionToken permissionToken = null;

			try
			{
				permissionToken = await GetCachedUserPermission(userId);
				if (permissionToken != null) return permissionToken;
			}
			catch (DocumentClientException e)
			{
				if (e.StatusCode != System.Net.HttpStatusCode.NotFound) throw e;
			}

			// Not cached or expired, get a new permission
			permissionToken = await GetNewPermission(userId);

			// Cache it
			await CacheUserPermission(permissionToken);

			return permissionToken;
		}

		private async Task<PermissionToken> GetCachedUserPermission(string userId)
		{
			Document permissionDocument = await Client.ReadDocumentAsync(
					UriFactory.CreateDocumentUri(databaseId, collectionId, userId + "permission"),
					new RequestOptions
					{
						PartitionKey = new PartitionKey(userId)
					});

			int expires = permissionDocument.GetPropertyValue<int>("expires");
			int fiveMinAgo = Convert.ToInt32(DateTime.UtcNow.AddMinutes(-5).Subtract(BeginningOfTime).TotalSeconds);

			if (expires > fiveMinAgo)
			{
				return new PermissionToken()
				{
					Token = permissionDocument.GetPropertyValue<string>("token"),
					Expires = expires,
					UserId = userId
				};
			}

			return null;
		}

		private async Task CacheUserPermission(PermissionToken permissionToken)
		{
			permissionToken.Id = permissionToken.UserId + "permission";
			await Client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId), permissionToken);
		}

		private async Task<PermissionToken> GetNewPermission(string userId)
		{
			Permission permission = null;
			try
			{
				permission = await Client.ReadPermissionAsync(UriFactory.CreatePermissionUri(databaseId, userId, permissionId));
			}
			catch (DocumentClientException e)
			{
				if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					DocumentCollection collection = await Client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId));
					Permission p = new Permission
					{
						PermissionMode = PermissionMode.All,
						ResourceLink = collection.SelfLink,
						ResourcePartitionKey = new PartitionKey(userId),
						Id = permissionId // Needs to be unique for a given user
					};
					await CreateUserIfNotExistsAsync(userId);
					permission = await Client.CreatePermissionAsync(UriFactory.CreateUserUri(databaseId, userId), p);
				}
				else throw e;
			}
			var expires = Convert.ToInt32(DateTime.UtcNow.Subtract(BeginningOfTime).TotalSeconds) + 3600; // expires in 1h
			return new PermissionToken()
			{
				Token = permission.Token,
				Expires = expires,
				UserId = userId
			};
		}

		private async Task CreateUserIfNotExistsAsync(string userId)
		{
			try
			{
				await Client.ReadUserAsync(UriFactory.CreateUserUri(databaseId, userId));
			}
			catch (DocumentClientException e)
			{
				if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					await Client.CreateUserAsync(UriFactory.CreateDatabaseUri(databaseId), new User { Id = userId });
				}
			}
		}
	}

	public class PermissionToken
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }
		[JsonProperty(PropertyName = "token")]
		public string Token { get; set; }
		[JsonProperty(PropertyName = "expires")]
		public int Expires { get; set; }
		[JsonProperty(PropertyName = "userid")]
		public string UserId { get; set; }
	}
}
