using System.Text;
using System.Text.Json;

namespace ThemModdingHerds.TFHResource.JSON;
public abstract class TextData
{   
    public byte[] ToTextData()
    {
        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(this));
    }
}