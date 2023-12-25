using SQLite;
using ThemModdingHerds.TFHResource;
namespace ThemModdingHerds;
public class TFHResourceFile(SQLiteConnection conn)
{
    public string Path {get;} = conn.DatabasePath;
    public SQLiteConnection Connection {get;} = conn;
    public TFHResourceFile(string path) : this(new SQLiteConnection(path))
    {

    }
    public List<T> GetEntries<T>() where T : new()
    {
        return [.. Connection.Table<T>()];
    }
    public TFHResourceFile Update<T>(int key,T item) where T : HiberliteTable
    {
        item.HiberliteId = key;
        Connection.Update(item);
        return this;
    }
    public TFHResourceFile Insert<T>(T item) where T : HiberliteTable
    {
        Connection.Insert(item);
        return this;
    }
}