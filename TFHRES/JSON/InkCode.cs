namespace ThemModdingHerds.TFHResource.JSON;
public class InkCode(int version,IEnumerable<object> root)
{
    public const int VERSION = 19;
    public int Version {get;set;} = version;
    public List<object> Root {get;set;} = [..root];
    public InkCode(IEnumerable<object> root): this(VERSION,root)
    {

    }
}