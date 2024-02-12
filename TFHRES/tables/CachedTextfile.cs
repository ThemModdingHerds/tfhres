using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class CachedTextfile
{
    public const string TABLE_NAME = "cached_textfile";
    public long HiberliteId {get; set;}
    public string Shortname {get; set;} = string.Empty;
    public string SourceFile {get; set;} = string.Empty;
    public byte[] TextData {get; set;} = [];
}
public static class CachedTextfileExt
{
    public static void Insert(this Database database,CachedTextfile cached_textfile)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {CachedTextfile.TABLE_NAME} (shortname,source_file,text_data) VALUES ($shortname,$source_file,$text_data);";
        cmd.Parameters.AddWithValue("$shortname",cached_textfile.Shortname);
        cmd.Parameters.AddWithValue("$source_file",cached_textfile.SourceFile);
        cmd.Parameters.AddWithValue("$text_data",cached_textfile.TextData);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<CachedTextfile> items)
    {
        foreach(CachedTextfile cached_textfile in items)
            Insert(database,cached_textfile);
    }
    public static void Update(this Database database,CachedTextfile cached_textfile)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {CachedTextfile.TABLE_NAME} SET shortname = $shortname, source_file = $source_file, text_data = $text_data WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",cached_textfile.HiberliteId);
        cmd.Parameters.AddWithValue("$shortname",cached_textfile.Shortname);
        cmd.Parameters.AddWithValue("$source_file",cached_textfile.SourceFile);
        cmd.Parameters.AddWithValue("$text_data",cached_textfile.TextData);
        cmd.ExecuteNonQuery();
    }
    public static List<CachedTextfile> ReadCachedTextfile(this Database database)
    {
        List<CachedTextfile> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {CachedTextfile.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new CachedTextfile()
                {
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Shortname = reader.GetText("shortname"),
                    SourceFile = reader.GetText("source_file"),
                    TextData = reader.GetBlob("text_data")
                }
            );
        }
        return items;
    }
}