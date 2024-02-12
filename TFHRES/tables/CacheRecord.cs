using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class CacheRecord
{
    public const string TABLE_NAME = "cache_record";
    public long HiberliteId {get; set;}
    public string Shortname {get; set;} = string.Empty;
    public string SourcePath {get; set;} = string.Empty;
}
public static class CacheRecordExt
{
    public static void Insert(this Database database,CacheRecord cache_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {CacheRecord.TABLE_NAME} (shortname,source_path) VALUES ($shortname,$source_path);";
        cmd.Parameters.AddWithValue("$shortname",cache_record.Shortname);
        cmd.Parameters.AddWithValue("$source_path",cache_record.SourcePath);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<CacheRecord> items)
    {
        foreach(CacheRecord cache_record in items)
            Insert(database,cache_record);
    }
    public static void Update(this Database database,CacheRecord cache_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {CacheRecord.TABLE_NAME} SET shortname = $shortname, source_path = $source_path WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",cache_record.HiberliteId);
        cmd.Parameters.AddWithValue("$shortname",cache_record.Shortname);
        cmd.Parameters.AddWithValue("$source_path",cache_record.SourcePath);
        cmd.ExecuteNonQuery();
    }
    public static List<CacheRecord> ReadCacheRecord(this Database database)
    {
        List<CacheRecord> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {CacheRecord.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new CacheRecord()
                {
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Shortname = reader.GetText("shortname"),
                    SourcePath = reader.GetText("source_path")
                }
            );
        }
        return items;
    }
}