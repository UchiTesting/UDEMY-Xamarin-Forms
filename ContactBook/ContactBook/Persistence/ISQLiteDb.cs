using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ContactBook.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
