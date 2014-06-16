using System;
using SQLite.Net;

namespace Todo
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

