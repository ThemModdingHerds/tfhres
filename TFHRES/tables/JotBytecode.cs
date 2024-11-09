// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class JotBytecode
{
    public const string TABLE_NAME = "jot_bytecode";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE jot_bytecode (bytecode TEXT, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, original TEXT, shortname TEXT)";
    public string Bytecode {get; set;} = string.Empty;
    public long HiberliteId {get; set;}
    public string Original {get; set;} = string.Empty;
    public string Shortname {get; set;} = string.Empty;
}
public static class JotBytecodeExt
{
    public static void Insert(this Database database,JotBytecode jot_bytecode)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {JotBytecode.TABLE_NAME} (bytecode,original,shortname) VALUES ($bytecode,$original,$shortname);";
        cmd.Parameters.AddWithValue("$bytecode",jot_bytecode.Bytecode);
        cmd.Parameters.AddWithValue("$original",jot_bytecode.Original);
        cmd.Parameters.AddWithValue("$shortname",jot_bytecode.Shortname);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<JotBytecode> items)
    {
        foreach(JotBytecode jot_bytecode in items)
            Insert(database,jot_bytecode);
    }
    public static void Upsert(this Database database,JotBytecode jot_bytecode)
    {
        if(ExistsJotBytecode(database,jot_bytecode))
        {
            Update(database,jot_bytecode);
            return;
        }
        Insert(database,jot_bytecode);
    }
    public static void Upsert(this Database database,IEnumerable<JotBytecode> items)
    {
        foreach(JotBytecode jot_bytecode in items)
            Upsert(database,jot_bytecode);
    }
    public static void Update(this Database database,JotBytecode jot_bytecode)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {JotBytecode.TABLE_NAME} SET bytecode = $bytecode, original = $original, shortname = $shortname WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$bytecode",jot_bytecode.Bytecode);
        cmd.Parameters.AddWithValue("$hiberlite_id",jot_bytecode.HiberliteId);
        cmd.Parameters.AddWithValue("$original",jot_bytecode.Original);
        cmd.Parameters.AddWithValue("$shortname",jot_bytecode.Shortname);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<JotBytecode> items)
    {
        foreach(JotBytecode item in items)
            Update(database,item);
    }
    public static List<JotBytecode> ReadJotBytecode(this Database database)
    {
        List<JotBytecode> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {JotBytecode.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new JotBytecode()
                {
                    Bytecode = reader.GetText("bytecode"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Original = reader.GetText("original"),
                    Shortname = reader.GetText("shortname")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static JotBytecode? ReadJotBytecode(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {JotBytecode.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new JotBytecode()
            {
                Bytecode = reader.GetText("bytecode"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Original = reader.GetText("original"),
                Shortname = reader.GetText("shortname")
            };
        return null;
    }
    public static bool ExistsJotBytecode(this Database database,long hiberlite_id)
    {
        return ReadJotBytecode(database,hiberlite_id) != null;
    }
    public static bool ExistsJotBytecode(this Database database,JotBytecode jot_bytecode)
    {
        return ExistsJotBytecode(database,jot_bytecode.HiberliteId);
    }
    public static void DeleteJotBytecode(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {JotBytecode.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteJotBytecode(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {JotBytecode.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}