// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class InkBytecode
{
    public const string TABLE_NAME = "ink_bytecode";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE ink_bytecode (bytecode TEXT, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, mapname TEXT, shortname TEXT, source_file TEXT)";
    [JsonPropertyName("bytecode")]
    public string Bytecode {get; set;} = string.Empty;
    [JsonPropertyName("hiberlite_id")]
    public long HiberliteId {get; set;}
    [JsonPropertyName("mapname")]
    public string Mapname {get; set;} = string.Empty;
    [JsonPropertyName("shortname")]
    public string Shortname {get; set;} = string.Empty;
    [JsonPropertyName("source_file")]
    public string SourceFile {get; set;} = string.Empty;
}
public static class InkBytecodeExt
{
    public static void Insert(this Database database,InkBytecode ink_bytecode)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {InkBytecode.TABLE_NAME} (bytecode,mapname,shortname,source_file) VALUES ($bytecode,$mapname,$shortname,$source_file);";
        cmd.Parameters.AddWithValue("$bytecode",ink_bytecode.Bytecode);
        cmd.Parameters.AddWithValue("$mapname",ink_bytecode.Mapname);
        cmd.Parameters.AddWithValue("$shortname",ink_bytecode.Shortname);
        cmd.Parameters.AddWithValue("$source_file",ink_bytecode.SourceFile);
        cmd.ExecuteNonQuery();
    }
    public static void ForceInsert(this Database database,InkBytecode ink_bytecode)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {InkBytecode.TABLE_NAME} (bytecode,hiberlite_id,mapname,shortname,source_file) VALUES ($bytecode,$hiberlite_id,$mapname,$shortname,$source_file);";
        cmd.Parameters.AddWithValue("$bytecode",ink_bytecode.Bytecode);
        cmd.Parameters.AddWithValue("$hiberlite_id",ink_bytecode.HiberliteId);
        cmd.Parameters.AddWithValue("$mapname",ink_bytecode.Mapname);
        cmd.Parameters.AddWithValue("$shortname",ink_bytecode.Shortname);
        cmd.Parameters.AddWithValue("$source_file",ink_bytecode.SourceFile);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<InkBytecode> items)
    {
        foreach(InkBytecode ink_bytecode in items)
            Insert(database,ink_bytecode);
    }
    public static void ForceInsert(this Database database,IEnumerable<InkBytecode> items)
    {
        foreach(InkBytecode ink_bytecode in items)
            ForceInsert(database,ink_bytecode);
    }
    public static void Upsert(this Database database,InkBytecode ink_bytecode)
    {
        if(ExistsInkBytecode(database,ink_bytecode.HiberliteId))
        {
            Update(database,ink_bytecode);
            return;
        }
        Insert(database,ink_bytecode);
    }
    public static void Upsert(this Database database,IEnumerable<InkBytecode> items)
    {
        foreach(InkBytecode ink_bytecode in items)
            Upsert(database,ink_bytecode);
    }
    public static void Delsert(this Database database,InkBytecode ink_bytecode)
    {
        if(ExistsInkBytecode(database,ink_bytecode.HiberliteId))
        {
            DeleteInkBytecode(database,ink_bytecode.HiberliteId);
            return;
        }
        ForceInsert(database,ink_bytecode);
    }
    public static void Delsert(this Database database,IEnumerable<InkBytecode> items)
    {
        foreach(InkBytecode ink_bytecode in items)
            Delsert(database,ink_bytecode);
    }
    public static void Update(this Database database,InkBytecode ink_bytecode)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {InkBytecode.TABLE_NAME} SET bytecode = $bytecode, mapname = $mapname, shortname = $shortname, source_file = $source_file WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$bytecode",ink_bytecode.Bytecode);
        cmd.Parameters.AddWithValue("$hiberlite_id",ink_bytecode.HiberliteId);
        cmd.Parameters.AddWithValue("$mapname",ink_bytecode.Mapname);
        cmd.Parameters.AddWithValue("$shortname",ink_bytecode.Shortname);
        cmd.Parameters.AddWithValue("$source_file",ink_bytecode.SourceFile);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<InkBytecode> items)
    {
        foreach(InkBytecode item in items)
            Update(database,item);
    }
    public static List<InkBytecode> ReadInkBytecode(this Database database)
    {
        List<InkBytecode> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {InkBytecode.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new InkBytecode()
                {
                    Bytecode = reader.GetText("bytecode"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Mapname = reader.GetText("mapname"),
                    Shortname = reader.GetText("shortname"),
                    SourceFile = reader.GetText("source_file")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static InkBytecode? ReadInkBytecode(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {InkBytecode.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new InkBytecode()
            {
                Bytecode = reader.GetText("bytecode"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Mapname = reader.GetText("mapname"),
                Shortname = reader.GetText("shortname"),
                SourceFile = reader.GetText("source_file")
            };
        return null;
    }
    public static bool ExistsInkBytecode(this Database database,long hiberlite_id)
    {
        return ReadInkBytecode(database,hiberlite_id) != null;
    }
    public static bool ExistsInkBytecode(this Database database,InkBytecode ink_bytecode)
    {
        return ExistsInkBytecode(database,ink_bytecode.HiberliteId);
    }
    public static void DeleteInkBytecode(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {InkBytecode.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteInkBytecode(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {InkBytecode.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}