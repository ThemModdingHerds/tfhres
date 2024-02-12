using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class FilemapRecord
{
    public const string TABLE_NAME = "filemap_record";
    public long HiberliteId {get; set;}
    public string Shortname {get; set;} = string.Empty;
    public string SourcePath {get; set;} = string.Empty;
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
    public static void Insert(this Database database,IEnumerable<FilemapRecord> items)
    {
        foreach(FilemapRecord filemap_record in items)
            Insert(database,filemap_record);
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
        return items;
    }
}