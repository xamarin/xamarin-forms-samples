using System;
using SQLite;

namespace TodoLocalized
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

