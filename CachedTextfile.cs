using SQLite;

namespace ThemModdingHerds.Resource;
[Table("cached_textfile")]
public class CachedTextfile
{
    [PrimaryKey, AutoIncrement, Column("hiberlite_id")]
    public int HiberliteId {get; set;}
    [Column("shortname")]
    public string ShortName {get; set;} = "";
    [Column("source_file")]
    public string SourceFile {get; set;} = "";
    [Column("text_data")]
    public byte[] TextData {get; set;} = [];
}