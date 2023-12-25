using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("cached_image")]
public class CachedImage : HiberliteTable
{
    [Column("height")]
    public int Height {get; set;}
    [Column("image_data")]
    public byte[] ImageData {get; set;} = [];
    [Column("is_compressed")]
    public int IsCompressed {get; set;}
    [Column("shortname")]
    public string ShortName {get; set;} = "";
    [Column("vram_only")]
    public int VramOnly {get; set;}
    [Column("width")]
    public int Width {get; set;}
}
