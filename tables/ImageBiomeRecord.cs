using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("image_biome_record")]
public class ImageBiomeRecord : HiberliteTable
{
    [Column("biomename")]
    public string BiomeName {get; set;} = "";
    [Column("image_shortname")]
    public string ImageShortName {get; set;} = "";
}