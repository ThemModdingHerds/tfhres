using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class TmxMapInstanceLayersItems
{
    public const string TABLE_NAME = "tmx_map_instance_layers_items";
    public long HiberliteEntryIndx {get; set;}
    public long HiberliteId {get; set;}
    public long HiberliteParentId {get; set;}
    public long ItemDepth {get; set;}
    public long ItemDrawLayer {get; set;}
    public string ItemLayerName {get; set;} = string.Empty;
    public long ItemNumVertices {get; set;}
    public string ItemTilesetImageShortname {get; set;} = string.Empty;
    public byte[] ItemVertexData {get; set;} = [];
}
public static class TmxMapInstanceLayersItemsExt
{
    public static void Insert(this Database database,TmxMapInstanceLayersItems tmx_map_instance_layers_items)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {TmxMapInstanceLayersItems.TABLE_NAME} (hiberlite_entry_indx,hiberlite_parent_id,item_depth,item_draw_layer,item_layer_name,item_num_vertices,item_tileset_image_shortname,item_vertex_data) VALUES ($hiberlite_entry_indx,$hiberlite_parent_id,$item_depth,$item_draw_layer,$item_layer_name,$item_num_vertices,$item_tileset_image_shortname,$item_vertex_data);";
        cmd.Parameters.AddWithValue("$hiberlite_entry_indx",tmx_map_instance_layers_items.HiberliteEntryIndx);
        cmd.Parameters.AddWithValue("$hiberlite_parent_id",tmx_map_instance_layers_items.HiberliteParentId);
        cmd.Parameters.AddWithValue("$item_depth",tmx_map_instance_layers_items.ItemDepth);
        cmd.Parameters.AddWithValue("$item_draw_layer",tmx_map_instance_layers_items.ItemDrawLayer);
        cmd.Parameters.AddWithValue("$item_layer_name",tmx_map_instance_layers_items.ItemLayerName);
        cmd.Parameters.AddWithValue("$item_num_vertices",tmx_map_instance_layers_items.ItemNumVertices);
        cmd.Parameters.AddWithValue("$item_tileset_image_shortname",tmx_map_instance_layers_items.ItemTilesetImageShortname);
        cmd.Parameters.AddWithValue("$item_vertex_data",tmx_map_instance_layers_items.ItemVertexData);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<TmxMapInstanceLayersItems> items)
    {
        foreach(TmxMapInstanceLayersItems tmx_map_instance_layers_items in items)
            Insert(database,tmx_map_instance_layers_items);
    }
    public static void Update(this Database database,TmxMapInstanceLayersItems tmx_map_instance_layers_items)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {TmxMapInstanceLayersItems.TABLE_NAME} SET hiberlite_entry_indx = $hiberlite_entry_indx, hiberlite_parent_id = $hiberlite_parent_id, item_depth = $item_depth, item_draw_layer = $item_draw_layer, item_layer_name = $item_layer_name, item_num_vertices = $item_num_vertices, item_tileset_image_shortname = $item_tileset_image_shortname, item_vertex_data = $item_vertex_data WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_entry_indx",tmx_map_instance_layers_items.HiberliteEntryIndx);
        cmd.Parameters.AddWithValue("$hiberlite_id",tmx_map_instance_layers_items.HiberliteId);
        cmd.Parameters.AddWithValue("$hiberlite_parent_id",tmx_map_instance_layers_items.HiberliteParentId);
        cmd.Parameters.AddWithValue("$item_depth",tmx_map_instance_layers_items.ItemDepth);
        cmd.Parameters.AddWithValue("$item_draw_layer",tmx_map_instance_layers_items.ItemDrawLayer);
        cmd.Parameters.AddWithValue("$item_layer_name",tmx_map_instance_layers_items.ItemLayerName);
        cmd.Parameters.AddWithValue("$item_num_vertices",tmx_map_instance_layers_items.ItemNumVertices);
        cmd.Parameters.AddWithValue("$item_tileset_image_shortname",tmx_map_instance_layers_items.ItemTilesetImageShortname);
        cmd.Parameters.AddWithValue("$item_vertex_data",tmx_map_instance_layers_items.ItemVertexData);
        cmd.ExecuteNonQuery();
    }
    public static List<TmxMapInstanceLayersItems> ReadTmxMapInstanceLayersItems(this Database database)
    {
        List<TmxMapInstanceLayersItems> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {TmxMapInstanceLayersItems.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new TmxMapInstanceLayersItems()
                {
                    HiberliteEntryIndx = reader.GetInteger("hiberlite_entry_indx"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    HiberliteParentId = reader.GetInteger("hiberlite_parent_id"),
                    ItemDepth = reader.GetInteger("item_depth"),
                    ItemDrawLayer = reader.GetInteger("item_draw_layer"),
                    ItemLayerName = reader.GetText("item_layer_name"),
                    ItemNumVertices = reader.GetInteger("item_num_vertices"),
                    ItemTilesetImageShortname = reader.GetText("item_tileset_image_shortname"),
                    ItemVertexData = reader.GetBlob("item_vertex_data")
                }
            );
        }
        return items;
    }
}