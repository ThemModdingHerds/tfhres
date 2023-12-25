using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("cached_textfile")]
public class CachedTextfile : HiberliteTable
{
    [Column("shortname")]
    public string ShortName {get; set;} = "";
    [Column("source_file")]
    public string SourceFile {get; set;} = "";
    [Column("text_data")]
    public byte[] TextData {get; set;} = [];
}