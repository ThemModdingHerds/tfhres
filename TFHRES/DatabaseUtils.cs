// file generated. DO NOT MODIFY (see scripts/create-utils.mjs in source code)
using Microsoft.Data.Sqlite;
using ThemModdingHerds.TFHResource.Data;

namespace ThemModdingHerds.TFHResource;
public static class DatabaseUtils
{
    public static void CreateTables(SqliteConnection connection)
    {
        SqliteCommand command = connection.CreateCommand();
        if(!connection.ExistsTable(CacheRecord.TABLE_NAME))
        {
            command.CommandText = CacheRecord.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(CachedImage.TABLE_NAME))
        {
            command.CommandText = CachedImage.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(CachedTextfile.TABLE_NAME))
        {
            command.CommandText = CachedTextfile.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(FilemapRecord.TABLE_NAME))
        {
            command.CommandText = FilemapRecord.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(ImageBiomeRecord.TABLE_NAME))
        {
            command.CommandText = ImageBiomeRecord.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(InkBytecode.TABLE_NAME))
        {
            command.CommandText = InkBytecode.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(JotBytecode.TABLE_NAME))
        {
            command.CommandText = JotBytecode.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(LocalizedText.TABLE_NAME))
        {
            command.CommandText = LocalizedText.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(MapBiomeRecord.TABLE_NAME))
        {
            command.CommandText = MapBiomeRecord.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(Pixelanim.TABLE_NAME))
        {
            command.CommandText = Pixelanim.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(PrecacheRecord.TABLE_NAME))
        {
            command.CommandText = PrecacheRecord.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(Swfanim.TABLE_NAME))
        {
            command.CommandText = Swfanim.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(TmxMapInstance.TABLE_NAME))
        {
            command.CommandText = TmxMapInstance.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(TmxMapInstanceLayersItems.TABLE_NAME))
        {
            command.CommandText = TmxMapInstanceLayersItems.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(TmxMapInstanceLayersItemsItemAnimationsItems.TABLE_NAME))
        {
            command.CommandText = TmxMapInstanceLayersItemsItemAnimationsItems.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsTable(Varstate.TABLE_NAME))
        {
            command.CommandText = Varstate.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsIndex("langcode"))
        {
            command.CommandText = "CREATE INDEX langcode ON localized_text (langcode)";
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsIndex("shortname"))
        {
            command.CommandText = "CREATE INDEX shortname ON cached_image (shortname)";
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsIndex("storyfile_dbname"))
        {
            command.CommandText = "CREATE INDEX storyfile_dbname ON localized_text (storyfile_dbname)";
            command.ExecuteNonQuery();
        }
        if(!connection.ExistsIndex("tag"))
        {
            command.CommandText = "CREATE INDEX tag ON localized_text (tag)";
            command.ExecuteNonQuery();
        }
    }
    public static void Upsert(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            db.Upsert(database.ReadCacheRecord());
            db.Upsert(database.ReadCachedImage());
            db.Upsert(database.ReadCachedTextfile());
            db.Upsert(database.ReadFilemapRecord());
            db.Upsert(database.ReadImageBiomeRecord());
            db.Upsert(database.ReadInkBytecode());
            db.Upsert(database.ReadJotBytecode());
            db.Upsert(database.ReadLocalizedText());
            db.Upsert(database.ReadMapBiomeRecord());
            db.Upsert(database.ReadPixelanim());
            db.Upsert(database.ReadPrecacheRecord());
            db.Upsert(database.ReadSwfanim());
            db.Upsert(database.ReadTmxMapInstance());
            db.Upsert(database.ReadTmxMapInstanceLayersItems());
            db.Upsert(database.ReadTmxMapInstanceLayersItemsItemAnimationsItems());
            db.Upsert(database.ReadVarstate());
        }
    }
    public static void Update(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            db.Update(database.ReadCacheRecord());
            db.Update(database.ReadCachedImage());
            db.Update(database.ReadCachedTextfile());
            db.Update(database.ReadFilemapRecord());
            db.Update(database.ReadImageBiomeRecord());
            db.Update(database.ReadInkBytecode());
            db.Update(database.ReadJotBytecode());
            db.Update(database.ReadLocalizedText());
            db.Update(database.ReadMapBiomeRecord());
            db.Update(database.ReadPixelanim());
            db.Update(database.ReadPrecacheRecord());
            db.Update(database.ReadSwfanim());
            db.Update(database.ReadTmxMapInstance());
            db.Update(database.ReadTmxMapInstanceLayersItems());
            db.Update(database.ReadTmxMapInstanceLayersItemsItemAnimationsItems());
            db.Update(database.ReadVarstate());
        }
    }
    public static void Insert(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            db.Insert(database.ReadCacheRecord());
            db.Insert(database.ReadCachedImage());
            db.Insert(database.ReadCachedTextfile());
            db.Insert(database.ReadFilemapRecord());
            db.Insert(database.ReadImageBiomeRecord());
            db.Insert(database.ReadInkBytecode());
            db.Insert(database.ReadJotBytecode());
            db.Insert(database.ReadLocalizedText());
            db.Insert(database.ReadMapBiomeRecord());
            db.Insert(database.ReadPixelanim());
            db.Insert(database.ReadPrecacheRecord());
            db.Insert(database.ReadSwfanim());
            db.Insert(database.ReadTmxMapInstance());
            db.Insert(database.ReadTmxMapInstanceLayersItems());
            db.Insert(database.ReadTmxMapInstanceLayersItemsItemAnimationsItems());
            db.Insert(database.ReadVarstate());
        }
    }
    public static void ForceInsert(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            db.ForceInsert(database.ReadCacheRecord());
            db.ForceInsert(database.ReadCachedImage());
            db.ForceInsert(database.ReadCachedTextfile());
            db.ForceInsert(database.ReadFilemapRecord());
            db.ForceInsert(database.ReadImageBiomeRecord());
            db.ForceInsert(database.ReadInkBytecode());
            db.ForceInsert(database.ReadJotBytecode());
            db.ForceInsert(database.ReadLocalizedText());
            db.ForceInsert(database.ReadMapBiomeRecord());
            db.ForceInsert(database.ReadPixelanim());
            db.ForceInsert(database.ReadPrecacheRecord());
            db.ForceInsert(database.ReadSwfanim());
            db.ForceInsert(database.ReadTmxMapInstance());
            db.ForceInsert(database.ReadTmxMapInstanceLayersItems());
            db.ForceInsert(database.ReadTmxMapInstanceLayersItemsItemAnimationsItems());
            db.ForceInsert(database.ReadVarstate());
        }
    }
    public static void Delsert(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            db.Delsert(database.ReadCacheRecord());
            db.Delsert(database.ReadCachedImage());
            db.Delsert(database.ReadCachedTextfile());
            db.Delsert(database.ReadFilemapRecord());
            db.Delsert(database.ReadImageBiomeRecord());
            db.Delsert(database.ReadInkBytecode());
            db.Delsert(database.ReadJotBytecode());
            db.Delsert(database.ReadLocalizedText());
            db.Delsert(database.ReadMapBiomeRecord());
            db.Delsert(database.ReadPixelanim());
            db.Delsert(database.ReadPrecacheRecord());
            db.Delsert(database.ReadSwfanim());
            db.Delsert(database.ReadTmxMapInstance());
            db.Delsert(database.ReadTmxMapInstanceLayersItems());
            db.Delsert(database.ReadTmxMapInstanceLayersItemsItemAnimationsItems());
            db.Delsert(database.ReadVarstate());
        }
    }
}