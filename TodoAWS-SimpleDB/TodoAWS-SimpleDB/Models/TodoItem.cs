using System;

namespace TodoAWSSimpleDB
{
	public class TodoItem
	{
		//[JsonProperty(PropertyName = "id")]
		public string ID { get; set; }

		//[JsonProperty(PropertyName = "text")]
		public string Name { get; set; }

		//[JsonProperty(PropertyName = "notes")]
		public string Notes { get; set; }

		//[JsonProperty(PropertyName = "complete")]
		public bool Done { get; set; }
	}
}
