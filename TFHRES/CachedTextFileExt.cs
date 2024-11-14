using System.Text.Json;
using ThemModdingHerds.TFHResource.Data;
using ThemModdingHerds.TFHResource.JSON;

namespace ThemModdingHerds.TFHResource;
public static class CachedTextfileExt
{
    private static readonly JsonSerializerOptions json5 = new()
    {
        ReadCommentHandling = JsonCommentHandling.Skip
    };
    public static Atlas? ReadAtlas(this CachedTextfile textfile)
    {
        return JsonSerializer.Deserialize<Atlas>(textfile.TextData);
    }
    public static Dictionary<string,ObjectFileEntry> ReadObjectFileEntries(this CachedTextfile textfile)
    {
        return JsonSerializer.Deserialize<Dictionary<string,ObjectFileEntry>>(textfile.TextData,json5) ?? [];
    }
    public static World? ReadWorld(this CachedTextfile textfile)
    {
        return JsonSerializer.Deserialize<World>(textfile.TextData);
    }
    public static void SetTextData(this CachedTextfile textfile,TextData textData)
    {
        textfile.TextData = textData.ToTextData();
    }
}