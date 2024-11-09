using System.Data;
using System.Text;
using Microsoft.Data.Sqlite;
using ThemModdingHerds.TFHResource;
using ThemModdingHerds.TFHResource.Data;

new Database().Save("test.tfhres",true);

Database db = Database.Open("test.tfhres");
Database db2 = new();

db2.Insert(new CacheRecord()
{
    Shortname = "a",
    SourcePath = "b"
});

Database both = db.Merge(db2);
db.Close();
db2.Close();
both.Save("test.tfhres",true);