using System.Data;
using Microsoft.Data.Sqlite;

namespace ThemModdingHerds.TFHResource;
public static class SqliteExt
{
    public static T GetValue<T>(this SqliteDataReader reader,string name,T defaultValue)
    {
        object value = reader.GetValue(name);
        if(value is DBNull)
            return defaultValue;
        return (T)value;
    }
    public static long GetHiberliteId(this SqliteDataReader reader) => GetInteger(reader,"hiberlite_id");
    public static string GetText(this SqliteDataReader reader,string name) => GetValue(reader,name,string.Empty);
    public static long GetInteger(this SqliteDataReader reader,string name) => GetValue(reader,name,-1L);
    public static byte[] GetBlob(this SqliteDataReader reader,string name) => GetValue<byte[]>(reader,name,[]);
}