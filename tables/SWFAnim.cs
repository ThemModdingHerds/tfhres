using SQLite;

namespace ThemModdingHerds.TFHResource;
[Table("swfanim")]
public class SWFAnim : HiberliteTable
{
    [Column("bytes")]
    public byte[] Bytes {get; set;} = [];
    [Column("shortname")]
    public string ShortName {get; set;} = "";
}