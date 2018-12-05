using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Memos.Droid.Database;
using Memos.Services.Database;

[assembly: Dependency(typeof(SQLiteDbDroid))]
namespace Memos.Droid.Database
{
    public class SQLiteDbDroid: ISQLiteDb
    {
       public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "YourDocName.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
