using System;
using SQLite;

namespace Todo
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

