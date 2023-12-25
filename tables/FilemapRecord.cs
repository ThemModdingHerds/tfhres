using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("filemap_record")]
public class FilemapRecord : HiberliteTable
{
    [Column("shortname")]
    public string ShortName {get; set;} = "";
    [Column("source_path")]
    public string SourcePath {get; set;} = "";
    [Column("type")]
    public string Type {get; set;} = "";
}