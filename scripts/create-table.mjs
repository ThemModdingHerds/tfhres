import { mkdirSync, rmSync, rmdirSync, writeFileSync } from "node:fs"
import { resolve, dirname } from "node:path"
import { fileURLToPath } from "node:url"

const __filename = fileURLToPath(import.meta.url)
const __dirname = dirname(__filename)

/** @type {"INTEGER" | "TEXT" | "BLOB"} */
const SchemaType = null

const type_map = {
    "INTEGER": "long",
    "TEXT": "string",
    "BLOB": "byte[]"
}

/**
 * 
 * @param {SchemaType} type 
 * @returns {"long" | "string" | "byte[]"}
 */
function get_type(type)
{
    if(type_map[type])
        return type_map[type]
    throw new Error(`no type exists for ${type}`)
}

/**
 * 
 * @param {SchemaType} type 
 * @param {string} name 
 * @returns {string}
 */
function get_reader_method(type,name)
{
    switch(type)
    {
        case "INTEGER":
            return `reader.GetInteger("${name}")`
        case "TEXT":
            return `reader.GetText("${name}")`
        case "BLOB":
            return `reader.GetBlob("${name}")`
        default:
            throw new Error(`no method exists for ${type}`)
    }
}

const default_value_map = {
    "TEXT": "string.Empty",
    "BLOB": "[]"
}

/**
 * 
 * @param {SchemaType} type 
 * @returns {"string.Empty" | ""}
 */
function get_default_value(type)
{
    if(default_value_map[type])
        return default_value_map[type]
    return ""
}

/**
 * 
 * @param {string} name 
 */
function convert_name(name)
{
    return name.split("_")
    .map((part) => part.charAt(0).toUpperCase() + part.slice(1))
    .join("")
}

/**
 * 
 * @param {string} name 
 * @param {SchemaType} type 
 */
function create_property(name,type)
{
    let prop = `public ${get_type(type)} ${convert_name(name)} {get; set;}`
    if(default_value_map[type])
        prop += ` = ${get_default_value(type)};`
    return prop
}

class Schema
{
    /** @type {Record<string,SchemaType} */
    props = {}
    /**
     * 
     * @param {string} name 
     */
    constructor(name)
    {
        this.name = name
    }
    /**
     * 
     * @param {SchemaType} type 
     * @param {string} name 
     * @returns {this}
     */
    addField(name,type)
    {
        this.props[name] = type
        return this
    }
}

/** @type {Array<Schema>} */
const schemas = [
    new Schema("cache_record")
    .addField("hiberlite_id","INTEGER")
    .addField("shortname","TEXT")
    .addField("source_path","TEXT"),
    new Schema("cached_image")
    .addField("height","INTEGER")
    .addField("hiberlite_id","INTEGER")
    .addField("image_data","BLOB")
    .addField("is_compressed","INTEGER")
    .addField("shortname","TEXT")
    .addField("vram_only","INTEGER")
    .addField("width","INTEGER"),
    new Schema("cached_textfile")
    .addField("hiberlite_id","INTEGER")
    .addField("shortname","TEXT")
    .addField("source_file","TEXT")
    .addField("text_data","BLOB"),
    new Schema("filemap_record")
    .addField("hiberlite_id","INTEGER")
    .addField("shortname","TEXT")
    .addField("source_path","TEXT")
    .addField("type","TEXT"),
    new Schema("image_biome_record")
    .addField("biomename","TEXT")
    .addField("hiberlite_id","INTEGER")
    .addField("image_shortname","TEXT"),
    new Schema("ink_bytecode")
    .addField("bytecode","TEXT")
    .addField("hiberlite_id","INTEGER")
    .addField("mapname","TEXT")
    .addField("shortname","TEXT")
    .addField("source_file","TEXT"),
    new Schema("jot_bytecode")
    .addField("bytecode","TEXT")
    .addField("hiberlite_id","INTEGER")
    .addField("orignal","TEXT")
    .addField("shortname","TEXT"),
    new Schema("localized_text")
    .addField("hiberlite_id","INTEGER")
    .addField("langcode","TEXT")
    .addField("storyfile_dbname","TEXT")
    .addField("tag","TEXT")
    .addField("text","TEXT"),
    new Schema("map_biome_record")
    .addField("biomename","TEXT")
    .addField("hiberlite_id","INTEGER")
    .addField("map_shortname","TEXT"),
    new Schema("pixelanim")
    .addField("animtype","INTEGER")
    .addField("atlas_shortname","TEXT")
    .addField("compressed_frame_hiberlite_ids","BLOB")
    .addField("shortname","TEXT")
    .addField("ticks_per_frame","INTEGER"),
    new Schema("precache_record")
    .addField("hiberlite_id","INTEGER")
    .addField("mapname","TEXT")
    .addField("shortname","TEXT")
    .addField("type","INTEGER"),
    new Schema("sqlite_sequence")
    .addField("name","TEXT")
    .addField("seq","INTEGER"),
    new Schema("swfanim")
    .addField("bytes","BLOB")
    .addField("hiberlite_id","INTEGER")
    .addField("shortname","TEXT"),
    new Schema("tmx_map_instance")
    .addField("flattened_terrain_grid","BLOB")
    .addField("hiberlite_id","INTEGER")
    .addField("map_id","TEXT")
    .addField("tmx_source_filepath","TEXT"),
    new Schema("tmx_map_instance_layers_items")
    .addField("hiberlite_entry_indx","INTEGER")
    .addField("hiberlite_id","INTEGER")
    .addField("hiberlite_parent_id","INTEGER")
    .addField("item_depth","INTEGER")
    .addField("item_draw_layer","INTEGER")
    .addField("item_layer_name","TEXT")
    .addField("item_num_vertices","INTEGER")
    .addField("item_tileset_image_shortname","TEXT")
    .addField("item_vertex_data","BLOB"),
    new Schema("tmx_map_instance_layers_items_item_animations_items")
    .addField("hiberlite_entry_indx","INTEGER")
    .addField("hiberlite_id","INTEGER")
    .addField("hiberlite_parent_id","INTEGER")
    .addField("item_max_frames","INTEGER")
    .addField("item_munged_frames","INTEGER")
    .addField("item_starting_vertex","INTEGER")
    .addField("item_ticks_per_frame","INTEGER"),
    new Schema("varstate")
    .addField("biome","TEXT")
    .addField("hiberlite_id","INTEGER")
    .addField("name","TEXT")
    .addField("notes","TEXT")
    .addField("state","TEXT")
]

