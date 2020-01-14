using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveSpeechService
{
    public static class Constants
    {
        // API key can be a shared, multi-resource key or an individual service key
        // and can be found and regenerated in the Azure portal
        public string CognitiveServicesApiKey = "< Enter API Key Here >";

        // Endpoint is based on your configured region and should be similar to: https://westus.api.cognitive.microsoft.com/
        public string CognitiveServicesEndpoint = "< Enter Endpoint Here >";
    }
}
