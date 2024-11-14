import { default_value_map, get_default_value, get_type, SchemaTag, SchemaType } from "./sql.mjs"
import { convert_name, T } from "./utils.mjs"

export class SchemaCell
{
    /** @type {string} */
    name
    /** @type {SchemaType} */
    type
    /** @type {Array<SchemaTag>} */
    tags
    /** @type {Array<string>} */
    attributes
    /**
     * @param {string} name
     * @param {SchemaType} type
     * @param {Array<SchemaTag>} tags
     */
    constructor(name, type, tags = [])
    {
        this.name = name
        this.type = type
        this.tags = tags
        this.attributes = [`JsonPropertyName("${name}")`]
    }
    /**
     * @param {string} attribute 
     * @returns 
     */
    addAttribute(attribute)
    {
        this.attributes.push(attribute)
        return this
    }
    asProperty()
    {
        const attributes = this.attributes.map((attr) => `[${attr}]`)
        const property = T(4)+`public ${get_type(this.type)} ${convert_name(this.name)} {get;set;}`
        const defaultValue = typeof default_value_map[this.type] !== "undefined" ? ` = ${get_default_value(this.type)}` : ""
        return [
            attributes,
            property + defaultValue
        ].join("\n")
    }
    /**
     * @param {string} variable 
     */
    asSQLParameter(variable)
    {
        return T(8)+`cmd.Parameters.AddWithValue("$${this.name}",${variable}.${convert_name(this.name)});`
    }
}

export class Schema
{
    /** @type {Record<string,SchemaCell>} */
    cells = {};
    /** @readonly @type {string} */
    name
    /** @readonly @type {string} */
    className
    /**
     *
     * @param {string} name
     */
    constructor(name) {
        this.name = name
        this.className = convert_name(name)
    }
    /**
     *
     * @param {SchemaType} type
     * @param {string} name
     * @param {Array<SchemaTag>} tags
     * @returns {this}
     */
    addField(name, type, tags = [])
    {
        this.cells[name] = new SchemaCell(name, type, tags)
        return this
    }
    /**
     * 
     * @param {string} name 
     * @param {string} attribute 
     */
    addAttribute(name,attribute)
    {
        this.cells[name].addAttribute(attribute)
        return this
    }
    asCreateTable()
    {
        const values = Object.values(this.cells)
        .map((cell) => `${cell.name} ${cell.type}` + (cell.tags.length != 0 ? ` ${cell.tags.join(" ")}` : ""))
        .join(", ")
        return `CREATE TABLE ${this.name} (${values})`
    }
    asClass()
    {
        const properties = []
        for(const cell of Object.values(this.cells))
            properties.push(cell.asProperty())
        return [
            `public class ${convert_name(this.name)}`,
            "{",
            T(4)+`public const string TABLE_NAME = "${this.name}";`,
            T(4)+`public const string CREATE_TABLE_COMMAND = ${this.asCreateTable()};`,
            ...properties,
            "}"
        ].join("\n")
    }
    asSQLParameters()
    {
        return [...Object.values(this.cells)].map((cell) => cell.asSQLParameter(this.name))
    }
    /**
     * @param {Array<string>} parameters 
     */
    asInsertMethodBody(parameters)
    {
        return [
            T(8)+"SqliteCommand cmd = database.Connection.CreateCommand();",
            T(8)+`cmd.CommandText = $"INSERT INTO {${this.className}.TABLE_NAME} (${parameters.join(", ")}) VALUES (${parameters.map((p) => `$${p}`).join(", ")})";`,
            ...this.asSQLParameters(),
            T(8)+"cmd.ExecuteQuery();"
        ]
    }
    asInsert()
    {
        const sqlparameters = this.asSQLParameters().filter((p) => p.includes("hiberlite_id"))
        return [
            T(4)+`public static void Insert(this Database database,${this.className} ${this.name})`,
            T(4)+"{",
            this.asInsertMethodBody(sqlparameters),
            T(4)+"}"
        ].join("\n")
    }
    asForceInsert()
    {
        const sqlparameters = this.asSQLParameters()
        return [
            T(4)+`public static void ForceInsert(this Database database,${this.className} ${this.name})`,
            T(4)+"{",
            this.asInsertMethodBody(sqlparameters),
            T(4)+"}"
        ].join("\n")
    }
    /**
     * @param {string} name
     * @param {string} cond 
     * @param {string} final 
     * @returns 
     */
    asInsertCond(name,cond,final)
    {
        return [
            T(4)+`public static void ${name}(this Database database,${this.className} ${this.name})`,
            T(4)+"{",
            T(8)+`if(Exists${this.className}(database,${this.name}.HiberliteId))`,
            T(8)+"{",
            T(12)+`${cond}(database,${this.name});`,
            T(12)+"return;",
            T(8)+"}",
            T(4)+`${final}(database,${this.name});`,
            T(4)+"}"
        ].join("\n")
    }
    /**
     * @param {string} method 
     */
    asEnumerateMethod(method)
    {
        return [
            T(4)+`public static void ${method}(this Database database,IEnumerable<${this.className}> items)`,
            T(4)+"{",
            T(8)+`foreach(${this.className} ${this.name} in items)`,
            T(12)+`${method}(database,${this.name});`,
            T(4)+"}"
        ].join("\n")
    }
    asInsertsMethods()
    {
        const sqlparameters = this.asSQLParameters()
        return [
            this.asInsert(),
            this.asForceInsert(),
            this.asInsertCond("Upsert","Update","Insert"),
            this.asInsertCond("Delsert","Delete","ForceInsert"),
            this.asEnumerateMethod("Insert"),
            this.asEnumerateMethod("ForceInsert"),
            this.asEnumerateMethod("Upsert"),
            this.asEnumerateMethod("Delsert")
        ].join("\n")
    }
}

