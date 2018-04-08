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
        HttpClient httpClient;

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
            var speechResult = JsonConvert.DeserializeObject<SpeechResult>(response);

            fileStream.Dispose();
            return speechResult;
        }

        string GenerateRequestUri(string speechEndpoint)
        {
            // To build a request URL, you should follow:
            // https://docs.microsoft.com/en-us/azure/cognitive-services/speech/getstarted/getstartedrest
            string requestUri = speechEndpoint;
            requestUri += @"dictation/cognitiveservices/v1?";
            requestUri += @"language=en-us";
            requestUri += @"&format=simple";
            System.Diagnostics.Debug.WriteLine(requestUri.ToString());
            return requestUri;
        }

        async Task<string> SendRequestAsync(Stream fileStream, string url, string bearerToken, string contentType)
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var content = new StreamContent(fileStream);
            content.Headers.TryAddWithoutValidation("Content-Type", contentType);
            var response = await httpClient.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
