using System.Collections.Generic;
using System.Linq;

namespace Todo.Models
{
    public class EmotionScores
    {
		public float Anger { get; set; }
        public float Contempt { get; set; }
        public float Disgust { get; set; }
        public float Fear { get; set; }
        public float Happiness { get; set; }
        public float Neutral { get; set; }
        public float Sadness { get; set; }
        public float Surprise { get; set; }

		public IEnumerable<KeyValuePair<string, float>> ToRankedList()
		{
			return new Dictionary<string, float>()
			{
				{ "Anger", Anger },
                { "Contempt", Contempt },
                { "Disgust", Disgust },
                { "Fear", Fear },
                { "Happiness", Happiness },
                { "Neutral", Neutral },
                { "Sadness", Sadness },
                { "Surprise", Surprise }
			}
			.OrderByDescending(kv => kv.Value)
			.ThenBy(kv => kv.Key)
			.ToList();
		}
    }
}
