using System.Text.Json;
using ThemModdingHerds.TFHResource.Data;
using ThemModdingHerds.TFHResource.JSON;

namespace ThemModdingHerds.TFHResource;
public static class CachedTextfileExt
{
    public static Atlas? ReadAtlas(this CachedTextfile textfile)
    {
        return JsonSerializer.Deserialize<Atlas>(textfile.TextData);
    }
    public static Dictionary<string,ObjectFileEntry>? ReadObjectFileEntries(this CachedTextfile textfile)
    {
        return JsonSerializer.Deserialize<Dictionary<string,ObjectFileEntry>>(textfile.TextData);
    }
    public static World? ReadWorld(this CachedTextfile textfile)
    {
        return JsonSerializer.Deserialize<World>(textfile.TextData);
    }
}