using System.Data;
using System.Text;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using ThemModdingHerds.TFHResource;
using ThemModdingHerds.TFHResource.Data;

string resource = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Them's Fightin' Herds\\Scripts\\src\\Farm\\resources";
string[] files = Directory.GetFiles(resource,"*.tfhres");

void Write<T>(string name,string tableName,List<T> values)
{
    string result = JsonSerializer.Serialize(values);
    string path = Path.Combine(name,$"{tableName}.json");
    File.WriteAllText(path,result);
}

foreach(string filepath in files)
{
    string name = Path.GetFileName(filepath) ?? throw new Exception();
    Directory.CreateDirectory(name);
    Database database = Database.Open(filepath);
    List<CachedImage> cachedImage = database.ReadCachedImage();
    Write(name,CachedImage.TABLE_NAME,cachedImage);
    List<CachedTextfile> cachedTextfile = database.ReadCachedTextfile();
    Write(name,CachedTextfile.TABLE_NAME,cachedTextfile);
    List<CacheRecord> cacheRecord = database.ReadCacheRecord();
    Write(name,CacheRecord.TABLE_NAME,cacheRecord);
    List<FilemapRecord> filemapRecord = database.ReadFilemapRecord();
    Write(name,FilemapRecord.TABLE_NAME,filemapRecord);
    List<ImageBiomeRecord> imageBiomeRecord = database.ReadImageBiomeRecord();
    Write(name,ImageBiomeRecord.TABLE_NAME,imageBiomeRecord);
    List<InkBytecode> inkBytecode = database.ReadInkBytecode();
    Write(name,InkBytecode.TABLE_NAME,inkBytecode);
    List<JotBytecode> jotBytecode = database.ReadJotBytecode();
    Write(name,JotBytecode.TABLE_NAME,jotBytecode);
    List<LocalizedText> localizedText = database.ReadLocalizedText();
    Write(name,LocalizedText.TABLE_NAME,localizedText);
    List<MapBiomeRecord> mapBiomeRecord = database.ReadMapBiomeRecord();
    Write(name,MapBiomeRecord.TABLE_NAME,mapBiomeRecord);
    List<Pixelanim> pixelAnim = database.ReadPixelanim();
    Write(name,Pixelanim.TABLE_NAME,pixelAnim);
    List<PrecacheRecord> precacheRecord = database.ReadPrecacheRecord();
    Write(name,PrecacheRecord.TABLE_NAME,precacheRecord);
    List<Swfanim> swfAnim = database.ReadSwfanim();
    Write(name,Swfanim.TABLE_NAME,swfAnim);
    List<TmxMapInstance> tmxMapInstance = database.ReadTmxMapInstance();
    Write(name,TmxMapInstance.TABLE_NAME,tmxMapInstance);
    List<TmxMapInstanceLayersItems> tmxMapInstanceLayersItems = database.ReadTmxMapInstanceLayersItems();
    Write(name,TmxMapInstanceLayersItems.TABLE_NAME,tmxMapInstanceLayersItems);
    List<TmxMapInstanceLayersItemsItemAnimationsItems> tmxMapInstanceLayersItemsItemANimationsItems = database.ReadTmxMapInstanceLayersItemsItemAnimationsItems();
    Write(name,TmxMapInstanceLayersItemsItemAnimationsItems.TABLE_NAME,tmxMapInstanceLayersItemsItemANimationsItems);
    List<Varstate> varstate = database.ReadVarstate();
    Write(name,Varstate.TABLE_NAME,varstate);
    database.Close();
}