using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class CachedImage
{
    public const string TABLE_NAME = "cached_image";
    public long Height {get; set;}
    public long HiberliteId {get; set;}
    public byte[] ImageData {get; set;} = [];
    public long IsCompressed {get; set;}
    public string Shortname {get; set;} = string.Empty;
    public long VramOnly {get; set;}
    public long Width {get; set;}
}
public static class CachedImageExt
{
    public static void Insert(this Database database,CachedImage cached_image)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {CachedImage.TABLE_NAME} (height,image_data,is_compressed,shortname,vram_only,width) VALUES ($height,$image_data,$is_compressed,$shortname,$vram_only,$width);";
        cmd.Parameters.AddWithValue("$height",cached_image.Height);
        cmd.Parameters.AddWithValue("$image_data",cached_image.ImageData);
        cmd.Parameters.AddWithValue("$is_compressed",cached_image.IsCompressed);
        cmd.Parameters.AddWithValue("$shortname",cached_image.Shortname);
        cmd.Parameters.AddWithValue("$vram_only",cached_image.VramOnly);
        cmd.Parameters.AddWithValue("$width",cached_image.Width);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<CachedImage> items)
    {
        foreach(CachedImage cached_image in items)
            Insert(database,cached_image);
    }
    public static void Update(this Database database,CachedImage cached_image)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {CachedImage.TABLE_NAME} SET height = $height, image_data = $image_data, is_compressed = $is_compressed, shortname = $shortname, vram_only = $vram_only, width = $width WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$height",cached_image.Height);
        cmd.Parameters.AddWithValue("$hiberlite_id",cached_image.HiberliteId);
        cmd.Parameters.AddWithValue("$image_data",cached_image.ImageData);
        cmd.Parameters.AddWithValue("$is_compressed",cached_image.IsCompressed);
        cmd.Parameters.AddWithValue("$shortname",cached_image.Shortname);
        cmd.Parameters.AddWithValue("$vram_only",cached_image.VramOnly);
        cmd.Parameters.AddWithValue("$width",cached_image.Width);
        cmd.ExecuteNonQuery();
    }
    public static List<CachedImage> ReadCachedImage(this Database database)
    {
        List<CachedImage> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {CachedImage.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new CachedImage()
                {
                    Height = reader.GetInteger("height"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    ImageData = reader.GetBlob("image_data"),
                    IsCompressed = reader.GetInteger("is_compressed"),
                    Shortname = reader.GetText("shortname"),
                    VramOnly = reader.GetInteger("vram_only"),
                    Width = reader.GetInteger("width")
                }
            );
        }
        return items;
    }
}