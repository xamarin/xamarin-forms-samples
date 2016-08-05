using SQLite;

namespace DeepLinking
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection ();
	}
}

