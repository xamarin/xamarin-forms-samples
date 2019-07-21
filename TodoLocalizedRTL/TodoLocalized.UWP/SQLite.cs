using SQLite;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(TodoLocalized.UWP.SQLite))]
namespace TodoLocalized.UWP
{
    public class SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var filename = "todo.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
            return new SQLiteConnection(path);
        }
    }
}
