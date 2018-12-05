using System;
using SQLite;

namespace Memos.Services.Database
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
