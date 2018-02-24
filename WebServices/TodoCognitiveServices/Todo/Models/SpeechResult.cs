using System.Collections.Generic;
using Newtonsoft.Json;

namespace Todo
{
    [JsonObject("result")]
    public class SpeechResult
    {
        public string RecognitionStatus { get; set; }
        public string DisplayText { get; set; }
        public long Offset { get; set; }
        public long Duration { get; set; }
    }
}
