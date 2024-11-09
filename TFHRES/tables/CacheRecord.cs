// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class CacheRecord
{
    public const string TABLE_NAME = "cache_record";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE cache_record (hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, shortname TEXT, source_path TEXT)";
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
    public static void Upsert(this Database database,CacheRecord cache_record)
    {
        if(ExistsCacheRecord(database,cache_record))
        {
            Update(database,cache_record);
            return;
        }
        Insert(database,cache_record);
    }
    public static void Upsert(this Database database,IEnumerable<CacheRecord> items)
    {
        foreach(CacheRecord cache_record in items)
            Upsert(database,cache_record);
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
    public static void Update(this Database database,IEnumerable<CacheRecord> items)
    {
        foreach(CacheRecord item in items)
            Update(database,item);
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
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static CacheRecord? ReadCacheRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {CacheRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new CacheRecord()
            {
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Shortname = reader.GetText("shortname"),
                SourcePath = reader.GetText("source_path")
            };
        return null;
    }
    public static bool ExistsCacheRecord(this Database database,long hiberlite_id)
    {
        return ReadCacheRecord(database,hiberlite_id) != null;
    }
    public static bool ExistsCacheRecord(this Database database,CacheRecord cache_record)
    {
        return ExistsCacheRecord(database,cache_record.HiberliteId);
    }
    public static void DeleteCacheRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {CacheRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteCacheRecord(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {CacheRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}