using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("map_biome_record")]
public class MapBiomeRecord : HiberliteTable
{
    [Column("biomename")]
    public string BiomeName {get; set;} = "";
    [Column("map_shortname")]
    public string MapShortName {get; set;} = "";
}