// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class Varstate
{
    public const string TABLE_NAME = "varstate";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE varstate (biome TEXT, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, notes TEXT, state TEXT)";
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
    public static void ForceInsert(this Database database,Varstate varstate)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {Varstate.TABLE_NAME} (biome,hiberlite_id,name,notes,state) VALUES ($biome,$hiberlite_id,$name,$notes,$state);";
        cmd.Parameters.AddWithValue("$biome",varstate.Biome);
        cmd.Parameters.AddWithValue("$hiberlite_id",varstate.HiberliteId);
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
    public static void ForceInsert(this Database database,IEnumerable<Varstate> items)
    {
        foreach(Varstate varstate in items)
            ForceInsert(database,varstate);
    }
    public static void Upsert(this Database database,Varstate varstate)
    {
        if(ExistsVarstate(database,varstate.HiberliteId))
        {
            Update(database,varstate);
            return;
        }
        Insert(database,varstate);
    }
    public static void Upsert(this Database database,IEnumerable<Varstate> items)
    {
        foreach(Varstate varstate in items)
            Upsert(database,varstate);
    }
    public static void Delsert(this Database database,Varstate varstate)
    {
        if(ExistsVarstate(database,varstate.HiberliteId))
        {
            DeleteVarstate(database,varstate.HiberliteId);
            return;
        }
        ForceInsert(database,varstate);
    }
    public static void Delsert(this Database database,IEnumerable<Varstate> items)
    {
        foreach(Varstate varstate in items)
            Delsert(database,varstate);
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
    public static void Update(this Database database,IEnumerable<Varstate> items)
    {
        foreach(Varstate item in items)
            Update(database,item);
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
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static Varstate? ReadVarstate(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {Varstate.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new Varstate()
            {
                Biome = reader.GetText("biome"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Name = reader.GetText("name"),
                Notes = reader.GetText("notes"),
                State = reader.GetText("state")
            };
        return null;
    }
    public static bool ExistsVarstate(this Database database,long hiberlite_id)
    {
        return ReadVarstate(database,hiberlite_id) != null;
    }
    public static bool ExistsVarstate(this Database database,Varstate varstate)
    {
        return ExistsVarstate(database,varstate.HiberliteId);
    }
    public static void DeleteVarstate(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {Varstate.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteVarstate(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {Varstate.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}