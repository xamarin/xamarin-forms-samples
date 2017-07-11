using Newtonsoft.Json;

namespace TodoDocumentDB
{
	public class TodoItem
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "notes")]
		public string Notes { get; set; }

		[JsonProperty(PropertyName = "done")]
		public bool Done { get; set; }
	}
}
