using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class InkBytecode
{
    public const string TABLE_NAME = "ink_bytecode";
    public string Bytecode {get; set;} = string.Empty;
    public long HiberliteId {get; set;}
    public string Mapname {get; set;} = string.Empty;
    public string Shortname {get; set;} = string.Empty;
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
    public static void Insert(this Database database,IEnumerable<InkBytecode> items)
    {
        foreach(InkBytecode ink_bytecode in items)
            Insert(database,ink_bytecode);
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
        return items;
    }
}