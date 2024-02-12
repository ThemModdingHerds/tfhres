using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class Pixelanim
{
    public const string TABLE_NAME = "pixelanim";
    public long Animtype {get; set;}
    public string AtlasShortname {get; set;} = string.Empty;
    public byte[] CompressedFrameHiberliteIds {get; set;} = [];
    public string Shortname {get; set;} = string.Empty;
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
    public static void Insert(this Database database,IEnumerable<Pixelanim> items)
    {
        foreach(Pixelanim pixelanim in items)
            Insert(database,pixelanim);
    }
    public static void Update(this Database database,Pixelanim pixelanim)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {Pixelanim.TABLE_NAME} SET animtype = $animtype, atlas_shortname = $atlas_shortname, compressed_frame_hiberlite_ids = $compressed_frame_hiberlite_ids, shortname = $shortname, ticks_per_frame = $ticks_per_frame WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$animtype",pixelanim.Animtype);
        cmd.Parameters.AddWithValue("$atlas_shortname",pixelanim.AtlasShortname);
        cmd.Parameters.AddWithValue("$compressed_frame_hiberlite_ids",pixelanim.CompressedFrameHiberliteIds);
        cmd.Parameters.AddWithValue("$shortname",pixelanim.Shortname);
        cmd.Parameters.AddWithValue("$ticks_per_frame",pixelanim.TicksPerFrame);
        cmd.ExecuteNonQuery();
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
                    Shortname = reader.GetText("shortname"),
                    TicksPerFrame = reader.GetInteger("ticks_per_frame")
                }
            );
        }
        return items;
    }
}