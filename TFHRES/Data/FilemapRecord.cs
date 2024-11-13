// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class FilemapRecord
{
    public const string TABLE_NAME = "filemap_record";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE filemap_record (hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, shortname TEXT, source_path TEXT, type TEXT)";
    [JsonPropertyName("hiberlite_id")]
    public long HiberliteId {get; set;}
    [JsonPropertyName("shortname")]
    public string Shortname {get; set;} = string.Empty;
    [JsonPropertyName("source_path")]
    public string SourcePath {get; set;} = string.Empty;
    [JsonPropertyName("type")]
    public string Type {get; set;} = string.Empty;
}
public static class FilemapRecordExt
{
    public static void Insert(this Database database,FilemapRecord filemap_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {FilemapRecord.TABLE_NAME} (shortname,source_path,type) VALUES ($shortname,$source_path,$type);";
        cmd.Parameters.AddWithValue("$shortname",filemap_record.Shortname);
        cmd.Parameters.AddWithValue("$source_path",filemap_record.SourcePath);
        cmd.Parameters.AddWithValue("$type",filemap_record.Type);
        cmd.ExecuteNonQuery();
    }
    public static void ForceInsert(this Database database,FilemapRecord filemap_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {FilemapRecord.TABLE_NAME} (hiberlite_id,shortname,source_path,type) VALUES ($hiberlite_id,$shortname,$source_path,$type);";
        cmd.Parameters.AddWithValue("$hiberlite_id",filemap_record.HiberliteId);
        cmd.Parameters.AddWithValue("$shortname",filemap_record.Shortname);
        cmd.Parameters.AddWithValue("$source_path",filemap_record.SourcePath);
        cmd.Parameters.AddWithValue("$type",filemap_record.Type);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<FilemapRecord> items)
    {
        foreach(FilemapRecord filemap_record in items)
            Insert(database,filemap_record);
    }
    public static void ForceInsert(this Database database,IEnumerable<FilemapRecord> items)
    {
        foreach(FilemapRecord filemap_record in items)
            ForceInsert(database,filemap_record);
    }
    public static void Upsert(this Database database,FilemapRecord filemap_record)
    {
        if(ExistsFilemapRecord(database,filemap_record.HiberliteId))
        {
            Update(database,filemap_record);
            return;
        }
        Insert(database,filemap_record);
    }
    public static void Upsert(this Database database,IEnumerable<FilemapRecord> items)
    {
        foreach(FilemapRecord filemap_record in items)
            Upsert(database,filemap_record);
    }
    public static void Delsert(this Database database,FilemapRecord filemap_record)
    {
        if(ExistsFilemapRecord(database,filemap_record.HiberliteId))
        {
            DeleteFilemapRecord(database,filemap_record.HiberliteId);
            return;
        }
        ForceInsert(database,filemap_record);
    }
    public static void Delsert(this Database database,IEnumerable<FilemapRecord> items)
    {
        foreach(FilemapRecord filemap_record in items)
            Delsert(database,filemap_record);
    }
    public static void Update(this Database database,FilemapRecord filemap_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {FilemapRecord.TABLE_NAME} SET shortname = $shortname, source_path = $source_path, type = $type WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",filemap_record.HiberliteId);
        cmd.Parameters.AddWithValue("$shortname",filemap_record.Shortname);
        cmd.Parameters.AddWithValue("$source_path",filemap_record.SourcePath);
        cmd.Parameters.AddWithValue("$type",filemap_record.Type);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<FilemapRecord> items)
    {
        foreach(FilemapRecord item in items)
            Update(database,item);
    }
    public static List<FilemapRecord> ReadFilemapRecord(this Database database)
    {
        List<FilemapRecord> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {FilemapRecord.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new FilemapRecord()
                {
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Shortname = reader.GetText("shortname"),
                    SourcePath = reader.GetText("source_path"),
                    Type = reader.GetText("type")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static FilemapRecord? ReadFilemapRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {FilemapRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new FilemapRecord()
            {
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Shortname = reader.GetText("shortname"),
                SourcePath = reader.GetText("source_path"),
                Type = reader.GetText("type")
            };
        return null;
    }
    public static bool ExistsFilemapRecord(this Database database,long hiberlite_id)
    {
        return ReadFilemapRecord(database,hiberlite_id) != null;
    }
    public static bool ExistsFilemapRecord(this Database database,FilemapRecord filemap_record)
    {
        return ExistsFilemapRecord(database,filemap_record.HiberliteId);
    }
    public static void DeleteFilemapRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {FilemapRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteFilemapRecord(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {FilemapRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}