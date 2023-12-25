using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("pixelanim")]
public class PixelAnim : HiberliteTable
{
    [Column("animtype")]
    public int AnimationType {get; set;}
    [Column("atlas_shortname")]
    public string AtlasShortName {get; set;} = "";
    [Column("compressed_frame_hiberlite_ids")]
    public byte[] CompressedFrameHiberliteIds {get; set;} = [];
    [Column("shortname")]
    public string ShortName {get; set;} = "";
    [Column("ticks_per_frame")]
    public int TicksPerFrame {get; set;}
}