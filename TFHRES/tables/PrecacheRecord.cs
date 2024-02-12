using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class PrecacheRecord
{
    public const string TABLE_NAME = "precache_record";
    public long HiberliteId {get; set;}
    public string Mapname {get; set;} = string.Empty;
    public string Shortname {get; set;} = string.Empty;
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
    public static void Insert(this Database database,IEnumerable<PrecacheRecord> items)
    {
        foreach(PrecacheRecord precache_record in items)
            Insert(database,precache_record);
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
        return items;
    }
}