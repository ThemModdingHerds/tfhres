// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class TmxMapInstanceLayersItems
{
    public const string TABLE_NAME = "tmx_map_instance_layers_items";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE tmx_map_instance_layers_items (hiberlite_entry_indx INTEGER, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, hiberlite_parent_id INTEGER, item_depth INTEGER, item_draw_layer INTEGER, item_layer_id INTEGER, item_layer_name TEXT, item_num_verticies INTEGER, item_tileset_image_shortname TEXT, item_vertex_data BLOB)";
    public long HiberliteEntryIndx {get; set;}
    public long HiberliteId {get; set;}
    public long HiberliteParentId {get; set;}
    public long ItemDepth {get; set;}
    public long ItemDrawLayer {get; set;}
    public long ItemLayerId {get; set;}
    public string ItemLayerName {get; set;} = string.Empty;
    public long ItemNumVerticies {get; set;}
    public string ItemTilesetImageShortname {get; set;} = string.Empty;
    public byte[] ItemVertexData {get; set;} = [];
}
public static class TmxMapInstanceLayersItemsExt
{
    public static void Insert(this Database database,TmxMapInstanceLayersItems tmx_map_instance_layers_items)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {TmxMapInstanceLayersItems.TABLE_NAME} (hiberlite_entry_indx,hiberlite_parent_id,item_depth,item_draw_layer,item_layer_id,item_layer_name,item_num_verticies,item_tileset_image_shortname,item_vertex_data) VALUES ($hiberlite_entry_indx,$hiberlite_parent_id,$item_depth,$item_draw_layer,$item_layer_id,$item_layer_name,$item_num_verticies,$item_tileset_image_shortname,$item_vertex_data);";
        cmd.Parameters.AddWithValue("$hiberlite_entry_indx",tmx_map_instance_layers_items.HiberliteEntryIndx);
        cmd.Parameters.AddWithValue("$hiberlite_parent_id",tmx_map_instance_layers_items.HiberliteParentId);
        cmd.Parameters.AddWithValue("$item_depth",tmx_map_instance_layers_items.ItemDepth);
        cmd.Parameters.AddWithValue("$item_draw_layer",tmx_map_instance_layers_items.ItemDrawLayer);
        cmd.Parameters.AddWithValue("$item_layer_id",tmx_map_instance_layers_items.ItemLayerId);
        cmd.Parameters.AddWithValue("$item_layer_name",tmx_map_instance_layers_items.ItemLayerName);
        cmd.Parameters.AddWithValue("$item_num_verticies",tmx_map_instance_layers_items.ItemNumVerticies);
        cmd.Parameters.AddWithValue("$item_tileset_image_shortname",tmx_map_instance_layers_items.ItemTilesetImageShortname);
        cmd.Parameters.AddWithValue("$item_vertex_data",tmx_map_instance_layers_items.ItemVertexData);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<TmxMapInstanceLayersItems> items)
    {
        foreach(TmxMapInstanceLayersItems tmx_map_instance_layers_items in items)
            Insert(database,tmx_map_instance_layers_items);
    }
    public static void Upsert(this Database database,TmxMapInstanceLayersItems tmx_map_instance_layers_items)
    {
        if(ExistsTmxMapInstanceLayersItems(database,tmx_map_instance_layers_items))
        {
            Update(database,tmx_map_instance_layers_items);
            return;
        }
        Insert(database,tmx_map_instance_layers_items);
    }
    public static void Upsert(this Database database,IEnumerable<TmxMapInstanceLayersItems> items)
    {
        foreach(TmxMapInstanceLayersItems tmx_map_instance_layers_items in items)
            Upsert(database,tmx_map_instance_layers_items);
    }
    public static void Update(this Database database,TmxMapInstanceLayersItems tmx_map_instance_layers_items)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {TmxMapInstanceLayersItems.TABLE_NAME} SET hiberlite_entry_indx = $hiberlite_entry_indx, hiberlite_parent_id = $hiberlite_parent_id, item_depth = $item_depth, item_draw_layer = $item_draw_layer, item_layer_id = $item_layer_id, item_layer_name = $item_layer_name, item_num_verticies = $item_num_verticies, item_tileset_image_shortname = $item_tileset_image_shortname, item_vertex_data = $item_vertex_data WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_entry_indx",tmx_map_instance_layers_items.HiberliteEntryIndx);
        cmd.Parameters.AddWithValue("$hiberlite_id",tmx_map_instance_layers_items.HiberliteId);
        cmd.Parameters.AddWithValue("$hiberlite_parent_id",tmx_map_instance_layers_items.HiberliteParentId);
        cmd.Parameters.AddWithValue("$item_depth",tmx_map_instance_layers_items.ItemDepth);
        cmd.Parameters.AddWithValue("$item_draw_layer",tmx_map_instance_layers_items.ItemDrawLayer);
        cmd.Parameters.AddWithValue("$item_layer_id",tmx_map_instance_layers_items.ItemLayerId);
        cmd.Parameters.AddWithValue("$item_layer_name",tmx_map_instance_layers_items.ItemLayerName);
        cmd.Parameters.AddWithValue("$item_num_verticies",tmx_map_instance_layers_items.ItemNumVerticies);
        cmd.Parameters.AddWithValue("$item_tileset_image_shortname",tmx_map_instance_layers_items.ItemTilesetImageShortname);
        cmd.Parameters.AddWithValue("$item_vertex_data",tmx_map_instance_layers_items.ItemVertexData);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<TmxMapInstanceLayersItems> items)
    {
        foreach(TmxMapInstanceLayersItems item in items)
            Update(database,item);
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
                    ItemLayerId = reader.GetInteger("item_layer_id"),
                    ItemLayerName = reader.GetText("item_layer_name"),
                    ItemNumVerticies = reader.GetInteger("item_num_verticies"),
                    ItemTilesetImageShortname = reader.GetText("item_tileset_image_shortname"),
                    ItemVertexData = reader.GetBlob("item_vertex_data")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static TmxMapInstanceLayersItems? ReadTmxMapInstanceLayersItems(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {TmxMapInstanceLayersItems.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new TmxMapInstanceLayersItems()
            {
                HiberliteEntryIndx = reader.GetInteger("hiberlite_entry_indx"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                HiberliteParentId = reader.GetInteger("hiberlite_parent_id"),
                ItemDepth = reader.GetInteger("item_depth"),
                ItemDrawLayer = reader.GetInteger("item_draw_layer"),
                ItemLayerId = reader.GetInteger("item_layer_id"),
                ItemLayerName = reader.GetText("item_layer_name"),
                ItemNumVerticies = reader.GetInteger("item_num_verticies"),
                ItemTilesetImageShortname = reader.GetText("item_tileset_image_shortname"),
                ItemVertexData = reader.GetBlob("item_vertex_data")
            };
        return null;
    }
    public static bool ExistsTmxMapInstanceLayersItems(this Database database,long hiberlite_id)
    {
        return ReadTmxMapInstanceLayersItems(database,hiberlite_id) != null;
    }
    public static bool ExistsTmxMapInstanceLayersItems(this Database database,TmxMapInstanceLayersItems tmx_map_instance_layers_items)
    {
        return ExistsTmxMapInstanceLayersItems(database,tmx_map_instance_layers_items.HiberliteId);
    }
    public static void DeleteTmxMapInstanceLayersItems(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {TmxMapInstanceLayersItems.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteTmxMapInstanceLayersItems(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {TmxMapInstanceLayersItems.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}