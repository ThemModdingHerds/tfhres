using Microsoft.Data.Sqlite;
namespace ThemModdingHerds.TFHResource;
public class Database(SqliteConnection connection)
{
    private readonly SqliteConnection _conn  = connection;
    public SqliteConnection Connection {get => _conn;}
    public string Path {get => _conn.DataSource;}
    public Database(string path): this(new SqliteConnection($"Data Source={path}"))
    {
        
    }
    public void Open()
    {
        _conn.Open();
    }
    public void Close()
    {
        _conn.Close();
    }
}