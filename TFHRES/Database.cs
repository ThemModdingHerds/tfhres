using System.Data;
using Microsoft.Data.Sqlite;
namespace ThemModdingHerds.TFHResource;
public class Database : IDisposable
{
    public SqliteConnection Connection {get;private set;}
    public ConnectionState State {get => Connection.State;}
    public static Database Open(string path)
    {
        SqliteConnection connection = new($"Data Source={path}");
        return new(connection);
    }
    public Database(SqliteConnection connection)
    {
        Connection = connection;
        if(Connection.State != System.Data.ConnectionState.Open)
            Connection.Open();
        DatabaseUtils.CreateTables(Connection);
    }
    public Database(): this(new())
    {

    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Close();
    }
    public void Close()
    {
        Connection.Close();
    }
    public Database Clone()
    {
        Database clone = new();
        DatabaseUtils.ForceInsert(clone,this);
        return clone;
    }
    public void Save(string path,bool overwrite = false)
    {
        if(File.Exists(path) && !overwrite)
            throw new IOException($"can't save to {path}, database already exists");
        SqliteConnection connection = new($"Data Source={path}");
        Connection.BackupDatabase(connection);
    }
}