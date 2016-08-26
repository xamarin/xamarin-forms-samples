using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace TodoAzure
{
	public class TodoItem
	{
		string id;
		string name;
		bool done;

		[JsonProperty (PropertyName = "id")]
		public string Id {
			get { return id; }
			set { id = value; }
		}

		[JsonProperty (PropertyName = "text")]
		public string Name {
			get { return name; }
			set { name = value; }
		}

		[JsonProperty (PropertyName = "complete")]
		public bool Done {
			get { return done; }
			set { done = value; }
		}

		[Version]
		public string Version { get; set; }
	}
}

