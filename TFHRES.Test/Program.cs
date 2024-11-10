using System.Data;
using System.Text;
using Microsoft.Data.Sqlite;
using ThemModdingHerds.TFHResource;
using ThemModdingHerds.TFHResource.Data;

string path = "G:\\SteamLibrary\\steamapps\\common\\Them's Fightin' Herds\\Scripts\\src\\Farm\\resources\\resources_prod.tfhres";
Database database = Database.Open(path);
Database mod = Database.Open("G:\\ThemModdingHerds\\VelvetBeautifier\\CLI\\bin\\Debug\\net8.0\\mods\\ntf.tfh.halloweenlobbies\\resources_prod.tfhres");
Database result = database.Clone();
result.Upsert(mod);
result.Save("test.tfhres",true);