using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class JotBytecode
{
    public const string TABLE_NAME = "jot_bytecode";
    public string Bytecode {get; set;} = string.Empty;
    public long HiberliteId {get; set;}
    public string Orignal {get; set;} = string.Empty;
    public string Shortname {get; set;} = string.Empty;
}
public static class JotBytecodeExt
{
    public static void Insert(this Database database,JotBytecode jot_bytecode)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {JotBytecode.TABLE_NAME} (bytecode,orignal,shortname) VALUES ($bytecode,$orignal,$shortname);";
        cmd.Parameters.AddWithValue("$bytecode",jot_bytecode.Bytecode);
        cmd.Parameters.AddWithValue("$orignal",jot_bytecode.Orignal);
        cmd.Parameters.AddWithValue("$shortname",jot_bytecode.Shortname);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<JotBytecode> items)
    {
        foreach(JotBytecode jot_bytecode in items)
            Insert(database,jot_bytecode);
    }
    public static void Update(this Database database,JotBytecode jot_bytecode)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {JotBytecode.TABLE_NAME} SET bytecode = $bytecode, orignal = $orignal, shortname = $shortname WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$bytecode",jot_bytecode.Bytecode);
        cmd.Parameters.AddWithValue("$hiberlite_id",jot_bytecode.HiberliteId);
        cmd.Parameters.AddWithValue("$orignal",jot_bytecode.Orignal);
        cmd.Parameters.AddWithValue("$shortname",jot_bytecode.Shortname);
        cmd.ExecuteNonQuery();
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
                    Orignal = reader.GetText("orignal"),
                    Shortname = reader.GetText("shortname")
                }
            );
        }
        return items;
    }
}