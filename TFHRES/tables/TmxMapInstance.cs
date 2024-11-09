// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class TmxMapInstance
{
    public const string TABLE_NAME = "tmx_map_instance";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE tmx_map_instance (flattened_terrain_grid BLOB, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, map_id TEXT, tmx_source_filepath TEXT)";
    public byte[] FlattenedTerrainGrid {get; set;} = [];
    public long HiberliteId {get; set;}
    public string MapId {get; set;} = string.Empty;
    public string TmxSourceFilepath {get; set;} = string.Empty;
}
public static class TmxMapInstanceExt
{
    public static void Insert(this Database database,TmxMapInstance tmx_map_instance)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {TmxMapInstance.TABLE_NAME} (flattened_terrain_grid,map_id,tmx_source_filepath) VALUES ($flattened_terrain_grid,$map_id,$tmx_source_filepath);";
        cmd.Parameters.AddWithValue("$flattened_terrain_grid",tmx_map_instance.FlattenedTerrainGrid);
        cmd.Parameters.AddWithValue("$map_id",tmx_map_instance.MapId);
        cmd.Parameters.AddWithValue("$tmx_source_filepath",tmx_map_instance.TmxSourceFilepath);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<TmxMapInstance> items)
    {
        foreach(TmxMapInstance tmx_map_instance in items)
            Insert(database,tmx_map_instance);
    }
    public static void Upsert(this Database database,TmxMapInstance tmx_map_instance)
    {
        if(ExistsTmxMapInstance(database,tmx_map_instance))
        {
            Update(database,tmx_map_instance);
            return;
        }
        Insert(database,tmx_map_instance);
    }
    public static void Upsert(this Database database,IEnumerable<TmxMapInstance> items)
    {
        foreach(TmxMapInstance tmx_map_instance in items)
            Upsert(database,tmx_map_instance);
    }
    public static void Update(this Database database,TmxMapInstance tmx_map_instance)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {TmxMapInstance.TABLE_NAME} SET flattened_terrain_grid = $flattened_terrain_grid, map_id = $map_id, tmx_source_filepath = $tmx_source_filepath WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$flattened_terrain_grid",tmx_map_instance.FlattenedTerrainGrid);
        cmd.Parameters.AddWithValue("$hiberlite_id",tmx_map_instance.HiberliteId);
        cmd.Parameters.AddWithValue("$map_id",tmx_map_instance.MapId);
        cmd.Parameters.AddWithValue("$tmx_source_filepath",tmx_map_instance.TmxSourceFilepath);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<TmxMapInstance> items)
    {
        foreach(TmxMapInstance item in items)
            Update(database,item);
    }
    public static List<TmxMapInstance> ReadTmxMapInstance(this Database database)
    {
        List<TmxMapInstance> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {TmxMapInstance.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new TmxMapInstance()
                {
                    FlattenedTerrainGrid = reader.GetBlob("flattened_terrain_grid"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    MapId = reader.GetText("map_id"),
                    TmxSourceFilepath = reader.GetText("tmx_source_filepath")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static TmxMapInstance? ReadTmxMapInstance(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {TmxMapInstance.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new TmxMapInstance()
            {
                FlattenedTerrainGrid = reader.GetBlob("flattened_terrain_grid"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                MapId = reader.GetText("map_id"),
                TmxSourceFilepath = reader.GetText("tmx_source_filepath")
            };
        return null;
    }
    public static bool ExistsTmxMapInstance(this Database database,long hiberlite_id)
    {
        return ReadTmxMapInstance(database,hiberlite_id) != null;
    }
    public static bool ExistsTmxMapInstance(this Database database,TmxMapInstance tmx_map_instance)
    {
        return ExistsTmxMapInstance(database,tmx_map_instance.HiberliteId);
    }
    public static void DeleteTmxMapInstance(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {TmxMapInstance.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteTmxMapInstance(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {TmxMapInstance.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}