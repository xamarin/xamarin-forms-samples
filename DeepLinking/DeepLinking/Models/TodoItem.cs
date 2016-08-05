using SQLite;

namespace DeepLinking
{
	public class TodoItem
	{
		[PrimaryKey]
		public string ID { get; set; }

		public string Name { get; set; }

		public string Notes { get; set; }

		public bool Done { get; set; }
	}
}

