using System.ComponentModel.DataAnnotations.Schema;

namespace ThemModdingHerds.TFHResource;
[Table("jot_bytecode")]
public class JotBytecode : HiberliteTable
{
    [Column("bytecode")]
    public string Bytecode {get; set;} = "";
    [Column("orginal")]
    public string Orginal {get; set;} = "";
    [Column("shortname")]
    public string ShortName {get; set;} = "";
}