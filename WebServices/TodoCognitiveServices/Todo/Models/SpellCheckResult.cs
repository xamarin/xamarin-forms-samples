using System.Collections.Generic;
using Newtonsoft.Json;

namespace Todo
{
	public class SpellCheckSuggestion
	{
		public string Suggestion { get; set; }
		public double Score { get; set; }
	}

	public class FlaggedToken
	{
		public int Offset { get; set; }
		public string Token { get; set; }
		public string Type { get; set; }
		public IList<SpellCheckSuggestion> Suggestions { get; set; }
	}

	public class SpellCheckResult
	{
		[JsonProperty("_type")]
		public string Type { get; set; }
		public IList<FlaggedToken> FlaggedTokens { get; set; }
	}
}
