// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class ImageBiomeRecord
{
    public const string TABLE_NAME = "image_biome_record";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE image_biome_record (biomename TEXT, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, image_shortname TEXT)";
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
    public static void Upsert(this Database database,ImageBiomeRecord image_biome_record)
    {
        if(ExistsImageBiomeRecord(database,image_biome_record))
        {
            Update(database,image_biome_record);
            return;
        }
        Insert(database,image_biome_record);
    }
    public static void Upsert(this Database database,IEnumerable<ImageBiomeRecord> items)
    {
        foreach(ImageBiomeRecord image_biome_record in items)
            Upsert(database,image_biome_record);
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
    public static void Update(this Database database,IEnumerable<ImageBiomeRecord> items)
    {
        foreach(ImageBiomeRecord item in items)
            Update(database,item);
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
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static ImageBiomeRecord? ReadImageBiomeRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {ImageBiomeRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new ImageBiomeRecord()
            {
                Biomename = reader.GetText("biomename"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                ImageShortname = reader.GetText("image_shortname")
            };
        return null;
    }
    public static bool ExistsImageBiomeRecord(this Database database,long hiberlite_id)
    {
        return ReadImageBiomeRecord(database,hiberlite_id) != null;
    }
    public static bool ExistsImageBiomeRecord(this Database database,ImageBiomeRecord image_biome_record)
    {
        return ExistsImageBiomeRecord(database,image_biome_record.HiberliteId);
    }
    public static void DeleteImageBiomeRecord(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {ImageBiomeRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteImageBiomeRecord(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {ImageBiomeRecord.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}