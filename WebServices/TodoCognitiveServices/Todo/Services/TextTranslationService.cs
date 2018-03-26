using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Todo
{
    public class TextTranslationService : ITextTranslationService
    {
        IAuthenticationService authenticationService;
        HttpClient httpClient;

        public TextTranslationService(IAuthenticationService authService)
        {
            authenticationService = authService;
        }

        public async Task<string> TranslateTextAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(authenticationService.GetAccessToken()))
            {
                await authenticationService.InitializeAsync();
            }

            string requestUri = GenerateRequestUri(Constants.TextTranslatorEndpoint, text, "en", "de");
            string accessToken = authenticationService.GetAccessToken();
            var response = await SendRequestAsync(requestUri, accessToken);
            var xml = XDocument.Parse(response);
            return xml.Root.Value;
        }

        string GenerateRequestUri(string endpoint, string text, string from, string to)
        {
            string requestUri = endpoint;
            requestUri += string.Format("?text={0}", Uri.EscapeUriString(text));
            requestUri += string.Format("&from={0}", from);
            requestUri += string.Format("&to={0}", to);
            return requestUri;
        }

        async Task<string> SendRequestAsync(string url, string bearerToken)
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
