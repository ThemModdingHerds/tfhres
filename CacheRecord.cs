using SQLite;

namespace ThemModdingHerds.Resource;
[Table("cache_record")]
public class CacheRecord
{
    [PrimaryKey, AutoIncrement, Column("hiberlite_id")]
    public int HiberliteId {get; set;}
    [Column("shortname")]
    public string ShortName {get; set;} = "";
    [Column("source_path")]
    public string SourcePath {get; set;} = "";
}