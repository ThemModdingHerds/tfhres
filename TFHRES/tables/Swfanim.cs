using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class Swfanim
{
    public const string TABLE_NAME = "swfanim";
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
    public static void Insert(this Database database,IEnumerable<Swfanim> items)
    {
        foreach(Swfanim swfanim in items)
            Insert(database,swfanim);
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
        return items;
    }
}