/** @type {Array<Schema>} */
export const schemas = [
    new Schema("cache_record")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("shortname", "TEXT")
        .addField("source_path", "TEXT"),
    new Schema("cached_image")
        .addField("height", "INTEGER")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("image_data", "BLOB")
        .addField("is_compressed", "INTEGER")
        .addField("shortname", "TEXT")
        .addField("vram_only", "INTEGER")
        .addField("width", "INTEGER"),
    new Schema("cached_textfile")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("shortname", "TEXT")
        .addField("source_file", "TEXT")
        .addField("text_data", "BLOB"),
    new Schema("filemap_record")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("shortname", "TEXT")
        .addField("source_path", "TEXT")
        .addField("type", "TEXT"),
    new Schema("image_biome_record")
        .addField("biomename", "TEXT")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("image_shortname", "TEXT"),
    new Schema("ink_bytecode")
        .addField("bytecode", "TEXT")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("mapname", "TEXT")
        .addField("shortname", "TEXT")
        .addField("source_file", "TEXT"),
    new Schema("jot_bytecode")
        .addField("bytecode", "TEXT")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("original", "TEXT")
        .addField("shortname", "TEXT"),
    new Schema("localized_text")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("langcode", "TEXT")
        .addField("storyfile_dbname", "TEXT")
        .addField("tag", "TEXT")
        .addField("text", "TEXT"),
    new Schema("map_biome_record")
        .addField("biomename", "TEXT")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("map_shortname", "TEXT"),
    new Schema("pixelanim")
        .addField("animtype","INTEGER")
        .addField("atlas_shortname","TEXT")
        .addField("compressed_frame_hiberlite_ids","BLOB")
        .addField("hiberlite_id","INTEGER")
        .addField("shortname","TEXT")
        .addField("ticks_per_frame","INTEGER"),
    new Schema("precache_record")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("mapname", "TEXT")
        .addField("shortname", "TEXT")
        .addField("type", "INTEGER"),
    new Schema("swfanim")
        .addField("bytes", "BLOB")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("shortname", "TEXT"),
    new Schema("tmx_map_instance")
        .addField("flattened_terrain_grid", "BLOB")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("map_id", "TEXT")
        .addField("tmx_source_filepath", "TEXT"),
    new Schema("tmx_map_instance_layers_items")
        .addField("hiberlite_entry_indx", "INTEGER")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("hiberlite_parent_id", "INTEGER")
        .addField("item_depth", "INTEGER")
        .addField("item_draw_layer", "INTEGER")
        .addField("item_layer_id","TEXT")
        .addField("item_layer_name", "TEXT")
        .addField("item_num_verticies", "INTEGER")
        .addField("item_tileset_image_shortname", "TEXT")
        .addField("item_vertex_data", "BLOB"),
    new Schema("tmx_map_instance_layers_items_item_animations_items")
        .addField("hiberlite_entry_indx", "INTEGER")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("hiberlite_parent_id", "INTEGER")
        .addField("item_max_frames", "INTEGER")
        .addField("item_munged_frames", "BLOB")
        .addField("item_starting_vertex", "INTEGER")
        .addField("item_ticks_per_frame", "INTEGER"),
    new Schema("varstate")
        .addField("biome", "TEXT")
        .addField("hiberlite_id", "INTEGER", ["PRIMARY KEY", "AUTOINCREMENT"])
        .addField("name", "TEXT")
        .addField("notes", "TEXT")
        .addField("state", "TEXT")
]