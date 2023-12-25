using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("varstate")]
public class Varstate : HiberliteTable
{
    [Column("biome")]
    public string Biome {get; set;} = "";
    [Column("name")]
    public string Name {get; set;} = "";
    [Column("notes")]
    public string Notes {get; set;} = "";
    [Column("state")]
    public string State {get; set;} = "";
}