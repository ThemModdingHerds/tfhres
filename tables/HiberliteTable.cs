using SQLite;

namespace ThemModdingHerds.TFHResource;
public class HiberliteTable
{
    [PrimaryKey, AutoIncrement, Column("hiberlite_id")]
    public int HiberliteId {get; set;}
}