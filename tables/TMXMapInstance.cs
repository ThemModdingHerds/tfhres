using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("tmx_map_instance")]
public class TMXMapInstance : HiberliteTable
{
    [Column("flattend_terrain_grid")]
    public byte[] FlattendTerrainGrid {get; set;} = [];
    [Column("map_id")]
    public string MapId {get; set;} = "";
    [Column("tmx_source_path")]
    public string TMXSourcePath {get; set;} = "";
}