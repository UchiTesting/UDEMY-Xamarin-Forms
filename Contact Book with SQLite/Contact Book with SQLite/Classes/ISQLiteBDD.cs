using SQLite;

namespace Contact_Book_with_SQLite.Classes
{
	public interface ISQLiteBDD
	{
		SQLiteAsyncConnection GetConnection();
	}
}
