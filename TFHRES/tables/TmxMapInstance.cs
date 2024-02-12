using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class TmxMapInstance
{
    public const string TABLE_NAME = "tmx_map_instance";
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
        return items;
    }
}