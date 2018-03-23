using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Todo
{
    public class BingSpellCheckService : IBingSpellCheckService
    {
        HttpClient httpClient;

        public BingSpellCheckService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Constants.BingSpellCheckApiKey);
        }

        public async Task<SpellCheckResult> SpellCheckTextAsync(string text)
        {
            string requestUri = GenerateRequestUri(Constants.BingSpellCheckEndpoint, text, SpellCheckMode.Spell);
            var response = await SendRequestAsync(requestUri);
            var spellCheckResults = JsonConvert.DeserializeObject<SpellCheckResult>(response);
            return spellCheckResults;
        }

        string GenerateRequestUri(string spellCheckEndpoint, string text, SpellCheckMode mode)
        {
            string requestUri = spellCheckEndpoint;
            requestUri += string.Format("?text={0}", WebUtility.UrlEncode(text));   // text to spell check
            requestUri += string.Format("&mode={0}", mode.ToString().ToLower());    // spellcheck mode - proof or spell
            return requestUri;
        }

        async Task<string> SendRequestAsync(string url)
        {
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}

