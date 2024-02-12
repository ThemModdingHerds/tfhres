using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class MapBiomeRecord
{
    public const string TABLE_NAME = "map_biome_record";
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
    public static void Insert(this Database database,IEnumerable<MapBiomeRecord> items)
    {
        foreach(MapBiomeRecord map_biome_record in items)
            Insert(database,map_biome_record);
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
        return items;
    }
}