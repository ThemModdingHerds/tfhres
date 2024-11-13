// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class PrecacheRecord
{
    public const string TABLE_NAME = "precache_record";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE precache_record (hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, mapname TEXT, shortname TEXT, type INTEGER)";
    [JsonPropertyName("hiberlite_id")]
    public long HiberliteId {get; set;}
    [JsonPropertyName("mapname")]
    public string Mapname {get; set;} = string.Empty;
    [JsonPropertyName("shortname")]
    public string Shortname {get; set;} = string.Empty;
    [JsonPropertyName("type")]
    public long Type {get; set;}
}
public static class PrecacheRecordExt
{
    public static void Insert(this Database database,PrecacheRecord precache_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {PrecacheRecord.TABLE_NAME} (mapname,shortname,type) VALUES ($mapname,$shortname,$type);";
        cmd.Parameters.AddWithValue("$mapname",precache_record.Mapname);
        cmd.Parameters.AddWithValue("$shortname",precache_record.Shortname);
        cmd.Parameters.AddWithValue("$type",precache_record.Type);
        cmd.ExecuteNonQuery();
    }
    public static void ForceInsert(this Database database,PrecacheRecord precache_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {PrecacheRecord.TABLE_NAME} (hiberlite_id,mapname,shortname,type) VALUES ($hiberlite_id,$mapname,$shortname,$type);";
        cmd.Parameters.AddWithValue("$hiberlite_id",precache_record.HiberliteId);
        cmd.Parameters.AddWithValue("$mapname",precache_record.Mapname);
        cmd.Parameters.AddWithValue("$shortname",precache_record.Shortname);
        cmd.Parameters.AddWithValue("$type",precache_record.Type);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<PrecacheRecord> items)
    {
        foreach(PrecacheRecord precache_record in items)
            Insert(database,precache_record);
    }
    public static void ForceInsert(this Database database,IEnumerable<PrecacheRecord> items)
    {
        foreach(PrecacheRecord precache_record in items)
            ForceInsert(database,precache_record);
    }
    public static void Upsert(this Database database,PrecacheRecord precache_record)
    {
        if(ExistsPrecacheRecord(database,precache_record.HiberliteId))
        {
            Update(database,precache_record);
            return;
        }
        Insert(database,precache_record);
    }
    public static void Upsert(this Database database,IEnumerable<PrecacheRecord> items)
    {
        foreach(PrecacheRecord precache_record in items)
            Upsert(database,precache_record);
    }
    public static void Delsert(this Database database,PrecacheRecord precache_record)
    {
        if(ExistsPrecacheRecord(database,precache_record.HiberliteId))
        {
            DeletePrecacheRecord(database,precache_record.HiberliteId);
            return;
        }
        ForceInsert(database,precache_record);
    }
    public static void Delsert(this Database database,IEnumerable<PrecacheRecord> items)
    {
        foreach(PrecacheRecord precache_record in items)
            Delsert(database,precache_record);
    }
    public static void Update(this Database database,PrecacheRecord precache_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {PrecacheRecord.TABLE_NAME} SET mapname = $mapname, shortname = $shortname, type = $type WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",precache_record.HiberliteId);
        cmd.Parameters.AddWithValue("$mapname",precache_record.Mapname);
        cmd.Parameters.AddWithValue("$shortname",precache_record.Shortname);
        cmd.Parameters.AddWithValue("$type",precache_record.Type);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<PrecacheRecord> items)
    {
        foreach(PrecacheRecord item in items)
            Update(database,item);
    }
    public static List<PrecacheRecord> ReadPrecacheRecord(this Database database)
    {
        List<PrecacheRecord> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {PrecacheRecord.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new PrecacheRecord()
                {
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Mapname = reader.GetText("mapname"),
                    Shortname = reader.GetText("shortname"),
                    Type = reader.GetInteger("type")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static PrecacheRecord? ReadPrecacheRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {PrecacheRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new PrecacheRecord()
            {
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Mapname = reader.GetText("mapname"),
                Shortname = reader.GetText("shortname"),
                Type = reader.GetInteger("type")
            };
        return null;
    }
    public static bool ExistsPrecacheRecord(this Database database,long hiberlite_id)
    {
        return ReadPrecacheRecord(database,hiberlite_id) != null;
    }
    public static bool ExistsPrecacheRecord(this Database database,PrecacheRecord precache_record)
    {
        return ExistsPrecacheRecord(database,precache_record.HiberliteId);
    }
    public static void DeletePrecacheRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {PrecacheRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeletePrecacheRecord(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {PrecacheRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}