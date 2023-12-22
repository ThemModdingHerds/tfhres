using SQLite;

namespace ThemModdingHerds.Resource;

public class CachedImage
{
    [Column("height")]
    public int Height {get; set;}
    [PrimaryKey, AutoIncrement, Column("hiberlite_id")]
    public int HiberliteId {get; set;}
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
