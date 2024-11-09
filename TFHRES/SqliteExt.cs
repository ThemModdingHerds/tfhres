using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource;
public static class SqliteExt
{
    public static T GetValue<T>(this SqliteDataReader reader,string name,T defaultValue)
    {
        if(reader.IsDBNull(name))
            return defaultValue;
        return reader.GetFieldValue<T>(name) ?? defaultValue;
    }
    public static long GetHiberliteId(this SqliteDataReader reader) => GetInteger(reader,"hiberlite_id");
    public static string GetText(this SqliteDataReader reader,string name) => GetValue(reader,name,string.Empty);
    public static long GetInteger(this SqliteDataReader reader,string name) => GetValue(reader,name,-1L);
    public static byte[] GetBlob(this SqliteDataReader reader,string name) => GetValue<byte[]>(reader,name,[]);
    public static bool ExistsTable(this SqliteConnection connection,string name)
    {
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{name}';";
        return command.ExecuteScalar() != null;
    }
    public static bool ExistsIndex(this SqliteConnection connection,string name)
    {
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"SELECT name FROM sqlite_master WHERE type='index' AND name='{name}';";
        return command.ExecuteScalar() != null;
    }
    public static SqliteConnection Clone(this SqliteConnection connection)
    {
        SqliteConnection clone = new();
        connection.BackupDatabase(clone);
        return clone;
    }
}