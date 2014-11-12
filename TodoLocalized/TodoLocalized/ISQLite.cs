using System;
using SQLite.Net;

namespace TodoLocalized
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

