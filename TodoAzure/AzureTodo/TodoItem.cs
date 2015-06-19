using System;
using Newtonsoft.Json;

namespace AzureTodo
{
	public class TodoItem
	{
		string id;
		string name;
		string notes;
		bool done;

		[JsonProperty(PropertyName = "id")]
		public string ID
		{
			get { return id; }
			set { id = value;}
		}

		[JsonProperty(PropertyName = "text")]
		public string Name
		{
			get { return name; }
			set { name = value;}
		}

		[JsonProperty(PropertyName = "notes")]
		public string Notes
		{
			get { return notes; }
			set { notes = value;}
		}

		[JsonProperty(PropertyName = "complete")]
		public bool Done
		{
			get { return done; }
			set { done = value;}
		}

	}
}

