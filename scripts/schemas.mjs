import { SchemaTag, SchemaType } from "./sql.mjs"

export class Schema
{
    /** @type {Record<string,SchemaCell>} */
    cells = {};
    /**
     *
     * @param {string} name
     */
    constructor(name) {
        this.name = name
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
}

export class SchemaCell
{
    /**
     * @param {string} name
     * @param {SchemaType} type
     * @param {Array<string>} tags
     */
    constructor(name, type, tags = [])
    {
        this.name = name
        this.type = type
        this.tags = tags
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