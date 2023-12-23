using SQLite;

namespace ThemModdingHerds.Resource;
public class Database(string path)
{
    public string Path {get;} = path;
    private readonly SQLiteConnection _conn = new(path);
    public List<CacheRecord> GetCacheRecords()
    {
        return [.. _conn.Table<CacheRecord>()];
    }
    public List<CachedImage> GetCachedImages()
    {
        return [.. _conn.Table<CachedImage>()];
    }
    public List<CachedTextfile> GetCachedTextfiles()
    {
        return [.. _conn.Table<CachedTextfile>()];
    }
    public Database Update(int key,CacheRecord record)
    {
        record.HiberliteId = key;
        _conn.Update(record);
        return this;
    }
    public Database Update(int key,CachedImage image)
    {
        image.HiberliteId = key;
        _conn.Update(image);
        return this;
    }
    public Database Update(int key,CachedTextfile textfile)
    {
        textfile.HiberliteId = key;
        _conn.Update(textfile);
        return this;
    }
    public Database Insert(CacheRecord record)
    {
        _conn.Insert(record);
        return this;
    }
    public Database Insert(List<CacheRecord> records)
    {
        foreach(CacheRecord record in records)
            Insert(record);
        return this;
    }
    public Database Insert(CachedImage image)
    {
        _conn.Insert(image);
        return this;
    }
    public Database Insert(List<CachedImage> images)
    {
        foreach(CachedImage image in images)
            Insert(image);
        return this;
    }
    public Database Insert(CachedTextfile textfile)
    {
        _conn.Insert(textfile);
        return this;
    }
    public Database Insert(List<CachedTextfile> textfiles)
    {
        foreach(CachedTextfile textfile in textfiles)
            Insert(textfile);
        return this;
    }
}