using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("localized_text")]
public class LocalizedText : HiberliteTable
{
    [Column("langcode")]
    public string LanguageCode {get; set;} = "";
    [Column("storyfile_dbname")]
    public string StoryFileDatabaseName {get; set;} = "";
    [Column("tag")]
    public string Tag {get; set;} = "";
    [Column("text")]
    public string Text {get; set;} = "";
}