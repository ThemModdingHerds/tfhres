using System.ComponentModel;
using Microsoft.Data.Sqlite;
using ThemModdingHerds.TFHResource.Data;
namespace ThemModdingHerds.TFHResource;
public class Database : IDisposable, ICloneable
{
    public SqliteConnection Connection {get;private set;}
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
        Connection.Close();
    }
    public object Clone()
    {
        return new Database(Connection.Clone());
    }
    public Database Merge(params Database[] databases)
    {
        return DatabaseUtils.Merge([this,..databases]);
    }
    public void Save(string path,bool overwrite = false)
    {
        if(File.Exists(path) && !overwrite)
            throw new IOException($"can't save to {path}, database already exists");
        if(overwrite)
            File.Delete(path);
        SqliteConnection connection = new($"Data Source={path}");
        Connection.BackupDatabase(connection);
    }
}