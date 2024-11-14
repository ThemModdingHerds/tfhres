/**
 * @type {{"INTEGER": "long","TEXT": "string","BLOB": "byte[]"}}
 */
export const type_map = {
    "INTEGER": "long",
    "TEXT": "string",
    "BLOB": "byte[]"
}

/** @typedef @type {"INTEGER" | "TEXT" | "BLOB"} */
export const SchemaType = null
/** @typedef @type {"PRIMARY KEY" | "AUTOINCREMENT"} */
export const SchemaTag = null

/**
 *
 * @param {SchemaType} type
 * @returns {"long" | "string" | "byte[]"}
 */
export function get_type(type)
{
    if(type_map[type])
        return type_map[type]
    throw new Error(`no type exists for ${type}`)
}

/**
 * @type {{"TEXT": "string.Empty","BLOB": "[]","INTEGER": undefined}}
 */
export const default_value_map = {
    "TEXT": "string.Empty",
    "BLOB": "[]",
    "INTEGER": undefined
}

/**
 *
 * @param {SchemaType} type
 * @returns {"string.Empty" | "[]" | ""}
 */
export function get_default_value(type)
{
    if(default_value_map[type])
        return default_value_map[type]
    return ""
}

