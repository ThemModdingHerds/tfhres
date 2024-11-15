// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class TmxMapInstanceLayersItemsItemAnimationsItems
{
    public const string TABLE_NAME = "tmx_map_instance_layers_items_item_animations_items";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE tmx_map_instance_layers_items_item_animations_items (hiberlite_entry_indx INTEGER, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, hiberlite_parent_id INTEGER, item_max_frames INTEGER, item_munged_frames BLOB, item_starting_vertex INTEGER, item_ticks_per_frame INTEGER)";
    [JsonPropertyName("hiberlite_entry_indx")]
    public long HiberliteEntryIndx {get; set;}
    [JsonPropertyName("hiberlite_id")]
    public long HiberliteId {get; set;}
    [JsonPropertyName("hiberlite_parent_id")]
    public long HiberliteParentId {get; set;}
    [JsonPropertyName("item_max_frames")]
    public long ItemMaxFrames {get; set;}
    [JsonPropertyName("item_munged_frames")]
    public byte[] ItemMungedFrames {get; set;} = [];
    [JsonPropertyName("item_starting_vertex")]
    public long ItemStartingVertex {get; set;}
    [JsonPropertyName("item_ticks_per_frame")]
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
    public static void ForceInsert(this Database database,TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {TmxMapInstanceLayersItemsItemAnimationsItems.TABLE_NAME} (hiberlite_entry_indx,hiberlite_id,hiberlite_parent_id,item_max_frames,item_munged_frames,item_starting_vertex,item_ticks_per_frame) VALUES ($hiberlite_entry_indx,$hiberlite_id,$hiberlite_parent_id,$item_max_frames,$item_munged_frames,$item_starting_vertex,$item_ticks_per_frame);";
        cmd.Parameters.AddWithValue("$hiberlite_entry_indx",tmx_map_instance_layers_items_item_animations_items.HiberliteEntryIndx);
        cmd.Parameters.AddWithValue("$hiberlite_id",tmx_map_instance_layers_items_item_animations_items.HiberliteId);
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
    public static void ForceInsert(this Database database,IEnumerable<TmxMapInstanceLayersItemsItemAnimationsItems> items)
    {
        foreach(TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items in items)
            ForceInsert(database,tmx_map_instance_layers_items_item_animations_items);
    }
    public static void Upsert(this Database database,TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items)
    {
        if(ExistsTmxMapInstanceLayersItemsItemAnimationsItems(database,tmx_map_instance_layers_items_item_animations_items.HiberliteId))
        {
            Update(database,tmx_map_instance_layers_items_item_animations_items);
            return;
        }
        Insert(database,tmx_map_instance_layers_items_item_animations_items);
    }
    public static void Upsert(this Database database,IEnumerable<TmxMapInstanceLayersItemsItemAnimationsItems> items)
    {
        foreach(TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items in items)
            Upsert(database,tmx_map_instance_layers_items_item_animations_items);
    }
    public static void Delsert(this Database database,TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items)
    {
        if(ExistsTmxMapInstanceLayersItemsItemAnimationsItems(database,tmx_map_instance_layers_items_item_animations_items.HiberliteId))
        {
            DeleteTmxMapInstanceLayersItemsItemAnimationsItems(database,tmx_map_instance_layers_items_item_animations_items.HiberliteId);
            return;
        }
        ForceInsert(database,tmx_map_instance_layers_items_item_animations_items);
    }
    public static void Delsert(this Database database,IEnumerable<TmxMapInstanceLayersItemsItemAnimationsItems> items)
    {
        foreach(TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items in items)
            Delsert(database,tmx_map_instance_layers_items_item_animations_items);
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
    public static void Update(this Database database,IEnumerable<TmxMapInstanceLayersItemsItemAnimationsItems> items)
    {
        foreach(TmxMapInstanceLayersItemsItemAnimationsItems item in items)
            Update(database,item);
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
                    ItemMungedFrames = reader.GetBlob("item_munged_frames"),
                    ItemStartingVertex = reader.GetInteger("item_starting_vertex"),
                    ItemTicksPerFrame = reader.GetInteger("item_ticks_per_frame")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static TmxMapInstanceLayersItemsItemAnimationsItems? ReadTmxMapInstanceLayersItemsItemAnimationsItems(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {TmxMapInstanceLayersItemsItemAnimationsItems.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new TmxMapInstanceLayersItemsItemAnimationsItems()
            {
                HiberliteEntryIndx = reader.GetInteger("hiberlite_entry_indx"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                HiberliteParentId = reader.GetInteger("hiberlite_parent_id"),
                ItemMaxFrames = reader.GetInteger("item_max_frames"),
                ItemMungedFrames = reader.GetBlob("item_munged_frames"),
                ItemStartingVertex = reader.GetInteger("item_starting_vertex"),
                ItemTicksPerFrame = reader.GetInteger("item_ticks_per_frame")
            };
        return null;
    }
    public static bool ExistsTmxMapInstanceLayersItemsItemAnimationsItems(this Database database,long hiberlite_id)
    {
        return ReadTmxMapInstanceLayersItemsItemAnimationsItems(database,hiberlite_id) != null;
    }
    public static bool ExistsTmxMapInstanceLayersItemsItemAnimationsItems(this Database database,TmxMapInstanceLayersItemsItemAnimationsItems tmx_map_instance_layers_items_item_animations_items)
    {
        return ExistsTmxMapInstanceLayersItemsItemAnimationsItems(database,tmx_map_instance_layers_items_item_animations_items.HiberliteId);
    }
    public static void DeleteTmxMapInstanceLayersItemsItemAnimationsItems(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {TmxMapInstanceLayersItemsItemAnimationsItems.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteTmxMapInstanceLayersItemsItemAnimationsItems(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {TmxMapInstanceLayersItemsItemAnimationsItems.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}