import { mkdirSync, rmSync, writeFileSync } from "node:fs"
import { resolve } from "node:path"
import { schemas, Schema } from "./schemas.mjs"
import { THFRESOURCE_DATA_FOLDER, convert_name } from "./utils.mjs"
import { get_type, default_value_map, get_default_value, SchemaType } from "./sql.mjs"


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

const CSHARP_HEADER = "using System.Data;\nusing Microsoft.Data.Sqlite;\n\nnamespace ThemModdingHerds.TFHResource.Data;"

/**
 * 
 * @param {Schema} schema 
 */
function create_create_command(schema)
{
    return `CREATE TABLE ${schema.name} (${Object.entries(schema.cells).map(([name,cell]) => `${name} ${cell.type}` + (cell.tags.length != 0 ? " " + cell.tags.join(" ") : "")).join(", ")})`
}

/**
 * 
 * @param {Schema} schema 
 * @returns {string}
 */
function create_csharp_class(schema)
{
    const properties = []
    for(const [name,cell] of Object.entries(schema.cells))
        properties.push(create_property(name,cell.type))
    return `public class ${convert_name(schema.name)}
{
    public const string TABLE_NAME = "${schema.name}";
    public const string CREATE_TABLE_COMMAND = "${create_create_command(schema)}";
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
    const className = convert_name(schema.name)
    const hasId = typeof schema.cells["hiberlite_id"] != "undefined"
    /**
     * @param {string} name 
     * @returns {string}
     */
    function create_param(name)
    {
        return `        cmd.Parameters.AddWithValue("$${name}",${schema.name}.${convert_name(name)});`
    }
    /**
     * @returns {string}
     */
    function create_inserts()
    {
        return `    public static void Insert(this Database database,${className} ${schema.name})
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {${className}.TABLE_NAME} (${[...Object.keys(schema.cells)].filter((name) => name != "hiberlite_id").join(",")}) VALUES (${[...Object.keys(schema.cells)].filter((name) => name != "hiberlite_id").map((prop) => "$" + prop).join(",")});";
${[...Object.keys(schema.cells)].filter((name) => name != "hiberlite_id").map(create_param).join("\n")}
        cmd.ExecuteNonQuery();
    }
    public static void ForceInsert(this Database database,${className} ${schema.name})
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {${className}.TABLE_NAME} (${[...Object.keys(schema.cells)].join(",")}) VALUES (${[...Object.keys(schema.cells)].map((prop) => "$" + prop).join(",")});";
${[...Object.keys(schema.cells)].map(create_param).join("\n")}
        cmd.ExecuteNonQuery();
    }
    public static void Insert(this Database database,IEnumerable<${className}> items)
    {
        foreach(${className} ${schema.name} in items)
            Insert(database,${schema.name});
    }
    public static void ForceInsert(this Database database,IEnumerable<${className}> items)
    {
        foreach(${className} ${schema.name} in items)
            ForceInsert(database,${schema.name});
    }
    public static void Upsert(this Database database,${className} ${schema.name})
    {
        if(Exists${className}(database,${schema.name}.HiberliteId))
        {
            Update(database,${schema.name});
            return;
        }
        Insert(database,${schema.name});
    }
    public static void Upsert(this Database database,IEnumerable<${className}> items)
    {
        foreach(${className} ${schema.name} in items)
            Upsert(database,${schema.name});
    }
    public static void Delsert(this Database database,${className} ${schema.name})
    {
        if(Exists${className}(database,${schema.name}.HiberliteId))
        {
            Delete${className}(database,${schema.name}.HiberliteId);
            return;
        }
        ForceInsert(database,${schema.name});
    }
    public static void Delsert(this Database database,IEnumerable<${className}> items)
    {
        foreach(${className} ${schema.name} in items)
            Delsert(database,${schema.name});
    }`
    }
    function create_update()
    {
        return `    public static void Update(this Database database,${className} ${schema.name})
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE {${className}.TABLE_NAME} SET ${[...Object.keys(schema.cells)].filter((name) => name != "hiberlite_id").map((name) => `${name} = $${name}`).join(", ")} WHERE hiberlite_id = $hiberlite_id;";
${[...Object.keys(schema.cells)].map(create_param).join("\n")}
        cmd.ExecuteNonQuery();
    }
    public static void Update(this Database database,IEnumerable<${className}> items)
    {
        foreach(${className} item in items)
            Update(database,item);
    }`
    }
    function create_delete()
    {
        return `
    public static void Delete${className}(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {${className}.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        cmd.ExecuteNonQuery();
    }
    public static void Delete${className}(this Database database,IEnumerable<long> hiberlite_ids)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM {${className}.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        foreach(long hiberlite_id in hiberlite_ids)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
            cmd.ExecuteNonQuery();
        }
    }`
    }
    function create_read()
    {
        return `    public static List<${className}> Read${className}(this Database database)
    {
        List<${className}> items = [];
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {${className}.TABLE_NAME};";
        using(SqliteDataReader reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            items.Add(
                new ${className}()
                {
                    ${[...Object.entries(schema.cells)].map(([name,cell]) => `${convert_name(name)} = ${get_reader_method(cell.type,name)}`).join(",\n                    ")}
                }
            );
        }${hasId ? "\n        items.Sort((a,b) => (int)(a.HiberliteId - b.HiberliteId))" : ""};
        return items;
    }` + 
    (hasId ? `\n    public static ${className}? Read${className}(this Database database,long hiberlite_id)
    {
        SqliteCommand cmd = database.Connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {${className}.TABLE_NAME} WHERE hiberlite_id = $hiberlite_id;";
        cmd.Parameters.AddWithValue("$hiberlite_id",hiberlite_id);
        using SqliteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            return new ${className}()
            {
                ${[...Object.entries(schema.cells)].map(([name,cell]) => `${convert_name(name)} = ${get_reader_method(cell.type,name)}`).join(",\n                ")}
            };
        return null;
    }
    public static bool Exists${className}(this Database database,long hiberlite_id)
    {
        return Read${className}(database,hiberlite_id) != null;
    }
    public static bool Exists${className}(this Database database,${className} ${schema.name})
    {
        return Exists${className}(database,${schema.name}.HiberliteId);
    }` : "")
    }
    return `public static class ${className}Ext
{
${create_inserts()}
${create_update()}
${create_read()}${hasId ? create_delete() : ""}
}`
}

/**
 * 
 * @param {Schema} schema 
 * @returns 
 */
function create_code(schema)
{
    return ["// generated code. DO NOT MODIFY (see scripts/create-table.mjs in source code)",CSHARP_HEADER,create_csharp_class(schema),create_csharp_ext(schema)]
    .join("\n")
    .replace("\t"," ".repeat(4))
    .replace("\n\t","\n" + " ".repeat(4))
    .replace("\t\t"," ".repeat(8))
}

rmSync(THFRESOURCE_DATA_FOLDER,{recursive: true,force: true})
mkdirSync(THFRESOURCE_DATA_FOLDER)

for(const schema of schemas)
{
    if(typeof schema != "object") continue;
    const filepath = resolve(THFRESOURCE_DATA_FOLDER,`${convert_name(schema.name)}.cs`)
    writeFileSync(filepath,create_code(schema),"utf-8")
}