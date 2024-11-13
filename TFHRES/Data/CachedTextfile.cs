// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class CachedTextfile
{
    public const string TABLE_NAME = "cached_textfile";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE cached_textfile (hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, shortname TEXT, source_file TEXT, text_data BLOB)";
    [JsonPropertyName("hiberlite_id")]
    public long HiberliteId {get; set;}
    [JsonPropertyName("shortname")]
    public string Shortname {get; set;} = string.Empty;
    [JsonPropertyName("source_file")]
    public string SourceFile {get; set;} = string.Empty;
    [JsonPropertyName("text_data")]
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
    public static void ForceInsert(this Database database,CachedTextfile cached_textfile)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {CachedTextfile.TABLE_NAME} (hiberlite_id,shortname,source_file,text_data) VALUES ($hiberlite_id,$shortname,$source_file,$text_data);";
        cmd.Parameters.AddWithValue("$hiberlite_id",cached_textfile.HiberliteId);
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
    public static void ForceInsert(this Database database,IEnumerable<CachedTextfile> items)
    {
        foreach(CachedTextfile cached_textfile in items)
            ForceInsert(database,cached_textfile);
    }
    public static void Upsert(this Database database,CachedTextfile cached_textfile)
    {
        if(ExistsCachedTextfile(database,cached_textfile.HiberliteId))
        {
            Update(database,cached_textfile);
            return;
        }
        Insert(database,cached_textfile);
    }
    public static void Upsert(this Database database,IEnumerable<CachedTextfile> items)
    {
        foreach(CachedTextfile cached_textfile in items)
            Upsert(database,cached_textfile);
    }
    public static void Delsert(this Database database,CachedTextfile cached_textfile)
    {
        if(ExistsCachedTextfile(database,cached_textfile.HiberliteId))
        {
            DeleteCachedTextfile(database,cached_textfile.HiberliteId);
            return;
        }
        ForceInsert(database,cached_textfile);
    }
    public static void Delsert(this Database database,IEnumerable<CachedTextfile> items)
    {
        foreach(CachedTextfile cached_textfile in items)
            Delsert(database,cached_textfile);
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
    public static void Update(this Database database,IEnumerable<CachedTextfile> items)
    {
        foreach(CachedTextfile item in items)
            Update(database,item);
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
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static CachedTextfile? ReadCachedTextfile(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {CachedTextfile.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new CachedTextfile()
            {
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Shortname = reader.GetText("shortname"),
                SourceFile = reader.GetText("source_file"),
                TextData = reader.GetBlob("text_data")
            };
        return null;
    }
    public static bool ExistsCachedTextfile(this Database database,long hiberlite_id)
    {
        return ReadCachedTextfile(database,hiberlite_id) != null;
    }
    public static bool ExistsCachedTextfile(this Database database,CachedTextfile cached_textfile)
    {
        return ExistsCachedTextfile(database,cached_textfile.HiberliteId);
    }
    public static void DeleteCachedTextfile(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {CachedTextfile.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteCachedTextfile(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {CachedTextfile.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}