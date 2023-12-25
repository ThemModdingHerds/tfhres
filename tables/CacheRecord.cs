using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("cache_record")]
public class CacheRecord : HiberliteTable
{
    [Column("shortname")]
    public string ShortName {get; set;} = "";
    [Column("source_path")]
    public string SourcePath {get; set;} = "";
}