﻿using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using ContactBook.iOS.Persistence;
using ContactBook.Persistence;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ContactBook.iOS.Persistence
{
    class SQLiteDb : ISQLiteDb
    {
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MySQLite.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}