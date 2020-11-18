using Contact_Book_with_SQLite.Classes;
using Contact_Book_with_SQLite.Droid.Classes;

using SQLite;

using System;
using System.IO;

using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteBDD))]

namespace Contact_Book_with_SQLite.Droid.Classes
{
	public class SQLiteBDD : ISQLiteBDD
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "ContactBookSQLiteDB.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}