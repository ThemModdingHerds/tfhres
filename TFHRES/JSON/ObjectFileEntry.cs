using System.Text.Json.Serialization;

namespace ThemModdingHerds.TFHResource.JSON;
public class ObjectFileEntry(string prefix,IEnumerable<string> body,string description)
{
    [JsonPropertyName("prefix")]
    public string Prefix {get;set;} = prefix;
    [JsonPropertyName("body")]
    public List<string> Body {get;set;} = [..body];
    [JsonPropertyName("description")]
    public string Description {get;set;} = description;
    public const char BODY_SEPERATOR = '\n';
    public ObjectFileEntry(string prefix,string body,string description): this(prefix,body.Split(BODY_SEPERATOR),description)
    {
        
    }
}