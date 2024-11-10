// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class MapBiomeRecord
{
    public const string TABLE_NAME = "map_biome_record";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE map_biome_record (biomename TEXT, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, map_shortname TEXT)";
    public string Biomename {get; set;} = string.Empty;
    public long HiberliteId {get; set;}
    public string MapShortname {get; set;} = string.Empty;
}
public static class MapBiomeRecordExt
{
    public static void Insert(this Database database,MapBiomeRecord map_biome_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {MapBiomeRecord.TABLE_NAME} (biomename,map_shortname) VALUES ($biomename,$map_shortname);";
        cmd.Parameters.AddWithValue("$biomename",map_biome_record.Biomename);
        cmd.Parameters.AddWithValue("$map_shortname",map_biome_record.MapShortname);
        cmd.ExecuteNonQuery();
    }
    public static void ForceInsert(this Database database,MapBiomeRecord map_biome_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {MapBiomeRecord.TABLE_NAME} (biomename,hiberlite_id,map_shortname) VALUES ($biomename,$hiberlite_id,$map_shortname);";
        cmd.Parameters.AddWithValue("$biomename",map_biome_record.Biomename);
        cmd.Parameters.AddWithValue("$hiberlite_id",map_biome_record.HiberliteId);
        cmd.Parameters.AddWithValue("$map_shortname",map_biome_record.MapShortname);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<MapBiomeRecord> items)
    {
        foreach(MapBiomeRecord map_biome_record in items)
            Insert(database,map_biome_record);
    }
    public static void ForceInsert(this Database database,IEnumerable<MapBiomeRecord> items)
    {
        foreach(MapBiomeRecord map_biome_record in items)
            ForceInsert(database,map_biome_record);
    }
    public static void Upsert(this Database database,MapBiomeRecord map_biome_record)
    {
        if(ExistsMapBiomeRecord(database,map_biome_record.HiberliteId))
        {
            Update(database,map_biome_record);
            return;
        }
        Insert(database,map_biome_record);
    }
    public static void Upsert(this Database database,IEnumerable<MapBiomeRecord> items)
    {
        foreach(MapBiomeRecord map_biome_record in items)
            Upsert(database,map_biome_record);
    }
    public static void Delsert(this Database database,MapBiomeRecord map_biome_record)
    {
        if(ExistsMapBiomeRecord(database,map_biome_record.HiberliteId))
        {
            DeleteMapBiomeRecord(database,map_biome_record.HiberliteId);
            return;
        }
        ForceInsert(database,map_biome_record);
    }
    public static void Delsert(this Database database,IEnumerable<MapBiomeRecord> items)
    {
        foreach(MapBiomeRecord map_biome_record in items)
            Delsert(database,map_biome_record);
    }
    public static void Update(this Database database,MapBiomeRecord map_biome_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {MapBiomeRecord.TABLE_NAME} SET biomename = $biomename, map_shortname = $map_shortname WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$biomename",map_biome_record.Biomename);
        cmd.Parameters.AddWithValue("$hiberlite_id",map_biome_record.HiberliteId);
        cmd.Parameters.AddWithValue("$map_shortname",map_biome_record.MapShortname);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<MapBiomeRecord> items)
    {
        foreach(MapBiomeRecord item in items)
            Update(database,item);
    }
    public static List<MapBiomeRecord> ReadMapBiomeRecord(this Database database)
    {
        List<MapBiomeRecord> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {MapBiomeRecord.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new MapBiomeRecord()
                {
                    Biomename = reader.GetText("biomename"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    MapShortname = reader.GetText("map_shortname")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static MapBiomeRecord? ReadMapBiomeRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {MapBiomeRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new MapBiomeRecord()
            {
                Biomename = reader.GetText("biomename"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                MapShortname = reader.GetText("map_shortname")
            };
        return null;
    }
    public static bool ExistsMapBiomeRecord(this Database database,long hiberlite_id)
    {
        return ReadMapBiomeRecord(database,hiberlite_id) != null;
    }
    public static bool ExistsMapBiomeRecord(this Database database,MapBiomeRecord map_biome_record)
    {
        return ExistsMapBiomeRecord(database,map_biome_record.HiberliteId);
    }
    public static void DeleteMapBiomeRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {MapBiomeRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteMapBiomeRecord(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {MapBiomeRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}