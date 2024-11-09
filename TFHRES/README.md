# Them's Fightin' Herds Resource reader/writer

A library for reading/writing `.tfhres` files from Them's Fightin' Herds

## Usage

### Getting items

```c#
using ThemModdingHerds.Resource;
using ThemModdingHerds.Resource.Data;

Database database = Database.Open(pathToTfhresFile);

// get all CachedImage records
List<CachedImage> images = database.ReadCachedImage();
// read the 20th CachedImage (might return null if the item does not exist)
CacheImage? image = database.ReadCachedImage(20);
```

### Updating items

```c#
using ThemModdingHerds.Resource;
using ThemModdingHerds.Resource.Data;

Database database = Database.Open(pathToTfhresFile);

// imagine we got this CachedImage "image" from "database.ReadCachedImage(long)" and it's not null

image.Height = 100; // Change property

database.Update(image); // update one item
database.Update(images); // update a list of items (images is a IEnumable)
database.Upsert(image); // updates if item with same id exists otherwise adds the item
```

### Adding new item(s)

```c#
using ThemModdingHerds.Resource;
using ThemModdingHerds.Resource.Data;

Database database = Database.Open(pathToTfhresFile);

// the HiberliteId property isn't required
CachedTextfile textfile = new()
{
    Shortname = "deez nuts",
    SourceFile = "very/cool/path",
    TextData = Encoding.UTF8.GetBytes("hah, gottem")
};

// add item to databse. this also be a list of the same item type
database.Insert(textfile);
```

### Merge Databases

```c#
Database result = database.Merge(otherDatabase); // keep in mind it returns a new database, it does not modify the variable
```
