using DataAccess.iOS.Persistance;
using DataAccess.Persistance;

using SQLite;

using System;
using System.IO;

using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace DataAccess.iOS.Persistance
{
	public class SQLiteDb : ISQLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MySQLite.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}

