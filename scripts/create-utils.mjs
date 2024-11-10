import { resolve } from "node:path"
import { Schema, schemas } from "./schemas.mjs"
import { TFHRESOURCE_FOLDER, convert_name } from "./utils.mjs"
import { existsSync, rmSync, writeFileSync } from "node:fs"
import { SchemaIndex, indices } from "./indices.mjs"

/**
 * 
 * @param {Schema} schema 
 */
function create_command_execution(schema)
{
    const className = convert_name(schema.name)
    return `        if(!connection.ExistsTable(${className}.TABLE_NAME))
        {
            command.CommandText = ${className}.CREATE_TABLE_COMMAND;
            command.ExecuteNonQuery();
        }`
}

/**
 * 
 * @param {SchemaIndex} index 
 */
function create_index_command_execution(index)
{
    return `        if(!connection.ExistsIndex("${index.name}"))
        {
            command.CommandText = "${index.create_command()}";
            command.ExecuteNonQuery();
        }`
}

function create_utils_file_body()
{
    return `// file generated. DO NOT MODIFY (see scripts/create-utils.mjs in source code)
using Microsoft.Data.Sqlite;
using ThemModdingHerds.TFHResource.Data;

namespace ThemModdingHerds.TFHResource;
public static class DatabaseUtils
{
    public static void CreateTables(SqliteConnection connection)
    {
        SqliteCommand command = connection.CreateCommand();
${schemas.map(create_command_execution).join("\n")}
${indices.map(create_index_command_execution).join("\n")}
    }
    public static void Upsert(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            ${schemas.map((schema) => `db.Upsert(database.Read${convert_name(schema.name)}());`).join("\n            ")}
        }
    }
    public static void Update(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            ${schemas.map((schema) => `db.Update(database.Read${convert_name(schema.name)}());`).join("\n            ")}
        }
    }
    public static void Insert(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            ${schemas.map((schema) => `db.Insert(database.Read${convert_name(schema.name)}());`).join("\n            ")}
        }
    }
    public static void ForceInsert(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            ${schemas.map((schema) => `db.ForceInsert(database.Read${convert_name(schema.name)}());`).join("\n            ")}
        }
    }
    public static void Delsert(this Database db,params Database[] databases)
    {
        foreach(Database database in databases)
        {
            ${schemas.map((schema) => `db.Delsert(database.Read${convert_name(schema.name)}());`).join("\n            ")}
        }
    }
}`
}

const file = resolve(TFHRESOURCE_FOLDER,"DatabaseUtils.cs")

if(existsSync(file))
    rmSync(file)
writeFileSync(file,create_utils_file_body(),"utf-8")