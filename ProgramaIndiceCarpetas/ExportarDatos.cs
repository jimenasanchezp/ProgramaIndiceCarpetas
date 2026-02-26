using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json; // Requiere paquete NuGet: Newtonsoft.Json
using iTextSharp.text; // Requiere paquete NuGet: iTextSharp
using iTextSharp.text.pdf; // Requiere paquete NuGet: iTextSharp

namespace ProgramaIndiceCarpetas
{
    public static class ExportadorDatos
    {
        /// <summary>
        /// Exporta la lista de carpetas a un archivo CSV.
        /// </summary>
        public static void ExportarCSV(List<CarpetaInfo> indice, string rutaDestino)
        {
            StringBuilder sb = new StringBuilder();
            // Encabezados
            sb.AppendLine("Carpeta,RutaCompleta,CantidadArchivos,Archivos");

            foreach (var item in indice)
            {
                // Se unen los archivos con punto y coma para no romper el formato CSV
                string archivosUnidos = string.Join("; ", item.Archivos);
                sb.AppendLine($"\"{item.NombreCarpeta}\",\"{item.RutaCompleta}\",{item.CantidadArchivos},\"{archivosUnidos}\"");
            }

            File.WriteAllText(rutaDestino, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Exporta la lista de carpetas a un archivo de texto plano (TXT).
        /// </summary>
        public static void ExportarTXT(List<CarpetaInfo> indice, string rutaDestino)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ÍNDICE DE CARPETAS Y ARCHIVOS");
            sb.AppendLine("================================================");

            foreach (var item in indice)
            {
                sb.AppendLine($"Carpeta: {item.NombreCarpeta}");
                sb.AppendLine($"Ruta: {item.RutaCompleta}");
                sb.AppendLine($"Total de Archivos: {item.CantidadArchivos}");
                sb.AppendLine($"Archivos: {string.Join(", ", item.Archivos)}");
                sb.AppendLine("------------------------------------------------");
            }

            File.WriteAllText(rutaDestino, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Exporta la lista de carpetas a un archivo JSON.
        /// </summary>
        public static void ExportarJSON(List<CarpetaInfo> indice, string rutaDestino)
        {
            // Serializa la lista con indentación para que sea legible por humanos
            string jsonString = JsonConvert.SerializeObject(indice, Formatting.Indented);
            File.WriteAllText(rutaDestino, jsonString, Encoding.UTF8);
        }

        /// <summary>
        /// Exporta la lista de carpetas a un documento PDF.
        /// </summary>
        public static void ExportarPDF(List<CarpetaInfo> indice, string rutaDestino)
        {
            // Crear el documento con tamaño A4
            Document doc = new Document(PageSize.A4);

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaDestino, FileMode.Create));
                doc.Open();

                // Título del documento
                Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                Paragraph titulo = new Paragraph("Reporte de Índice de Carpetas\n\n", fuenteTitulo)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(titulo);

                // Fuente para el contenido
                Font fuenteContenido = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                Font fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                foreach (var item in indice)
                {
                    doc.Add(new Paragraph($"Carpeta: {item.NombreCarpeta}", fuenteNegrita));
                    doc.Add(new Paragraph($"Ruta: {item.RutaCompleta}", fuenteContenido));
                    doc.Add(new Paragraph($"Total Archivos: {item.CantidadArchivos}", fuenteContenido));
                    doc.Add(new Paragraph($"Archivos: {string.Join(", ", item.Archivos)}", fuenteContenido));
                    doc.Add(new Paragraph("---------------------------------------------------------------------------------------------------\n", fuenteContenido));
                }
            }
            finally
            {
                if (doc.IsOpen())
                {
                    doc.Close();
                }
            }
        }
    }
}