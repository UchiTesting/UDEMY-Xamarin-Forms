using SQLite;

namespace DataAccess.Persistance
{
	public interface ISQLiteDB
	{
		SQLiteAsyncConnection GetConnection();
	}
}

