using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class Varstate
{
    public const string TABLE_NAME = "varstate";
    public string Biome {get; set;} = string.Empty;
    public long HiberliteId {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Notes {get; set;} = string.Empty;
    public string State {get; set;} = string.Empty;
}
public static class VarstateExt
{
    public static void Insert(this Database database,Varstate varstate)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {Varstate.TABLE_NAME} (biome,name,notes,state) VALUES ($biome,$name,$notes,$state);";
        cmd.Parameters.AddWithValue("$biome",varstate.Biome);
        cmd.Parameters.AddWithValue("$name",varstate.Name);
        cmd.Parameters.AddWithValue("$notes",varstate.Notes);
        cmd.Parameters.AddWithValue("$state",varstate.State);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<Varstate> items)
    {
        foreach(Varstate varstate in items)
            Insert(database,varstate);
    }
    public static void Update(this Database database,Varstate varstate)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {Varstate.TABLE_NAME} SET biome = $biome, name = $name, notes = $notes, state = $state WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$biome",varstate.Biome);
        cmd.Parameters.AddWithValue("$hiberlite_id",varstate.HiberliteId);
        cmd.Parameters.AddWithValue("$name",varstate.Name);
        cmd.Parameters.AddWithValue("$notes",varstate.Notes);
        cmd.Parameters.AddWithValue("$state",varstate.State);
        cmd.ExecuteNonQuery();
    }
    public static List<Varstate> ReadVarstate(this Database database)
    {
        List<Varstate> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {Varstate.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new Varstate()
                {
                    Biome = reader.GetText("biome"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Name = reader.GetText("name"),
                    Notes = reader.GetText("notes"),
                    State = reader.GetText("state")
                }
            );
        }
        return items;
    }
}