using Contact_Book_with_SQLite.Classes;

using SQLite;

using System;
using System.IO;

using Xamarin.Forms;

[assembly: Dependency(typeof(Contact_Book_with_SQLite.iOS.Classes.SQLiteBDD))]

namespace Contact_Book_with_SQLite.iOS.Classes
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