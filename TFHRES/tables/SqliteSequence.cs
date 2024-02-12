using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource.Data;
public class SqliteSequence
{
    public const string TABLE_NAME = "sqlite_sequence";
    public string Name {get; set;} = string.Empty;
    public long Seq {get; set;}
}
public static class SqliteSequenceExt
{
    public static void Insert(this Database database,SqliteSequence sqlite_sequence)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {SqliteSequence.TABLE_NAME} (name,seq) VALUES ($name,$seq);";
        cmd.Parameters.AddWithValue("$name",sqlite_sequence.Name);
        cmd.Parameters.AddWithValue("$seq",sqlite_sequence.Seq);
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<SqliteSequence> items)
    {
        foreach(SqliteSequence sqlite_sequence in items)
            Insert(database,sqlite_sequence);
    }
    public static void Update(this Database database,SqliteSequence sqlite_sequence)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {SqliteSequence.TABLE_NAME} SET name = $name, seq = $seq WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$name",sqlite_sequence.Name);
        cmd.Parameters.AddWithValue("$seq",sqlite_sequence.Seq);
        cmd.ExecuteNonQuery();
    }
    public static List<SqliteSequence> ReadSqliteSequence(this Database database)
    {
        List<SqliteSequence> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {SqliteSequence.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new SqliteSequence()
                {
                    Name = reader.GetText("name"),
                    Seq = reader.GetInteger("seq")
                }
            );
        }
        return items;
    }
}