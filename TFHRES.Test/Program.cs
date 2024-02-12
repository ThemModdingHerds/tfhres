using System.Text;
using Microsoft.Data.Sqlite;
using ThemModdingHerds.TFHResource;
using ThemModdingHerds.TFHResource.Data;

/*if (args.Length != 1)
{
    Console.WriteLine("usage: THFRES.Test.exe <*.tfhres>");
    Environment.Exit(1);
}
string path = args[0]
*/
string path = "G:\\SteamLibrary\\steamapps\\common\\Them's Fightin' Herds\\Scripts\\src\\Farm\\resources\\resources_prod.tfhres";
if(!File.Exists(path))
    throw new FileNotFoundException($"{path} does not exist");
Database database = new(path);

database.Open();

CachedTextfile textfile = new()
{
    Shortname = "deez nuts",
    SourceFile = "very/cool/path",
    TextData = Encoding.UTF8.GetBytes("hah, gottem")
};

database.Insert(textfile);