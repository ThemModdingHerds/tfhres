// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class LocalizedText
{
    public const string TABLE_NAME = "localized_text";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE localized_text (hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, langcode TEXT, storyfile_dbname TEXT, tag TEXT, text TEXT)";
    [JsonPropertyName("hiberlite_id")]
    public long HiberliteId {get; set;}
    [JsonPropertyName("langcode")]
    public string Langcode {get; set;} = string.Empty;
    [JsonPropertyName("storyfile_dbname")]
    public string StoryfileDbname {get; set;} = string.Empty;
    [JsonPropertyName("tag")]
    public string Tag {get; set;} = string.Empty;
    [JsonPropertyName("text")]
    public string Text {get; set;} = string.Empty;
}
public static class LocalizedTextExt
{
    public static void Insert(this Database database,LocalizedText localized_text)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {LocalizedText.TABLE_NAME} (langcode,storyfile_dbname,tag,text) VALUES ($langcode,$storyfile_dbname,$tag,$text);";
        cmd.Parameters.AddWithValue("$langcode",localized_text.Langcode);
        cmd.Parameters.AddWithValue("$storyfile_dbname",localized_text.StoryfileDbname);
        cmd.Parameters.AddWithValue("$tag",localized_text.Tag);
        cmd.Parameters.AddWithValue("$text",localized_text.Text);
        cmd.ExecuteNonQuery();
    }
    public static void ForceInsert(this Database database,LocalizedText localized_text)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {LocalizedText.TABLE_NAME} (hiberlite_id,langcode,storyfile_dbname,tag,text) VALUES ($hiberlite_id,$langcode,$storyfile_dbname,$tag,$text);";
        cmd.Parameters.AddWithValue("$hiberlite_id",localized_text.HiberliteId);
        cmd.Parameters.AddWithValue("$langcode",localized_text.Langcode);
        cmd.Parameters.AddWithValue("$storyfile_dbname",localized_text.StoryfileDbname);
        cmd.Parameters.AddWithValue("$tag",localized_text.Tag);
        cmd.Parameters.AddWithValue("$text",localized_text.Text);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<LocalizedText> items)
    {
        foreach(LocalizedText localized_text in items)
            Insert(database,localized_text);
    }
    public static void ForceInsert(this Database database,IEnumerable<LocalizedText> items)
    {
        foreach(LocalizedText localized_text in items)
            ForceInsert(database,localized_text);
    }
    public static void Upsert(this Database database,LocalizedText localized_text)
    {
        if(ExistsLocalizedText(database,localized_text.HiberliteId))
        {
            Update(database,localized_text);
            return;
        }
        Insert(database,localized_text);
    }
    public static void Upsert(this Database database,IEnumerable<LocalizedText> items)
    {
        foreach(LocalizedText localized_text in items)
            Upsert(database,localized_text);
    }
    public static void Delsert(this Database database,LocalizedText localized_text)
    {
        if(ExistsLocalizedText(database,localized_text.HiberliteId))
        {
            DeleteLocalizedText(database,localized_text.HiberliteId);
            return;
        }
        ForceInsert(database,localized_text);
    }
    public static void Delsert(this Database database,IEnumerable<LocalizedText> items)
    {
        foreach(LocalizedText localized_text in items)
            Delsert(database,localized_text);
    }
    public static void Update(this Database database,LocalizedText localized_text)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {LocalizedText.TABLE_NAME} SET langcode = $langcode, storyfile_dbname = $storyfile_dbname, tag = $tag, text = $text WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",localized_text.HiberliteId);
        cmd.Parameters.AddWithValue("$langcode",localized_text.Langcode);
        cmd.Parameters.AddWithValue("$storyfile_dbname",localized_text.StoryfileDbname);
        cmd.Parameters.AddWithValue("$tag",localized_text.Tag);
        cmd.Parameters.AddWithValue("$text",localized_text.Text);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<LocalizedText> items)
    {
        foreach(LocalizedText item in items)
            Update(database,item);
    }
    public static List<LocalizedText> ReadLocalizedText(this Database database)
    {
        List<LocalizedText> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {LocalizedText.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new LocalizedText()
                {
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Langcode = reader.GetText("langcode"),
                    StoryfileDbname = reader.GetText("storyfile_dbname"),
                    Tag = reader.GetText("tag"),
                    Text = reader.GetText("text")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static LocalizedText? ReadLocalizedText(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {LocalizedText.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new LocalizedText()
            {
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Langcode = reader.GetText("langcode"),
                StoryfileDbname = reader.GetText("storyfile_dbname"),
                Tag = reader.GetText("tag"),
                Text = reader.GetText("text")
            };
        return null;
    }
    public static bool ExistsLocalizedText(this Database database,long hiberlite_id)
    {
        return ReadLocalizedText(database,hiberlite_id) != null;
    }
    public static bool ExistsLocalizedText(this Database database,LocalizedText localized_text)
    {
        return ExistsLocalizedText(database,localized_text.HiberliteId);
    }
    public static void DeleteLocalizedText(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {LocalizedText.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteLocalizedText(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {LocalizedText.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}