using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("sqlite_sequence")]
public class SQLiteSequence : HiberliteTable
{
    [Column("name")]
    public string Name {get; set;} = "";
    [Column("seq")]
    public string Sequence {get; set;} = "";
}