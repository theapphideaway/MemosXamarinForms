using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Memos.iOS.Database;
using Memos.Services.Database;

[assembly: Dependency(typeof(SQLiteDbiOS))]
namespace Memos.iOS.Database
{
    public class SQLiteDbiOS : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "YourDocName.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}