export class SchemaIndex
{
    /**
     * @param {string} name 
     * @param {string} table 
     * @param {Array<string>} cells 
     */
    constructor(name,table,cells)
    {
        this.name = name
        this.table = table
        this.cells = cells
    }
    create_command()
    {
        return `CREATE INDEX ${this.name} ON ${this.table} (${this.cells.join(", ")})`
    }
}

/** @type {Array<SchemaIndex>} */
export const indices = [
    new SchemaIndex("langcode","localized_text",["langcode"]),
    new SchemaIndex("shortname","cached_image",["shortname"]),
    new SchemaIndex("storyfile_dbname","localized_text",["storyfile_dbname"]),
    new SchemaIndex("tag","localized_text",["tag"])
]