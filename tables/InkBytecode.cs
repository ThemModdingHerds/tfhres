using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("ink_bytecode")]
public class InkBytecode : HiberliteTable
{
    [Column("bytecode")]
    public string Bytecode {get; set;} = "";
    [Column("mapname")]
    public string MapName {get; set;} = "";
    [Column("shortname")]
    public string ShortName {get; set;} = "";
    [Column("source_file")]
    public string SourceFile {get; set;} = "";
}