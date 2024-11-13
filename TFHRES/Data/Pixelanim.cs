// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class Pixelanim
{
    public const string TABLE_NAME = "pixelanim";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE pixelanim (animtype INTEGER, atlas_shortname TEXT, compressed_frame_hiberlite_ids BLOB, hiberlite_id INTEGER, shortname TEXT, ticks_per_frame INTEGER)";
    [JsonPropertyName("animtype")]
    public long Animtype {get; set;}
    [JsonPropertyName("atlas_shortname")]
    public string AtlasShortname {get; set;} = string.Empty;
    [JsonPropertyName("compressed_frame_hiberlite_ids")]
    public byte[] CompressedFrameHiberliteIds {get; set;} = [];
    [JsonPropertyName("hiberlite_id")]
    public long HiberliteId {get; set;}
    [JsonPropertyName("shortname")]
    public string Shortname {get; set;} = string.Empty;
    [JsonPropertyName("ticks_per_frame")]
    public long TicksPerFrame {get; set;}
}
public static class PixelanimExt
{
    public static void Insert(this Database database,Pixelanim pixelanim)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {Pixelanim.TABLE_NAME} (animtype,atlas_shortname,compressed_frame_hiberlite_ids,shortname,ticks_per_frame) VALUES ($animtype,$atlas_shortname,$compressed_frame_hiberlite_ids,$shortname,$ticks_per_frame);";
        cmd.Parameters.AddWithValue("$animtype",pixelanim.Animtype);
        cmd.Parameters.AddWithValue("$atlas_shortname",pixelanim.AtlasShortname);
        cmd.Parameters.AddWithValue("$compressed_frame_hiberlite_ids",pixelanim.CompressedFrameHiberliteIds);
        cmd.Parameters.AddWithValue("$shortname",pixelanim.Shortname);
        cmd.Parameters.AddWithValue("$ticks_per_frame",pixelanim.TicksPerFrame);
        cmd.ExecuteNonQuery();
    }
    public static void ForceInsert(this Database database,Pixelanim pixelanim)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {Pixelanim.TABLE_NAME} (animtype,atlas_shortname,compressed_frame_hiberlite_ids,hiberlite_id,shortname,ticks_per_frame) VALUES ($animtype,$atlas_shortname,$compressed_frame_hiberlite_ids,$hiberlite_id,$shortname,$ticks_per_frame);";
        cmd.Parameters.AddWithValue("$animtype",pixelanim.Animtype);
        cmd.Parameters.AddWithValue("$atlas_shortname",pixelanim.AtlasShortname);
        cmd.Parameters.AddWithValue("$compressed_frame_hiberlite_ids",pixelanim.CompressedFrameHiberliteIds);
        cmd.Parameters.AddWithValue("$hiberlite_id",pixelanim.HiberliteId);
        cmd.Parameters.AddWithValue("$shortname",pixelanim.Shortname);
        cmd.Parameters.AddWithValue("$ticks_per_frame",pixelanim.TicksPerFrame);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<Pixelanim> items)
    {
        foreach(Pixelanim pixelanim in items)
            Insert(database,pixelanim);
    }
    public static void ForceInsert(this Database database,IEnumerable<Pixelanim> items)
    {
        foreach(Pixelanim pixelanim in items)
            ForceInsert(database,pixelanim);
    }
    public static void Upsert(this Database database,Pixelanim pixelanim)
    {
        if(ExistsPixelanim(database,pixelanim.HiberliteId))
        {
            Update(database,pixelanim);
            return;
        }
        Insert(database,pixelanim);
    }
    public static void Upsert(this Database database,IEnumerable<Pixelanim> items)
    {
        foreach(Pixelanim pixelanim in items)
            Upsert(database,pixelanim);
    }
    public static void Delsert(this Database database,Pixelanim pixelanim)
    {
        if(ExistsPixelanim(database,pixelanim.HiberliteId))
        {
            DeletePixelanim(database,pixelanim.HiberliteId);
            return;
        }
        ForceInsert(database,pixelanim);
    }
    public static void Delsert(this Database database,IEnumerable<Pixelanim> items)
    {
        foreach(Pixelanim pixelanim in items)
            Delsert(database,pixelanim);
    }
    public static void Update(this Database database,Pixelanim pixelanim)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {Pixelanim.TABLE_NAME} SET animtype = $animtype, atlas_shortname = $atlas_shortname, compressed_frame_hiberlite_ids = $compressed_frame_hiberlite_ids, shortname = $shortname, ticks_per_frame = $ticks_per_frame WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$animtype",pixelanim.Animtype);
        cmd.Parameters.AddWithValue("$atlas_shortname",pixelanim.AtlasShortname);
        cmd.Parameters.AddWithValue("$compressed_frame_hiberlite_ids",pixelanim.CompressedFrameHiberliteIds);
        cmd.Parameters.AddWithValue("$hiberlite_id",pixelanim.HiberliteId);
        cmd.Parameters.AddWithValue("$shortname",pixelanim.Shortname);
        cmd.Parameters.AddWithValue("$ticks_per_frame",pixelanim.TicksPerFrame);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<Pixelanim> items)
    {
        foreach(Pixelanim item in items)
            Update(database,item);
    }
    public static List<Pixelanim> ReadPixelanim(this Database database)
    {
        List<Pixelanim> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {Pixelanim.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new Pixelanim()
                {
                    Animtype = reader.GetInteger("animtype"),
                    AtlasShortname = reader.GetText("atlas_shortname"),
                    CompressedFrameHiberliteIds = reader.GetBlob("compressed_frame_hiberlite_ids"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Shortname = reader.GetText("shortname"),
                    TicksPerFrame = reader.GetInteger("ticks_per_frame")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static Pixelanim? ReadPixelanim(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {Pixelanim.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new Pixelanim()
            {
                Animtype = reader.GetInteger("animtype"),
                AtlasShortname = reader.GetText("atlas_shortname"),
                CompressedFrameHiberliteIds = reader.GetBlob("compressed_frame_hiberlite_ids"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Shortname = reader.GetText("shortname"),
                TicksPerFrame = reader.GetInteger("ticks_per_frame")
            };
        return null;
    }
    public static bool ExistsPixelanim(this Database database,long hiberlite_id)
    {
        return ReadPixelanim(database,hiberlite_id) != null;
    }
    public static bool ExistsPixelanim(this Database database,Pixelanim pixelanim)
    {
        return ExistsPixelanim(database,pixelanim.HiberliteId);
    }
    public static void DeletePixelanim(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {Pixelanim.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeletePixelanim(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {Pixelanim.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}