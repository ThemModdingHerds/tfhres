using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class LocalizedText
{
    public const string TABLE_NAME = "localized_text";
    public long HiberliteId {get; set;}
    public string Langcode {get; set;} = string.Empty;
    public string StoryfileDbname {get; set;} = string.Empty;
    public string Tag {get; set;} = string.Empty;
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
    public static void Insert(this Database database,IEnumerable<LocalizedText> items)
    {
        foreach(LocalizedText localized_text in items)
            Insert(database,localized_text);
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
        return items;
    }
}