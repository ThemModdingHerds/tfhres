using System.Text.Json.Serialization;

namespace ThemModdingHerds.TFHResource.JSON;
public class Atlas(Dictionary<string,AtlasFrame> frames,AtlasMetadata metadata) : TextData
{
    [JsonPropertyName("frames")]
    public Dictionary<string,AtlasFrame> Frames {get;set;} = frames;
    [JsonPropertyName("metadata")]
    public AtlasMetadata Metadata {get;set;} = metadata;
    public Atlas(AtlasMetadata metadata): this([],metadata)
    {

    }
    public Atlas(): this([],new())
    {

    }
}
public class AtlasFrame
{
    [JsonPropertyName("max.x")]
    public int MaxX {get;set;}
    [JsonPropertyName("min.x")]
    public int MinX {get;set;}
    [JsonPropertyName("max.y")]
    public int MaxY {get;set;}
    [JsonPropertyName("min.y")]
    public int MinY {get;set;}
}
public class AtlasMetadata
{
    [JsonPropertyName("height")]
    public int Height {get;set;}
    [JsonPropertyName("width")]
    public int Width {get;set;}
    [JsonPropertyName("tex_name")]
    public object? TexName {get;set;} = null;
}