// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)
using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class Swfanim
{
    public const string TABLE_NAME = "swfanim";
    public const string CREATE_TABLE_COMMAND = "CREATE TABLE swfanim (bytes BLOB, hiberlite_id INTEGER PRIMARY KEY AUTOINCREMENT, shortname TEXT)";
    public byte[] Bytes {get; set;} = [];
    public long HiberliteId {get; set;}
    public string Shortname {get; set;} = string.Empty;
}
public static class SwfanimExt
{
    public static void Insert(this Database database,Swfanim swfanim)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {Swfanim.TABLE_NAME} (bytes,shortname) VALUES ($bytes,$shortname);";
        cmd.Parameters.AddWithValue("$bytes",swfanim.Bytes);
        cmd.Parameters.AddWithValue("$shortname",swfanim.Shortname);
        cmd.ExecuteNonQuery();
    }
    public static void ForceInsert(this Database database,Swfanim swfanim)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {Swfanim.TABLE_NAME} (bytes,hiberlite_id,shortname) VALUES ($bytes,$hiberlite_id,$shortname);";
        cmd.Parameters.AddWithValue("$bytes",swfanim.Bytes);
        cmd.Parameters.AddWithValue("$hiberlite_id",swfanim.HiberliteId);
        cmd.Parameters.AddWithValue("$shortname",swfanim.Shortname);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<Swfanim> items)
    {
        foreach(Swfanim swfanim in items)
            Insert(database,swfanim);
    }
    public static void ForceInsert(this Database database,IEnumerable<Swfanim> items)
    {
        foreach(Swfanim swfanim in items)
            ForceInsert(database,swfanim);
    }
    public static void Upsert(this Database database,Swfanim swfanim)
    {
        if(ExistsSwfanim(database,swfanim.HiberliteId))
        {
            Update(database,swfanim);
            return;
        }
        Insert(database,swfanim);
    }
    public static void Upsert(this Database database,IEnumerable<Swfanim> items)
    {
        foreach(Swfanim swfanim in items)
            Upsert(database,swfanim);
    }
    public static void Delsert(this Database database,Swfanim swfanim)
    {
        if(ExistsSwfanim(database,swfanim.HiberliteId))
        {
            DeleteSwfanim(database,swfanim.HiberliteId);
            return;
        }
        ForceInsert(database,swfanim);
    }
    public static void Delsert(this Database database,IEnumerable<Swfanim> items)
    {
        foreach(Swfanim swfanim in items)
            Delsert(database,swfanim);
    }
    public static void Update(this Database database,Swfanim swfanim)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {Swfanim.TABLE_NAME} SET bytes = $bytes, shortname = $shortname WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$bytes",swfanim.Bytes);
        cmd.Parameters.AddWithValue("$hiberlite_id",swfanim.HiberliteId);
        cmd.Parameters.AddWithValue("$shortname",swfanim.Shortname);
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<Swfanim> items)
    {
        foreach(Swfanim item in items)
            Update(database,item);
    }
    public static List<Swfanim> ReadSwfanim(this Database database)
    {
        List<Swfanim> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {Swfanim.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new Swfanim()
                {
                    Bytes = reader.GetBlob("bytes"),
                    HiberliteId = reader.GetInteger("hiberlite_id"),
                    Shortname = reader.GetText("shortname")
                }
            );
        }
        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId));
        return items;
    }
    public static Swfanim? ReadSwfanim(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {Swfanim.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new Swfanim()
            {
                Bytes = reader.GetBlob("bytes"),
                HiberliteId = reader.GetInteger("hiberlite_id"),
                Shortname = reader.GetText("shortname")
            };
        return null;
    }
    public static bool ExistsSwfanim(this Database database,long hiberlite_id)
    {
        return ReadSwfanim(database,hiberlite_id) != null;
    }
    public static bool ExistsSwfanim(this Database database,Swfanim swfanim)
    {
        return ExistsSwfanim(database,swfanim.HiberliteId);
    }
    public static void DeleteSwfanim(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {Swfanim.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void DeleteSwfanim(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {Swfanim.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }
}