const CSHARP_HEADER = "using Microsoft.Data.Sqlite;\n\nnamespace ThemModdingHerds.TFHResource.Data;"

/**
 * 
 * @param {Schema} schema 
 * @returns {string}
 */
function create_csharp_class(schema)
{
    const properties = []
    for(const [name,type] of Object.entries(schema.props))
        properties.push(create_property(name,type))
    return `public class ${convert_name(schema.name)}
{
    public const string TABLE_NAME = "${schema.name}";
    ${properties.join("\n    ")}
}`
}

/**
 * 
 * @param {Schema} schema 
 * @returns {string}
 */
function create_csharp_ext(schema)
{
    function create_param(name)
    {
        return `        cmd.Parameters.AddWithValue("$${name}",${schema.name}.${convert_name(name)});`
    }
    /**
     * 
     * @param {Schema} schema 
     * @returns {string}
     */
    function create_inserts()
    {
        
        const HEADER_BODY = `        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {${convert_name(schema.name)}.TABLE_NAME} (${[...Object.keys(schema.props)].filter((name) => name != "hiberlite_id").join(",")}) VALUES (${[...Object.keys(schema.props)].filter((name) => name != "hiberlite_id").map((prop) => "$" + prop).join(",")});";
${[...Object.keys(schema.props)].filter((name) => name != "hiberlite_id").map(create_param).join("\n")}
        cmd.ExecuteNonQuery();`
        return `    public static void Insert(this Database database,${convert_name(schema.name)} ${schema.name})
    {
${HEADER_BODY}
    }
    public static void Insert(this Database database,IEnumerable<${convert_name(schema.name)}> items)
    {
        foreach(${convert_name(schema.name)} ${schema.name} in items)
            Insert(database,${schema.name});
    }`
    }
    function create_update()
    {
        return `    public static void Update(this Database database,${convert_name(schema.name)} ${schema.name})
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {${convert_name(schema.name)}.TABLE_NAME} SET ${[...Object.keys(schema.props)].filter((name) => name != "hiberlite_id").map((name) => `${name} = $${name}`).join(", ")} WHERE hiberlite_id = $hiberlite_id;";
${[...Object.keys(schema.props)].map(create_param).join("\n")}
        cmd.ExecuteNonQuery();
    }`
    }
    function create_read()
    {

        return `    public static List<${convert_name(schema.name)}> Read${convert_name(schema.name)}(this Database database)
    {
        List<${convert_name(schema.name)}> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {${convert_name(schema.name)}.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new ${convert_name(schema.name)}()
                {
                    ${[...Object.entries(schema.props)].map(([name,type]) => `${convert_name(name)} = ${get_reader_method(type,name)}`).join(",\n                    ")}
                }
            );
        }
        return items;
    }`
    }
    return `public static class ${convert_name(schema.name)}Ext
{
${create_inserts()}
${create_update()}
${create_read()}
}`
}

/**
 * 
 * @param {Schema} schema 
 * @returns 
 */
function create_code(schema)
{
    return [CSHARP_HEADER,create_csharp_class(schema),create_csharp_ext(schema)]
    .join("\n")
    .replace("\t"," ".repeat(4))
    .replace("\n\t","\n" + " ".repeat(4))
    .replace("\t\t"," ".repeat(8))
}

const tables_folder = resolve("..","TFHRES","tables")

rmSync(tables_folder,{recursive: true,force: true})
mkdirSync(tables_folder)

for(const schema of schemas)
{
    if(typeof schema != "object") continue;
    const filepath = resolve(tables_folder,`${convert_name(schema.name)}.cs`)
    writeFileSync(filepath,create_code(schema),"utf-8")
}