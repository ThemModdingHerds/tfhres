# Them's Fightin' Herds Resource reader/writer

A library for reading/writing `.tfhres` files from Them's Fightin' Herds

## Usage

### Getting items

```c#
using ThemModdingHerds.Resource;
using ThemModdingHerds.Resource.Data;

Database database = new Database(pathToTfhresFile);

// required for any actions
database.Open();

// get all CachedImage records
List<CachedImage> images = database.ReadCachedImage();

// don't forget to close afterwards
database.Close();
```

### Updating items

```c#
using ThemModdingHerds.Resource;
using ThemModdingHerds.Resource.Data;

Database database = new Database(pathToTfhresFile);

// required for any actions
database.Open();

// imagine we got this CachedImage "image" from "database.ReadCachedImage()"

image.Height = 100; // Change property

database.Update(image);

// don't forget to close afterwards
database.Close();
```

### Adding new item(s)

```c#
using ThemModdingHerds.Resource;
using ThemModdingHerds.Resource.Data;

Database database = new Database(pathToTfhresFile);

// required for any actions
database.Open();

// the HiberliteId property isn't required
CachedTextfile textfile = new()
{
    Shortname = "deez nuts",
    SourceFile = "very/cool/path",
    TextData = Encoding.UTF8.GetBytes("hah, gottem")
};

// add item to databse. this also be a list of the same item type
database.Insert(textfile);

// don't forget to close afterwards
database.Close();
```
