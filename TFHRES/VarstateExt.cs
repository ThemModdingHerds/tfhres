using ThemModdingHerds.TFHResource.Data;

namespace ThemModdingHerds.TFHResource;
public static class VarstateExt
{
    public static long? GetStateAsNumber(this Varstate varstate)
    {
        bool parsed = long.TryParse(varstate.State,out long result);
        return parsed ? result : null;
    }
    public static bool? GetStateAsBoolean(this Varstate varstate)
    {
        bool parsed = bool.TryParse(varstate.State,out bool result);
        return parsed ? result : null;
    }
}