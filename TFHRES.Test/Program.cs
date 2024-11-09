using System.Data;
using System.Text;
using Microsoft.Data.Sqlite;
using ThemModdingHerds.TFHResource;
using ThemModdingHerds.TFHResource.Data;

Database db = new();
db.Insert(new CacheRecord()
{
    Shortname = "memes",
    SourcePath = "lo/fu/you"
});
Database db2 = new();
db2.Insert(new CacheRecord()
{
    Shortname = "this record does not exist",
    SourcePath = "that's true"
});
db2.Insert(new CacheRecord()
{
    Shortname = "haha",
    SourcePath = "something/aa"
});
Database result = db2.Merge(db);
Console.WriteLine(result.ReadCacheRecord());