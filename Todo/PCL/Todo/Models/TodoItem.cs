using System;
using SQLite;

namespace Todo
{
	public class TodoItem
	{
		public TodoItem ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
	}
}

