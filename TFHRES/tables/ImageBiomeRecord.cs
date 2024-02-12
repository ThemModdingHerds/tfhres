using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class ImageBiomeRecord
{
    public const string TABLE_NAME = "image_biome_record";
    public string Biomename {get; set;} = string.Empty;
    public long HiberliteId {get; set;}
    public string ImageShortname {get; set;} = string.Empty;
}
public static class ImageBiomeRecordExt
{
    public static void Insert(this Database database,ImageBiomeRecord image_biome_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {ImageBiomeRecord.TABLE_NAME} (biomename,image_shortname) VALUES ($biomename,$image_shortname);";
        cmd.Parameters.AddWithValue("$biomename",image_biome_record.Biomename);
        cmd.Parameters.AddWithValue("$image_shortname",image_biome_record.ImageShortname);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<ImageBiomeRecord> items)
    {
        foreach(ImageBiomeRecord image_biome_record in items)
            Insert(database,image_biome_record);
    }
    public static void Update(this Database database,ImageBiomeRecord image_biome_record)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {ImageBiomeRecord.TABLE_NAME} SET biomename = $biomename, image_shortname = $image_shortname WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$biomename",image_biome_record.Biomename);
        cmd.Parameters.AddWithValue("$hiberlite_id",image_biome_record.HiberliteId);
        cmd.Parameters.AddWithValue("$image_shortname",image_biome_record.ImageShortname);
        cmd.ExecuteNonQuery();
    }
    public static List<ImageBiomeRecord> ReadImageBiomeRecord(this Database database)
    {
        List<ImageBiomeRecord> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {ImageBiomeRecord.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new ImageBiomeRecord()
                {
                    Biomename = reader.GetText("biomename"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    ImageShortname = reader.GetText("image_shortname")
                }
            );
        }
        return items;
    }
}