using System;
using System.IO;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ProgramaIndiceCarpetas
{
    public static class ConvertidorArchivos
    {
        // Exporta el contenido del archivo a un PDF
        public static void ExportarAPdf(string rutaOrigen, string rutaDestino)
        {
            string contenido = File.ReadAllText(rutaOrigen);
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(rutaDestino, FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph(contenido));
            doc.Close();
        }

        // Exporta (copia) el contenido a un TXT
        public static void ExportarATxt(string rutaOrigen, string rutaDestino)
        {
            string contenido = File.ReadAllText(rutaOrigen);
            File.WriteAllText(rutaDestino, contenido);
        }

        // Convierte cada línea del archivo en un objeto JSON
        public static void ExportarAJson(string rutaOrigen, string rutaDestino)
        {
            string[] lineas = File.ReadAllLines(rutaOrigen);
            var objetoJson = new
            {
                ArchivoOriginal = Path.GetFileName(rutaOrigen),
                Contenido = lineas
            };
            string jsonString = JsonConvert.SerializeObject(objetoJson, Formatting.Indented);
            File.WriteAllText(rutaDestino, jsonString);
        }

        // Convierte el archivo a CSV (cada línea del archivo original será una fila)
        public static void ExportarACsv(string rutaOrigen, string rutaDestino)
        {
            string[] lineas = File.ReadAllLines(rutaOrigen);
            using (StreamWriter sw = new StreamWriter(rutaDestino))
            {
                sw.WriteLine("Linea,Texto");
                for (int i = 0; i < lineas.Length; i++)
                {
                    // Reemplazamos comillas dobles para evitar romper el formato CSV
                    string lineaEscapada = lineas[i].Replace("\"", "\"\"");
                    sw.WriteLine($"{i + 1},\"{lineaEscapada}\"");
                }
            }
        }
    }
}