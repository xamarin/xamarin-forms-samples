using Newtonsoft.Json;

namespace TodoCognitive
{
    [JsonObject("result")]
    public class SpeechResult
    {
        public string RecognitionStatus { get; set; }
        public string DisplayText { get; set; }
        public string Offset { get; set; }
        public string Duration { get; set; }
    }
}
