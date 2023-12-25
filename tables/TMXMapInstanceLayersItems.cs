using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("tmx_map_instance_layers_items")]
public class TMXMapInstanceLayersItems : HiberliteTable
{
    [Column("hiberlite_entry_indx")]
    public int HiberliteEntryIndex {get; set;}
    [Column("hiberlite_parent_id")]
    public int HiberliteParentId {get; set;}
    [Column("item_depth")]
    public int ItemDepth {get; set;}
    [Column("item_draw_layer")]
    public int ItemDrawLayer {get; set;}
    [Column("item_layer_id")]
    public string ItemLayerId {get; set;} = "";
    [Column("item_layer:name")]
    public string ItemLayerName {get; set;} = "";
    [Column("item_num_verticies")]
    public int ItemNumVerticies {get; set;}
    [Column("item_tileset_image_shortname")]
    public string ItemTileSetImageShortName {get; set;} = "";
    [Column("item_vertex_data")]
    public byte[] ItemVertexData {get; set;} = [];
}