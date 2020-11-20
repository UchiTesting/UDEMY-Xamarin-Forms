using ContactBookMVVM.Persistence;

using ContactMVVM.iOS.Persistence;

using SQLite;

using System;
using System.IO;

using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteBDD))]

namespace ContactMVVM.iOS.Persistence
{
	public class SQLiteBDD : ISQLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "ContactBookSQLiteDB.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}