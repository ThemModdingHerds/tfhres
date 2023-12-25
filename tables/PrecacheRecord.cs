using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("precache_record")]
public class PrecacheRecord : HiberliteTable
{
    [Column("mapname")]
    public string MapName {get; set;} = "";
    [Column("shortname")]
    public string ShortName {get; set;} = "";
    [Column("type")]
    public string Type {get; set;} = "";
}