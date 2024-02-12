using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class TmxMapInstanceLayersItemsItemAnimationsItems
{
    public const string TABLE_NAME = "tmx_map_instance_layers_items_item_animations_items";
    public long HiberliteEntryIndx {get; set;}
    public long HiberliteId {get; set;}
    public long HiberliteParentId {get; set;}
    public long ItemMaxFrames {get; set;}
    public long ItemMungedFrames {get; set;}
    public long ItemStartingVertex {get; set;}
    public long ItemTicksPerFrame {get; set;}
}
public static class TmxMapInstanceLayersItemsItemAnimationsItemsExt
{
    public static void Insert(this Database database,TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {TmxMapInstanceLayersItemsItemAnimationsItems.TABLE_NAME} (hiberlite_entry_indx,hiberlite_parent_id,item_max_frames,item_munged_frames,item_starting_vertex,item_ticks_per_frame) VALUES ($hiberlite_entry_indx,$hiberlite_parent_id,$item_max_frames,$item_munged_frames,$item_starting_vertex,$item_ticks_per_frame);";
        cmd.Parameters.AddWithValue("$hiberlite_entry_indx",tmx_map_instance_layers_items_item_animations_items.HiberliteEntryIndx);
        cmd.Parameters.AddWithValue("$hiberlite_parent_id",tmx_map_instance_layers_items_item_animations_items.HiberliteParentId);
        cmd.Parameters.AddWithValue("$item_max_frames",tmx_map_instance_layers_items_item_animations_items.ItemMaxFrames);
        cmd.Parameters.AddWithValue("$item_munged_frames",tmx_map_instance_layers_items_item_animations_items.ItemMungedFrames);
        cmd.Parameters.AddWithValue("$item_starting_vertex",tmx_map_instance_layers_items_item_animations_items.ItemStartingVertex);
        cmd.Parameters.AddWithValue("$item_ticks_per_frame",tmx_map_instance_layers_items_item_animations_items.ItemTicksPerFrame);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<TmxMapInstanceLayersItemsItemAnimationsItems> items)
    {
        foreach(TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items in items)
            Insert(database,tmx_map_instance_layers_items_item_animations_items);
    }
    public static void Update(this Database database,TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {TmxMapInstanceLayersItemsItemAnimationsItems.TABLE_NAME} SET hiberlite_entry_indx = $hiberlite_entry_indx, hiberlite_parent_id = $hiberlite_parent_id, item_max_frames = $item_max_frames, item_munged_frames = $item_munged_frames, item_starting_vertex = $item_starting_vertex, item_ticks_per_frame = $item_ticks_per_frame WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_entry_indx",tmx_map_instance_layers_items_item_animations_items.HiberliteEntryIndx);
        cmd.Parameters.AddWithValue("$hiberlite_id",tmx_map_instance_layers_items_item_animations_items.HiberliteId);
        cmd.Parameters.AddWithValue("$hiberlite_parent_id",tmx_map_instance_layers_items_item_animations_items.HiberliteParentId);
        cmd.Parameters.AddWithValue("$item_max_frames",tmx_map_instance_layers_items_item_animations_items.ItemMaxFrames);
        cmd.Parameters.AddWithValue("$item_munged_frames",tmx_map_instance_layers_items_item_animations_items.ItemMungedFrames);
        cmd.Parameters.AddWithValue("$item_starting_vertex",tmx_map_instance_layers_items_item_animations_items.ItemStartingVertex);
        cmd.Parameters.AddWithValue("$item_ticks_per_frame",tmx_map_instance_layers_items_item_animations_items.ItemTicksPerFrame);
        cmd.ExecuteNonQuery();
    }
    public static List<TmxMapInstanceLayersItemsItemAnimationsItems> ReadTmxMapInstanceLayersItemsItemAnimationsItems(this Database database)
    {
        List<TmxMapInstanceLayersItemsItemAnimationsItems> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {TmxMapInstanceLayersItemsItemAnimationsItems.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new TmxMapInstanceLayersItemsItemAnimationsItems()
                {
                    HiberliteEntryIndx = reader.GetInteger("hiberlite_entry_indx"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    HiberliteParentId = reader.GetInteger("hiberlite_parent_id"),
                    ItemMaxFrames = reader.GetInteger("item_max_frames"),
                    ItemMungedFrames = reader.GetInteger("item_munged_frames"),
                    ItemStartingVertex = reader.GetInteger("item_starting_vertex"),
                    ItemTicksPerFrame = reader.GetInteger("item_ticks_per_frame")
                }
            );
        }
        return items;
    }
}