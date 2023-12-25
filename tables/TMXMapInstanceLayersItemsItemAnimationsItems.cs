using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("tmx_map_instance_layers_items_item_animations_items")]
public class TMXMapInstanceLayersItemsItemAnimationsItems : HiberliteTable
{
    [Column("hiberlite_entry_indx")]
    public int HiberliteEntryIndex {get; set;}
    [Column("hiberlite_parent_id")]
    public int HiberliteParentId {get; set;}
    [Column("item_max_frames")]
    public int ItemMaxFrames {get; set;}
    [Column("item_munged_frames")]
    public byte[] ItemMungedFrames {get; set;} = [];
    [Column("item_starting_vertex")]
    public int ItemStartingVertex {get; set;}
    [Column("item_ticks_per_frame")]
    public int ItemTicksPerFrame {get; set;}
}