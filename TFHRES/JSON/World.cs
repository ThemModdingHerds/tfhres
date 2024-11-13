using System.Text.Json.Serialization;

namespace ThemModdingHerds.TFHResource.JSON;
public class World(IEnumerable<WorldMap> maps,bool onlyShowAdjacentMaps)
{
    [JsonPropertyName("maps")]
    public List<WorldMap> Maps {get;set;} = [..maps];
    [JsonPropertyName("onlyShowAdjacentMaps")]
    public bool OnlyShowAdjacentMaps {get;set;} = onlyShowAdjacentMaps;
    public const string TYPE = "world";
    [JsonPropertyName("type")]
    public string Type {get;set;} = TYPE;
    public World(bool onlyShowAdjacentMaps): this([],onlyShowAdjacentMaps)
    {

    }
}
public class WorldMap(string fileName,int x,int y,int? width,int? height)
{
    [JsonPropertyName("fileName")]
    public string FileName {get;set;} = fileName;
    [JsonPropertyName("width")]
    public int? Width {get;set;} = width;
    [JsonPropertyName("height")]
    public int? Height {get;set;} = height;
    [JsonPropertyName("x")]
    public int X {get;set;} = x;
    [JsonPropertyName("y")]
    public int Y {get;set;} = y;
    public WorldMap(string fileName,int x,int y): this(fileName,x,y,null,null)
    {

    }
}