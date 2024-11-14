import { dirname, resolve } from "node:path"
import { fileURLToPath } from "node:url"

const __filename = fileURLToPath(import.meta.url)
const __dirname = dirname(__filename)

/**
 *
 * @param {string} name
 */
export function convert_name(name)
{
    return name.split("_")
        .map((part) => part.charAt(0).toUpperCase() + part.slice(1))
        .join("")
}

export const T = (/** @type {number} */ a) => " ".repeat(a)

export const TFHRESOURCE_FOLDER = resolve(__dirname,"..","TFHRES")
export const THFRESOURCE_DATA_FOLDER = resolve(TFHRESOURCE_FOLDER,"Data")