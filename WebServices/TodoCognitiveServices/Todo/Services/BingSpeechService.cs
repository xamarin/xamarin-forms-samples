using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Todo
{
	public class BingSpeechService : IBingSpeechService
	{
		IAuthenticationService authenticationService;
		string operatingSystem;

		public BingSpeechService(IAuthenticationService authService, string os)
		{
			authenticationService = authService;
			operatingSystem = os;
		}

		public async Task<SpeechResult> RecognizeSpeechAsync(string filename)
		{
			if (string.IsNullOrWhiteSpace(authenticationService.GetAccessToken()))
			{
				await authenticationService.InitializeAsync();
			}

			// Read audio file to a stream
			var file = await PCLStorage.FileSystem.Current.LocalStorage.GetFileAsync(filename);
			var fileStream = await file.OpenAsync(PCLStorage.FileAccess.Read);

			// Send audio stream to Bing and deserialize the response
			string requestUri = GenerateRequestUri(Constants.SpeechRecognitionEndpoint);
			string accessToken = authenticationService.GetAccessToken();
			var response = await SendRequestAsync(fileStream, requestUri, accessToken, Constants.AudioContentType);
			var speechResults = JsonConvert.DeserializeObject<SpeechResults>(response);

			fileStream.Dispose();
			return speechResults.results.FirstOrDefault();
		}

		string GenerateRequestUri(string speechEndpoint)
		{
			string requestUri = speechEndpoint;
			requestUri += @"?scenarios=ulm";                                    // websearch is the other option
			requestUri += @"&appid=D4D52672-91D7-4C74-8AD8-42B1D98141A5";       // You must use this ID.
			requestUri += @"&locale=en-US";                                     // Other languages supported.
			requestUri += string.Format("&device.os={0}", operatingSystem);     // Open field
			requestUri += @"&version=3.0";                                      // Required value
			requestUri += @"&format=json";                                      // Required value
			requestUri += @"&instanceid=fe34a4de-7927-4e24-be60-f0629ce1d808";  // GUID for device making the request
			requestUri += @"&requestid=" + Guid.NewGuid().ToString();           // GUID for the request
			return requestUri;
		}

		async Task<string> SendRequestAsync(Stream fileStream, string url, string bearerToken, string contentType)
		{
			var content = new StreamContent(fileStream);
			content.Headers.TryAddWithoutValidation("Content-Type", contentType);

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
				var response = await httpClient.PostAsync(url, content);

				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}
