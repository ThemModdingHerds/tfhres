// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class CachedImage
{
    public const string TABLE_NAME = "cached_image";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE cached_image (height INTEGER, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, image_data BLOB, is_compressed INTEGER, shortname TEXT, vram_only INTEGER, width INTEGER)";
    [JsonPropertyName("height")]
    public long Height {get; set;}
    [JsonPropertyName("hiberlite_id")]
    public long HiberliteId {get; set;}
    [JsonPropertyName("image_data")]
    public byte[] ImageData {get; set;} = [];
    [JsonPropertyName("is_compressed")]
    public long IsCompressed {get; set;}
    [JsonPropertyName("shortname")]
    public string Shortname {get; set;} = string.Empty;
    [JsonPropertyName("vram_only")]
    public long VramOnly {get; set;}
    [JsonPropertyName("width")]
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
    public static void ForceInsert(this Database database,CachedImage cached_image)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {CachedImage.TABLE_NAME} (height,hiberlite_id,image_data,is_compressed,shortname,vram_only,width) VALUES ($height,$hiberlite_id,$image_data,$is_compressed,$shortname,$vram_only,$width);";
        cmd.Parameters.AddWithValue("$height",cached_image.Height);
        cmd.Parameters.AddWithValue("$hiberlite_id",cached_image.HiberliteId);
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
    public static void ForceInsert(this Database database,IEnumerable<CachedImage> items)
    {
        foreach(CachedImage cached_image in items)
            ForceInsert(database,cached_image);
    }
    public static void Upsert(this Database database,CachedImage cached_image)
    {
        if(ExistsCachedImage(database,cached_image.HiberliteId))
        {
            Update(database,cached_image);
            return;
        }
        Insert(database,cached_image);
    }
    public static void Upsert(this Database database,IEnumerable<CachedImage> items)
    {
        foreach(CachedImage cached_image in items)
            Upsert(database,cached_image);
    }
    public static void Delsert(this Database database,CachedImage cached_image)
    {
        if(ExistsCachedImage(database,cached_image.HiberliteId))
        {
            DeleteCachedImage(database,cached_image.HiberliteId);
            return;
        }
        ForceInsert(database,cached_image);
    }
    public static void Delsert(this Database database,IEnumerable<CachedImage> items)
    {
        foreach(CachedImage cached_image in items)
            Delsert(database,cached_image);
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
    public static void Update(this Database database,IEnumerable<CachedImage> items)
    {
        foreach(CachedImage item in items)
            Update(database,item);
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
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static CachedImage? ReadCachedImage(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {CachedImage.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new CachedImage()
            {
                Height = reader.GetInteger("height"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                ImageData = reader.GetBlob("image_data"),
                IsCompressed = reader.GetInteger("is_compressed"),
                Shortname = reader.GetText("shortname"),
                VramOnly = reader.GetInteger("vram_only"),
                Width = reader.GetInteger("width")
            };
        return null;
    }
    public static bool ExistsCachedImage(this Database database,long hiberlite_id)
    {
        return ReadCachedImage(database,hiberlite_id) != null;
    }
    public static bool ExistsCachedImage(this Database database,CachedImage cached_image)
    {
        return ExistsCachedImage(database,cached_image.HiberliteId);
    }
    public static void DeleteCachedImage(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {CachedImage.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteCachedImage(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {CachedImage.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}